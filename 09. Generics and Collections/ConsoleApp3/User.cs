using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class User
    {
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PhoneNumber { get; set; }
        public User(string Name)
        {
            this.Name = Name;
            RegisterDate = DateTime.Now;
        }
    }
}
