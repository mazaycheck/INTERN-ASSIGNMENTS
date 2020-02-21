using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    interface IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
