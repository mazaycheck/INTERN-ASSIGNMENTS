using System;

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

            Annoucement a1 = new Annoucement(cars, "BMW for sale") { Text = "Good condition 2.0 diesel", Price = 5000, User = vasea };
            Annoucement a2 = new Annoucement(computers, "Laptop for sale") { Text = "Apple macbook",Price = 300, User = iura };
            Annoucement a3 = new Annoucement(sneakers, "Adidas for sale") { Text = "Brand new",Price = 75, User = iura };
        }
    }
}
