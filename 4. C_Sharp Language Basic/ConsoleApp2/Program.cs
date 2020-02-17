using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterModifiersTest t1 = new ParameterModifiersTest();            
            int b = 100;

            Console.WriteLine($"old value : b {b}");
            ParameterModifiersTest.testRefModifierMultiplyBy55(ref b);
            Console.WriteLine($"new value : b {b}");

            //int a;
            ParameterModifiersTest.testOutModifierEquals65648(out int a);
            Console.WriteLine($"new value of a: {a}");

            int.TryParse("das", out var tt);
        }
    }

    public class ParameterModifiersTest
    {


        public static void testRefModifierMultiplyBy55(ref int b)
        {
            b *= 55;
        }

        public static void testOutModifierEquals65648(out int a)
        {
            a = 65648;
        }
    }
}
