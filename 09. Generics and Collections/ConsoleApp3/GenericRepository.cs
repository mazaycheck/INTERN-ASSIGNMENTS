using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ConsoleApp3
{
    class GenericRepository<T,TId> : IGenericRepository<T,TId> where T : IEntity<TId>
    {
        private readonly List<T> _storage;

        public GenericRepository()
        {
            _storage = new List<T>();
        }
        public void Delete(TId id)
        {
            var item = _storage.FirstOrDefault(m => m.Id.Equals(id));
            _storage.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _storage;
        }

        public T GetById(TId id)
        {
            return _storage.FirstOrDefault(m => m.Id.Equals(id));
        }

        public void Insert(T obj)
        {
            _storage.Add(obj);
        }

        public void Update(T obj)
        {
            var item = _storage.FirstOrDefault(m => m.Id.Equals(obj.Id));
            item = obj;
            
        }

    }
}
