using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {                    


            
            Angle angle1 = new Angle(3, 36, 1);
            Angle angle2 = new Angle(4, 27, 45);
            Angle anglesum = angle1 + angle2;
            Angle anglesub = angle1 - angle2;
            Angle anglemult = angle1 * 2;
            Angle anglediv = angle1 / 2;
            Console.WriteLine($"result sum of \t{angle1}\tand \t{angle2}is \t{anglesum}");
            Console.WriteLine($"result sub of \t{angle1}\tand \t{angle2}is \t{anglesub}");
            Console.WriteLine($"result mult of \t{angle1}\tand \t{2}\tis \t{anglemult}");
            Console.WriteLine($"result div of \t{angle1}\tand \t{2}\tis \t{anglediv}");

            Angle angle3 = new Angle(15, 27, 45);
            Angle angle4 = new Angle(23, 27, 41);
            Angle angle5 = new Angle(50, 1, 47);
            Angle angle6 = new Angle(50, 1, 45);
            Angle angle7 = new Angle(50, 1, 43);
            Angle angle8 = new Angle(3, 31, 40);
            Angle angle9 = new Angle(44, 27, 49);
            Angle angle10 = new Angle(0, 0, 49000);
            Console.WriteLine();

            List<Angle> n1 = new List<Angle>() { angle1, angle2, angle3 };

            n1[0].Degree += 700;
                
            Console.WriteLine("Sorted list");

            Angle.AngliList.Sort();

            foreach (var item in Angle.AngliList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Console.WriteLine(angle1[0]);
            //Console.WriteLine(angle1[1]);
            //Console.WriteLine(angle1[2]);

            Console.WriteLine("Yield return GetYieldProps");

            foreach (var item in angle1.GetYieldProps())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Yield return GetuEnumerator Method");

            foreach (var item in angle1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("IEnumerator");
            foreach (var prop in new AngleEnumerator(angle1))
            {
                Console.WriteLine(prop);
            }
        }

        public class Angle : IComparable
        {
            public int this[int i]
            {
                get 
                {
                    switch (i)
                    {
                        case 0: return Degree; 
                        case 1: return Minutes; 
                        case 2: return Seconds; 
                        default: throw new IndexOutOfRangeException("No such field");
                    }
                }
                set 
                {
                    switch (i)
                    {
                        case 0: Degree = value; break;
                        case 1: Minutes = value; break;
                        case 2: Seconds = value; break;
                        default: throw new IndexOutOfRangeException("No such field");
                    }
                }
            }
            public static List<Angle> AngliList { get; set; }
            protected int degree;
            protected int minutes;
            protected int seconds;
            public int Degree { 
                get { return degree; }
                set
                {
                    degree = value % 360;
                    if(degree < 0)
                    {
                        degree += 360;
                    }
                }
            }
            public int Minutes {
                get { return minutes; }
                set { if (value >= 60)                                         
                        Degree += (value / 60);                    
                    minutes = value % 60;
                    if (minutes < 0)
                    {
                        minutes += 60;
                        Degree -= 1;
                    }
                }
            }
            public int Seconds
            {
                get { return seconds; }
                set
                {
                    if (value >= 60)                    
                        Minutes += value / 60;                             
                    seconds = value % 60;
                    if (seconds < 0)
                    {
                        seconds += 60;
                        Minutes -= 1;
                    }
                }
            }


            static Angle()
            {
                AngliList = new List<Angle>();
            }

            public Angle(int deg, int min, int sec)
            {
                Degree = deg;
                Minutes = min;
                Seconds = sec;
                //AngliList.Add(this);
            }
            public override string ToString()
            {
                return $"{Degree}° {Minutes}' {Seconds}''";
            }

            public int CompareTo(object obj)
            {                
                if(obj != null)
                {
                    Angle otherobj = obj as Angle;

                    if(this.Degree.CompareTo(otherobj.Degree) == 0)
                    {
                        if (this.Minutes.CompareTo(otherobj.Minutes) == 0)
                        {
                            return this.Seconds.CompareTo(otherobj.Seconds);
                        }              
                        return this.Minutes.CompareTo(otherobj.Minutes);                        
                    }                    
                    return this.Degree.CompareTo(otherobj.Degree);                    
                }
                else
                {
                    throw new Exception("Cannot compare");
                }
            }

            public IEnumerable<int> GetYieldProps()
            {
                for (int i = 0; i < 3; i++)
                {
                    yield return this[i];
                }
            }

            public IEnumerator GetEnumerator0()
            {
                for (int i = 0; i < 3; i++)
                {
                    yield return this[i];
                }
            }
            
            public IEnumerator GetEnumerator()
            {
                return new AngleEnumerator(this);
       
            }

            public IEnumerator GetEnumerator2()
            {    
                yield return this[0];
                yield return this[1];
                yield return this[2];               
            }
            public static Angle operator + (Angle a1, Angle a2)
            {
                Angle a3 = new Angle(0,0,0);
                a3.Degree = a1.Degree + a2.Degree;
                a3.Minutes = a1.Minutes + a2.Minutes;
                a3.Seconds = a1.Seconds + a2.Seconds;
                return a3;
            }

            public static Angle operator -(Angle a1, Angle a2)
            {
                Angle a3 = new Angle(0, 0, 0);
                a3.Degree = a1.Degree - a2.Degree;
                a3.Minutes = a1.Minutes - a2.Minutes;
                a3.Seconds = a1.Seconds - a2.Seconds;
                return a3;
            }

            public static Angle operator *(Angle a1, int number)
            {
                Angle a3 = new Angle(0, 0, 0);
                a3.Degree = a1.Degree * number;
                a3.Minutes = a1.Minutes * number;
                a3.Seconds = a1.Seconds * number;
                return a3;
            }
            public static Angle operator /(Angle a1, int number )
            {
                Angle a3 = new Angle(0, 0, 0);
                a3.Degree = a1.Degree / number;                               
                a3.Minutes = a1.Minutes / number;                
                a3.Seconds = a1.Seconds / number;
                int moduleDegree = a1.Degree % number;
                int modeuleMinutes = a1.Minutes % number;
                a3.Minutes += (int)(((double)moduleDegree / number) * 60);
                a3.Seconds += (int)(((double)modeuleMinutes / number) * 60);
                return a3;
            }

            public static bool operator == (Angle a1, Angle a2)
            {             
                if (a1.Degree == a2.Degree && a1.Minutes == a2.Minutes && a1.Seconds == a2.Seconds)
                    return true;
                return false;
            }

            public static bool operator !=(Angle a1, Angle a2)
            {
                if (a1.Degree != a2.Degree || a1.Minutes != a2.Minutes || a1.Seconds != a2.Seconds)
                    return true;
                return false;
            }

            public override bool Equals(object obj)
            {
                Angle AngleObj = (Angle)obj;
                if (AngleObj.Degree == Degree && AngleObj.Minutes == Minutes && AngleObj.Seconds == Seconds)
                    return true;
                return false;
            }


            public override int GetHashCode()
            {
                return $"{Degree} : {Minutes} : {Seconds}".GetHashCode();
            }
        }
        class AngleEnumerator : IEnumerator
        {
            private Angle AngleObj { get; set; }

            public IEnumerator GetEnumerator()
            {
                return new AngleEnumerator(AngleObj);
            }
            object IEnumerator.Current => AngleObj[currentPosition];

            private int currentPosition;
            public AngleEnumerator(Angle angle)
            {
                AngleObj = angle;
                currentPosition = -1;
            }
 
            public bool MoveNext()
            {
                if(currentPosition < 2)
                {
                    ++currentPosition;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                currentPosition = -1;
            }
        }
    }
}
