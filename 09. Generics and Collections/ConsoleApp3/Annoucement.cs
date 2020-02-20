using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp3
{
    class Annoucement : IEntity<int> , IComparer<Annoucement>
    {
        public static int AutoId;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Datetime;
 
        public Subcategory Subcategory { get; set; }
        //public T Options { get; set; }
        public User User { get; set; }
        public int? Price { get; set; }
        

        public Annoucement()
        {
            Datetime = DateTime.Now;
            AutoId++;
            Id = AutoId;
        }
        static Annoucement()
        {
            AutoId = 0;
        }

        public override string ToString()
        {
            return $"title:{Title} user:{User.Name} date:{Datetime}";
        }
        public int Compare([AllowNull] Annoucement x, [AllowNull] Annoucement y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
