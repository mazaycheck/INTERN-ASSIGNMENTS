using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticConstructorClass ct = new StaticConstructorClass();
            StaticConstructorClass ct2 = new StaticConstructorClass();
            StaticConstructorClass ct3 = new StaticConstructorClass();
            Console.WriteLine(StaticConstructorClass.StaticField);
        }
    }

    public class StaticConstructorClass
    {
        public static int StaticField { get; set; }
        static StaticConstructorClass()
        {
            Console.WriteLine("Message from Static c-tor");
            StaticField = 99;
        }

        public StaticConstructorClass()
        {
            Console.WriteLine("Hello from default constr");
        }
    }
}
