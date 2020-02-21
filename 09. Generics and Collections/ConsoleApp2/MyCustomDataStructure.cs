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
        private int size;

        public T this[int i] { 
            get { if (i >= 0 && i < size) return Storage[i]; else throw new IndexOutOfRangeException();}
            set { if (i >= 0 && i < size)  Storage[i] = value; else throw new IndexOutOfRangeException();}
        }

        public MyCustomDataStructure(int size) 
        {
            Storage = new T[size];
            this.size = size;
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
