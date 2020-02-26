using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Advert
    {
        private int _price;
        public string Category { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }        
        public int Price
        {
            get { return _price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price must be positive!");
                _price = value;
            }
        }
        
        private User User { get; set; }

        public Advert(string category, string title, string text, int? price)
        {
            Category = category;
            Title = title;
            Text = text ?? "";
            Price = price ?? 0;
        }

        public void SetUser(User user)
        {
            User = user;
        }
    }
}
