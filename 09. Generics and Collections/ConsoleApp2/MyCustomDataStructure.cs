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
            if (index < Storage.Length)
                Storage[index++] = value;
            else
                throw new IndexOutOfRangeException();
        }

        public void Swap(int x, int y)
        {
            if (x >= 0 && x < Storage.Length && y >= 0 && y < Storage.Length)
            {
                T tmp = Storage[x];
                Storage[x] = Storage[y];
                Storage[y] = tmp;
            }
            else
                throw new IndexOutOfRangeException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Storage.GetEnumerator();
        }
    }
}
