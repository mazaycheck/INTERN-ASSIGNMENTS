using System;
using static ConsoleApp2.MessageFactory;
using static ConsoleApp2.AdvertFactory;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            $"UTC Time {DateTime.UtcNow}".Print(ConsoleColor.Green);
            $"Timezone Info {TimeZoneInfo.Local}".Print(ConsoleColor.Green);
            $"Local time : {DateTime.Now}".Print(ConsoleColor.Green);

            Console.OutputEncoding = Encoding.UTF8;
            BulletinBoard Board = BulletinBoard.GetInstance();
            BulletinBoard Board2 = BulletinBoard.GetInstance();
            $"Board is same object as Board 2 : {Board.Equals(Board2)}".Print(ConsoleColor.Cyan);
            BulletinLazyBoard Board3 = BulletinLazyBoard.Instance;
            BulletinLazyBoard Board4 = BulletinLazyBoard.Instance;
            $"Board3 is same object as Board 4 : {Board3.Equals(Board4)}".Print(ConsoleColor.Green);
            //TimeZoneInfo.Local.ToString().Print(ConsoleColor.Blue);

            User Vasea = new User(name:"Vasea", phone: "06454778");
            User Iura = new User(name:"Iura", phone: "05465487");
            User Anna = new User(name:"Anna", phone: "2125578");
            User Nina = new User(name:"Nina", phone: "3465468");

            Vasea.SendMessage(to : Iura, text: "Hello");
            Vasea.SendMessage(to : Iura);

            Advert ad1 = CreateCarAdvert("New Renault Logan", "Renault logan", 4500, DateTime.Parse("12-12-12"));
            Vasea.RequestPostAdvert(ad1, Board);
            Advert ad2 = CreateLaptopAdvert("Lenovo laptop", "Used condition, works great", 200, DateTime.Parse("Sat, 18 Aug 2018 07:22:16 GMT"));
            Iura.RequestPostAdvert(ad2, Board);
            Advert ad4 = CreateLaptopAdvert("Lenovo laptop", "Used condition, works great", 200, DateTime.Parse("19 Aug 2018 07:00:16 GMT"));
            Iura.RequestPostAdvert(ad4, Board);
            Advert ad3 = CreateLaptopAdvert("Samsung laptop", "New condition ", 300, DateTime.Parse("15 Dec 2015"));
            Anna.RequestPostAdvert(ad3, Board);

            foreach (var item in Board.AdvertList)
            {
                Console.WriteLine(item.Date);
            }
            
   
            string path = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\16.Encoding Disposal GarbageCollection\db.txt";
            FileManager.DeleteFile(path);
            FileManager.WriteToFile(text : ad1.ToString(),filename: path, encoding : Encoding.UTF8);
            //FileManager.WriteToFile(text : ad1.ToString(),filename: path, encoding : Encoding.ASCII);

            string converted = FileManager.ReadAndConvertEncoding(path, Encoding.UTF8, Encoding.Unicode);
            Console.WriteLine("\nUnicode text" + converted);
            string converted2 = FileManager.ReadAndConvertEncoding(path, Encoding.UTF8, Encoding.ASCII);
            Console.WriteLine("\nASCII text" + converted2);

            //Messages
            foreach (var item in Iura.MessageBox) Console.WriteLine(item);


            foreach (var item in Board.AdvertList)
            {
                if (item.ToString().Contains("Lenovo"))
                {
                    Console.WriteLine(item);
                }
            }
                                
        }
    }
}
