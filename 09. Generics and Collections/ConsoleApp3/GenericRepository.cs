using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ConsoleApp3
{
    class GenericRepository<T,U> : IGenericRepository<T,U> where T : IEntity<U>
    {
        private List<T> Storage;

        public GenericRepository()
        {
            Storage = new List<T>();
        }
        public void Delete(U id)
        {
            var item = Storage.FirstOrDefault(m => m.Id.Equals(id));
            Storage.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return Storage;
        }

        public T GetById(U id)
        {
            return Storage.FirstOrDefault(m => m.Id.Equals(id));
        }

        public void Insert(T obj)
        {
            Storage.Add(obj);
        }

        public void Update(T obj)
        {
            var item = Storage.FirstOrDefault(m => m.Id.Equals(obj.Id));
            item = obj;
            
        }

    }
}
