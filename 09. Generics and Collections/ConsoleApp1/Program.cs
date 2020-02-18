using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new TestObject(4, 3);
            var obj2 = new TestObject(2, 5);
            var obj3 = new TestObject(4, 3);
            var tester = new TestObjectsComparer();
            var resultofcompare = tester.Equals(obj1, obj2);
            var resultofcompare2 = tester.Equals(obj1, obj3);
            Console.WriteLine(resultofcompare);
            Console.WriteLine(resultofcompare2);
        }
    }

    class TestObject
    {
        public int Field1 { get; set; }
        public int Field2 { get; set; }

        public TestObject(int a, int b)
        {
            Field1 = a;
            Field2 = b;
        }
    }

    class TestObjectsComparer : IEqualityComparer<TestObject>
    {
        public bool Equals([AllowNull] TestObject x, [AllowNull] TestObject y)
        {
            if (x.Field1 == y.Field1 && x.Field2 == y.Field2)
                return true;
            return false;
        }

        public int GetHashCode([DisallowNull] TestObject obj)
        {
            return $"{obj.Field1}:{obj.Field2}".GetHashCode();
        }
    }
}
