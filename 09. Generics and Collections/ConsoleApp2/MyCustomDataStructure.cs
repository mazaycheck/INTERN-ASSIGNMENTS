using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class MyCustomDataStructure<T>  : IEnumerable
    {
        private T[] Storage;
        private int index = 0;

        public T this[int i] { 
            get { return Storage[i]; }
            set { Storage[i] = value; }
        }

        public MyCustomDataStructure(int size) 
        {
            Storage = new T[size];
        }
        
        public void Add(T value)
        {
            Storage[index++] = value;
        }

        public void Swap(int x, int y)
        {
            T tmp = Storage[x];
            Storage[x] = Storage[y];
            Storage[y] = tmp;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return Storage.GetEnumerator();
        }
    }
}
