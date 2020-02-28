using System;

using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            BulletinBoard Board = BulletinBoard.GetInstance();

            User Vasea = new User(name:"Vasea", phone: "06454778");
            User Iura = new User(name:"Iura", phone: "05465487");
            User Anna = new User(name:"Anna", phone: "2125578");
            User Nina = new User(name:"Nina", phone: "3465468");

            Vasea.SendMessage(to : Iura, text: "Hello!");
            Iura.SendMessage(to : Vasea, text: "Whats up?");

            Board.Subscribe(Vasea, Categories.Cars);
            Board.Subscribe(Vasea, Categories.Laptop);

            Board.PrintSubscriptionsOfUser(Vasea);

            Advert ad1 = new Advert(Categories.Cars, "BMW", "good car", 5000);
            Iura.RequestPostAdvert(ad1, Board);            
            Advert ad2 = new Advert(Categories.Laptop, "Lenovo", "good condition", 300);
            Vasea.RequestPostAdvert(ad2, Board);            
        }
    }
}
