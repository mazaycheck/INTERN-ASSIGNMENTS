using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }

        private void OnAnnoucementPost(object sender, AnnoucementEventArgs e)
        {
            if(sender is Category cat) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} you have new notification!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"New Annoucement on { cat.Title} category check it out!");                
                Console.WriteLine($"Title : {e.title}  on   date : {e.date}\n");                
            }
        }

        public void SubscribeToCategory(Category cat)
        {
            cat.NewAnnoucementPost += OnAnnoucementPost;
        }

        public void UnSubscribeToCategory(Category cat)
        {
            cat.NewAnnoucementPost -= OnAnnoucementPost;
        }
    }
}
