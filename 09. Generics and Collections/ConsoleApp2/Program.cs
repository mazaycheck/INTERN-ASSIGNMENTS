using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCustomDataStructure<int> s1 = new MyCustomDataStructure<int>(10) { 41, 12, 35, 46, 53, 62, 71, 83, 9, 60 };

            Console.WriteLine(s1[0]);
            Console.WriteLine(s1[1]);
            Console.WriteLine(s1[2]);
            Console.WriteLine(s1[3]);
            Console.WriteLine(s1[4]);

            foreach (var item in s1)
            {
                Console.WriteLine(item);
            }
       
        }

        
    }

    
}
