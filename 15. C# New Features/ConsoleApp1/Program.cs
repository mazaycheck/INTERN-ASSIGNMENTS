using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Person p1 = new Person("Vasea", 30);
            Console.WriteLine(MyMethod(p1));
            MyNamedParams(10, b : 4, v : "asd");


            Person p2 = new Person(name: "petia", age: 20);
            Person anna = new Student("Anna", 23, school:"School#123");
            Console.WriteLine("Anna school "+((Student)anna).School);


            // Error for read-only fields
            //Person p3 = new Person { Name = "Kolea" , Age = 18 };


            //dynamic
            dynamic d1 = 100;            
            d1 = true;
            d1 = "hehe";
            string s1 = d1;
            //object
            object o1 = 100;            
            o1 = false;
            o1 = "some string";

            // Objects must be implicitly converted!
            string s2 = (string)o1;
            var letters = (Alpha : "a", Beta : "b");

            //Named tuples
            (int Omega, int  Zeta) = (4,1);
            Console.WriteLine( letters.Alpha);
        }


        public static dynamic MyMethod(Person p = null)
        {
            Person person = p ?? new Person("Jora", 33);
          
            switch (person.Age)
            {
                case 30: return "Hello 30";
                default: return person.Age;                    
            }            
        }
        public class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; }
            public int Age { get; }
        }

        public class Student : Person
        {
            public string School { get; }
            public Student(string name, int age, string school) : base(name, age)
            {
                School = school;
            }
            
        }

        public static void MyNamedParams(int aasd, int b, string v)
        {
            Console.WriteLine(nameof(aasd));
        }
    }
}
