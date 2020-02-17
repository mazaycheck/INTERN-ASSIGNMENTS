using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ValuePoint sp1 = new ValuePoint(4, 5);
            ValuePoint sp2 = new ValuePoint(8, 3);

            RefPoint rp1 = new RefPoint(3, 4);
            RefPoint rp2 = new RefPoint(6, 9);

            double structdistance = ValuePoint.CalculateDistance(sp1, sp2);
            double refdistance = RefPoint.CalculateDistance(rp1, rp2);

            Console.WriteLine(structdistance);
            Console.WriteLine(refdistance);

        }
    }


    public struct ValuePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ValuePoint(int x , int y)
        {
            X = x;
            Y = y;
        }
        
        public static double CalculateDistance(ValuePoint a, ValuePoint b)
        {
            return Math.Sqrt(Math.Pow(2, (a.X - b.X)) + Math.Pow(2, (a.Y - b.Y))); 
        }
    }

    public class  RefPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RefPoint(int x , int y)
        {
            X = x;
            Y = y;
        }

        public static double CalculateDistance(RefPoint a, RefPoint b)
        {
            return Math.Sqrt(Math.Pow(2, (a.X - b.X)) + Math.Pow(2, (a.Y - b.Y)));
        }
    }




}
