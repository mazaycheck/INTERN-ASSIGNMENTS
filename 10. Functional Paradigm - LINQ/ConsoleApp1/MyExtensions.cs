using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public static class MyExtensions
    {
        public static IEnumerable<Annoucement> GetAnnoucementsByUserName<T>(this IEnumerable<Annoucement> collection, string name)
        {
            List<Annoucement> filteredbyname = new List<Annoucement>();
            foreach (var item in collection)
            {
                if(item.Author.Name == name)
                {
                    filteredbyname.Add(item);
                }
            }
            return filteredbyname;
            
        }        
    }
}
