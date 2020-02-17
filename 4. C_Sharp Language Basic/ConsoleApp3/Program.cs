using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct a = new MyStruct(50);            
            MyClass b = new MyClass(50);
            
            object aObj = a;
            object bObj = b;

            a.multiplyBy(100);
            b.multiplyBy(100);
   
            Console.WriteLine(((MyStruct)aObj).X);
            Console.WriteLine(((MyClass)bObj).X);                        
        }
    }

    public struct MyStruct
    {
        public int X { get; set; }
        public MyStruct(int n) { X = n; }
        public void multiplyBy(int n)
        {
            X *= n;
        }

    }

    public class MyClass
    {
        public int X { get; set; }
        public MyClass(int n) => X = n;

        public void multiplyBy(int n) => X *= n;

    }
}
