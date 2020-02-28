
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public static class ColoredConsole
    {
        public static void Print(this string str, ConsoleColor color)
        {
            Print(color, str);
        }

        public static void Print(ConsoleColor color, string str)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }



    

}
