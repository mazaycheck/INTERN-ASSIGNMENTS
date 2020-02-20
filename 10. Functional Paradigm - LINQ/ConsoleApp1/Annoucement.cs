using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Annoucement
    {
        
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
}
