using System;
using System.Threading;

namespace ConsoleApp5
{
    class Program
    {
        public static void CreateThread()
        {            
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(600);
                Console.WriteLine("Message from second thread");
            }            
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(CreateThread));
            th.Start();            
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Message from first thread");
                Console.ForegroundColor = color;

            }           
        }
    }
}
