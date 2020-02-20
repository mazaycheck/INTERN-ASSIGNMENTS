using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AnnoucementEventArgs : EventArgs
    {
        public readonly string title;

        public readonly DateTime date;

        public AnnoucementEventArgs(string title, DateTime date)
        {
            this.title = title;
            this.date = date;
        }
    }
}
