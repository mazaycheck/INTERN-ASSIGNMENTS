using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RandomIntArray = Arrays.GenerateOneDimensionalIntArray(10);
            Console.WriteLine("Array of random ints");
            foreach (var item in RandomIntArray)
                Console.Write(item + ", ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tree");
            Console.ForegroundColor = ConsoleColor.Green;
            string[] Pyramid = Arrays.CreateAPyramid(15);
            foreach (var item in Pyramid) {
                
                Console.Write(item); }
                
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            string[,] Letters = Arrays.Create2DImensionalArray(10);
            for (int i  = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Console.Write(Letters[i,y] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Jagged Array");
            char[][] chararray = Arrays.CreateJaggedCharArray(10, '$');
            foreach (var item in chararray)
            {
                
                Console.WriteLine($"{new string(item).PadRight(10,' ')} {item.Length} dollars");
            }



        }                
    }


    public class Arrays
    {
        public static int[] GenerateOneDimensionalIntArray(int size)
        {
            Random randomNumberGenerator = new Random();
            int[] RandomIntArray = new int[size];
            int[] arra1 = { 3, 4, 5 };
            int[] arra2 = new int[] { 3, 4, 5 };            
            for (int i = 0; i < size; i++)
            {
                RandomIntArray[i] = randomNumberGenerator.Next(1,100);
            }
            return RandomIntArray;
        }

        public static string[] CreateAPyramid(int size)
        {
            string[] Pyramid = new string[size];

            for (int i = 0; i < size; i++)
            {
                string line = new string(' ', size - i) + new string('*', (i * 2) + 1)   + "\n";
                Pyramid[i] = line;
            }
            return Pyramid;
        }

        public static string[,] Create2DImensionalArray(int size = 24)
        {
            string[,] d2array = new string[size, size];
            char letter1, letter2;
            letter1 = '@';
            letter2 = '@';
            for (int i = 0; i < size; i++)
            {
                letter1 = (char)((int)letter1 + 1);
                for (int y = 0; y < size; y++)
                {
                    letter2 = (char)((int)letter2 + 1);
                    d2array[i, y] = (letter1.ToString() + " " +  letter2.ToString());        
                   
                }             
                letter2 = 'A';
            }

            return d2array;
        }

        public static char[][] CreateJaggedCharArray(int size, char ch)
        {
            var rnd = new Random();
            char[][] jaggerCharArray = new char[size][];
            char[][] jagged1 = new char[][] { new char[] { 'a', 'b', 'c' }, new char[] { 'a' } };
            char[][] jagged4 = new char[2][] { new char[] { 'a', 'b', 'c' }, new char[] { 'a','q','e','f' } };
            for (int i = 0; i < size; i++)
            {
                int insideSize = rnd.Next(1, 10);
                jaggerCharArray[i] = new char[insideSize];
                
                for (int y = 0; y < insideSize; y++)
                {
                    jaggerCharArray[i][y] = ch;
                }
            }
            return jaggerCharArray;
        }
    }
}
