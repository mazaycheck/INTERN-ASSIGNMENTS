using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Advert
    {
        private int _price;
        public Categories Category { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }          
        public float Size { get; set; }
        public DateTime? Date { get; set; }
        public int Price
        {
            get { return _price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price must be positive!");
                _price = value;
            }
        }
        
        public User User { get; set; }

        public Advert(Categories category, string title, string text, int? price, DateTime? datetime = null)
        {
            Category = category;
            Title = title;
            Text = text ?? "";
            Price = price ?? 0;
            if (!datetime.HasValue)
                Date = DateTime.Now;
            else
                Date = datetime;
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public override string ToString()
        {
            return $"\nTitle:{Title.PadRight(10)},  \u23F0 \nDate:{Date}, \uFDFD \nUser : {User.Name}, \nPrice : {Price} ,  \nText: {Text.PadRight(20)} \u0A74  \u1FAD \u2188  \n";
        }

        
    }
}
