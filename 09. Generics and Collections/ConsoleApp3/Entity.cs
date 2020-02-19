using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    interface IEntity<U>
    {
        public U Id { get; set; }
    }
}
