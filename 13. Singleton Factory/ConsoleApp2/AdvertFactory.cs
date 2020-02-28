using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class AdvertFactory
    {
        public static Advert CreateCarAdvert(string title, string text, int price, DateTime? date = null)
        {            
            return new Advert(Categories.Cars, title, text, price, date);
        }
        public static Advert CreateLaptopAdvert(string title, string text, int price, DateTime? date = null)
        {
            if (price > 10000 || price < 0)
            { 
                var e = new ArgumentOutOfRangeException(nameof(price),price,"Out of range");                
                throw e;
            }
            return new Advert(Categories.Laptop, title, text, price, date);
        }        

        public static Advert CreateShoeAdvert(string title, string text, int price, DateTime? date = null)
        {
            return new Advert(Categories.Shoes, title, text, price, date);
        }
    }
}
