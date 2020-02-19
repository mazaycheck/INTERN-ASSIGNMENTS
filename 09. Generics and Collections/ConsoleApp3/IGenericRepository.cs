using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    interface IGenericRepository<T,U> where T : IEntity<U>
    {
        IEnumerable<T> GetAll();
        T GetById(U id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(U id);
    }
}
