using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            User vasea = new User("Vasea");
            User andrey = new User("Andrey");
            User julia = new User("Julia");
            Category phonesCat = new Category("Phones");
            Category laptolsCat = new Category("Laptops");
            Category carsCat = new Category("Cars");

            Annoucement a1 = new Annoucement() { Author = vasea, Category = phonesCat, Title = "New iphone selling", Text = "Ok condition", Price = 200 };
            Annoucement a2 = new Annoucement() { Author = julia, Category = phonesCat, Title = "old Nokia selling", Text = "Old condition", Price = 21 };
            Annoucement a3 = new Annoucement() { Author = andrey, Category = laptolsCat, Title = "Asus laptop good", Text = "Ok condition", Price = 330 };
            Annoucement a4 = new Annoucement() { Author = vasea, Category = carsCat, Title = "Ford", Text = "Great condition", Price = 4110 };
            Annoucement a5 = new Annoucement() { Author = julia, Category = phonesCat, Title = "iphone selling", Text = "Ok condition", Price = 244 };
            Annoucement a6 = new Annoucement() { Author = vasea, Category = laptolsCat, Title = "Lenovo", Text = "Great condition", Price = 211 };
            Annoucement a7 = new Annoucement() { Author = julia, Category = phonesCat, Title = "Dell", Text = "Old condition", Price = 654 };
            Annoucement a8 = new Annoucement() { Author = vasea, Category = carsCat, Title = "Mazda 3", Text = "Great condition", Price = 2110 };
            Annoucement a9 = new Annoucement() { Author = julia, Category = phonesCat, Title = "samsung phone ", Text = "Great condition", Price = 2 };
            Annoucement a10 = new Annoucement() { Author = andrey, Category = laptolsCat, Title = "Lenovo", Text = "Old condition", Price = 78 };

            List<Annoucement> allannoucements = new List<Annoucement>() { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 };

            //Using delegates
            bool LessThen(Annoucement a, int price) { return a.Price < price; }
            var lessthenfunc = new MyFilterDelegate(LessThen);
            var filtered1 = allannoucements.Where(m => lessthenfunc(m, 400));
            //Using anonimous functions delegates
            var filtered2 = allannoucements.Where(delegate(Annoucement a) { return a.Price < 400; });
            //Using lambda funcitons
            var filtered3 = allannoucements.Where(a => a.Price < 400 );
            foreach (var item in filtered3)
            {
                Console.Write(item.Title + " ");
                Console.WriteLine(item.Price);
            }
            
            var userAnnoucements = allannoucements.GetAnnoucementsByUserName<Annoucement>("Vasea");
            ;
            Console.WriteLine("\nBy user name");
            foreach (var item in userAnnoucements.Select(m => new { Auth = m.Author, Tit = m.Title }))
            {
                Console.WriteLine(item.Tit.PadRight(20) + item.Auth.Name);
            }


        }
        public delegate bool MyFilterDelegate(Annoucement a, int x);
    }
}
