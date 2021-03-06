﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class AdvertFactory
    {
        public static Advert CreateCarAdvert(string title, string text, int price)
        {            
            return new Advert("cars", title, text, price);
        }
        public static Advert CreateLaptopAdvert(string title, string text, int price)
        {
            if (price > 10000 || price < 0) 
            { 
                var e = new ArgumentOutOfRangeException(nameof(price),price,"Out of range");                
                throw e;
            }
            return new Advert("laptop", title, text, price);
        }
    }
}
