using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCustomDataStructure<int> s1 = new MyCustomDataStructure<int>(10) { 41, 12, 35, 46, 53, 62, 71, 83, 9, 60 };
            s1[0] = 1000;            
            int index = 0;
            Console.WriteLine($"{index} : {s1[index++]}" );
            Console.WriteLine($"{index} : {s1[index++]}" );
            Console.WriteLine($"{index} : {s1[index++]}" );                        
            Console.WriteLine("Iterating");
            foreach (var item in s1)
            {

                Console.Write(item + " ");
            }
            Console.WriteLine();
            s1.Swap(0, 9);
            s1.Swap(1, 8);
            s1.Swap(2, 7);            
            Console.WriteLine("After swap");
            foreach (var item in s1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
       
        }

        
    }

    
}
