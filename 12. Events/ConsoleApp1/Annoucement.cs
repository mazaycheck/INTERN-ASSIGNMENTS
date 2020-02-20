using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Annoucement
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public int Price { get; set; }
        public Annoucement(Category cat, string title)
        {
            Category = cat;
            Title = title;
            Category.OnNewAnnoucementPost(Title);
        }
    }
}
