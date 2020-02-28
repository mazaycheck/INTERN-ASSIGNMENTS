using System;
using static ConsoleApp2.MessageFactory;
using static ConsoleApp2.AdvertFactory;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            BulletinBoard Board = BulletinBoard.GetInstance();
            //dynamic adfsdfsafsadf = "";
            //adfsdfsafsadf.PRIVETVASEA();
            User Vasea = new User(name:"Vasea", phone: "06454778");
            User Iura = new User(name:"Iura", phone: 564879878);
            User Anna = new User(name:"Anna", phone: false);
            User Nina = new User(name:"Nina", phone: 234234.12);

            string VaseaNum = Vasea.Phone;
            int IuraNum = Iura.Phone;
            bool AnnaNum = Anna.Phone;
            double NinaNum = Nina.Phone;

            Vasea.SendMessage(to : Iura, text: "Hello");
            Vasea.SendMessage(to : Iura);

            try
            {
                Vasea.PostAdvert(CreateCarAdvert("New Renault Logan", "Renault logan", 4500));
                Iura.PostAdvert(CreateLaptopAdvert("Lenovo laptop", "Used condition, works great", 200000));
                Anna.PostAdvert(CreateLaptopAdvert("Samsung laptop", "New condition ", -200));

            }
            catch (ArgumentOutOfRangeException e) when ((int)e.ActualValue > 100000)
            {
                
                Console.WriteLine("Price is too high, did you make a mistake?");
            }
            catch (ArgumentOutOfRangeException e) when ((int)e.ActualValue < 0)
            {
                Console.WriteLine("Price must be positive!");
            }

            foreach (var item in Iura.MessageBox) Console.WriteLine(item);                                
        }
    }
}
