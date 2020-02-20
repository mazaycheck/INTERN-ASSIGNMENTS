using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int[] somenumbers = { 2, 3, 4, 5, 1, 2, 3, 4, 1, 2, 35, 6, 7, 8, 2, 32323, 1, 23, 123, 3, 1, 23 };
            int[] somenumbers2 = { 98, 65, 21, 87, 3, 1, 5, 7, 5, 4, 6, 87, 8, 6, 3, 46, 48, 32, 54, 6, 4 };
            //var r = somenumbers.SkipWhile(m => m < 35);
            var r = somenumbers.TakeWhile(m => m < 35);
            
            
            foreach (var item in r)
            {
                Console.Write(item + " ");
            }

            GroupName A1 = new GroupName("A1GR");
            GroupName A2 = new GroupName("B2GR");
            List<GroupName> groups = new List<GroupName>{ A1, A2 };


            List<User> users = new List<User>
            {
                new User {Name="Tom", Age=23, Languages = new List<string> {"engl", "ger" } , Group = A1},
                new User {Name="Bob", Age=27, Languages = new List<string> { "engl", "fra" } , Group = A2},
                new User {Name="John", Age=27, Languages = new List<string> { "engl", "spa" }, Group = A1},
                new User {Name="Alis", Age=23, Languages = new List<string> {"spa", "ger" } , Group = A2}
            };

            var userlangs = users.SelectMany(u => u.Languages, (parent, child) => new { User = parent, Lang = child });

            foreach (var item in userlangs)
            {
                Console.Write(item.User.Name + " ");
                Console.WriteLine(item.Lang);
            }

            var usergroup = users.Join(groups, u => u.Group, g => g, (u, g) => new { User= u.Name, u.Age, Group = g.Title })
                .OrderBy(m=>m.Group)
                .ThenByDescending(m => m.Age)
                .ThenBy(m=>m.User);

            foreach (var item in usergroup)
            {
                Console.WriteLine($"{item.User}  {item.Age}  :{item.Group}");
            }





            var groupbyage = users.GroupBy(m => m.Age);
            foreach (var group in groupbyage)
            {
                Console.Write("\nAgegroup : " + group.Key + "  consists of ");
                Console.WriteLine(group.Count() + " people");
                foreach (var item in group)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.WriteLine();
            }


            bool result1 = users.All(m => m.Age < 50);
            Console.WriteLine("All users under age 50 :" + result1);

            var result2 = users.SelectMany(m => m.Languages, (user, lang) => new { User = user.Name, Lang = lang }).Any(m=>m.Lang == "ger");
            var knowsgerman = users.SelectMany(m => m.Languages, (user, lang) => new { User = user.Name, Lang = lang }).FirstOrDefault(m=>m.Lang == "ger");
            
            Console.WriteLine("Does anyone know german language ? "  + result2  + $"{ knowsgerman}");

            var intrange = Enumerable.Range(1, 10);
            var repeatrange = Enumerable.Repeat("HEHE", 3);
            var listint =  intrange.ToList();
            Console.WriteLine("Intrange");
            foreach (var item in intrange) Console.WriteLine(item);
            Console.WriteLine("String repeat");
            foreach (var item in repeatrange) Console.WriteLine(item);

            var lookup = users.ToLookup(m => m.Name.Length);
            foreach (var look in lookup)
            {
                foreach (var item in look)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("***");
            }

            // Closures
            MyClosere();
 

        }

        public static void MyClosere() 
        {
            int number = 1;
            Action closure = () => Console.WriteLine(number);

            closure();

            number = 10;

            closure();
        }



        public static void Closure()
        {
            int i = 1;
            Action action = () => Console.WriteLine(i++);
            action();
        }



    }
    class User
    {
        public GroupName Group { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }

    class GroupName
    {
        public string Title { get; set; }
        public GroupName(string title)
        {
            Title = title;
        }
    }


}
