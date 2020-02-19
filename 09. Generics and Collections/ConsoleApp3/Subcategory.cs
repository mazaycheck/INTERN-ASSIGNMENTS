using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Subcategory
    {
        string Title { get; set; }
        public Category Category { get; set; }
        public Subcategory(string title, Category cat)
        {
            Title = title;
            Category = cat;
        }
    }
}
