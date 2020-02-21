using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            User vasea = new User("Vasea");
            User iura = new User("Iura");

            Category cars = new Category("Cars");
            Category computers = new Category("Computers");
            Category sneakers = new Category("Sneakers");

            vasea.SubscribeToCategory(cars);
            iura.SubscribeToCategory(computers);
            iura.SubscribeToCategory(cars);

            vasea.PostNewAnnoucement(new Annoucement(cars, "BMW for sale") { Text = "Good condition 2.0 diesel", Price = 5000 });
            iura.PostNewAnnoucement(new Annoucement(computers, "Laptop for sale") { Text = "Apple macbook", Price = 300 });
            iura.PostNewAnnoucement(new Annoucement(sneakers, "Adidas for sale") { Text = "Brand new", Price = 75 });

            //foreach (var item in iura.GetListOfUserAnnoucements()) Console.WriteLine($"{item.Title} : {item.Price}");

        }
    }
}
