using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    interface IGenericRepository<T, TId> where T : IEntity<TId>
    {
        IEnumerable<T> GetAll();
        T GetById(TId id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(TId id);
    }
}
