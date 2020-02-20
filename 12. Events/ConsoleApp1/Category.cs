using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Category
    {
        public event EventHandler<AnnoucementEventArgs> NewAnnoucementPost;
        
        public string Title { get; set; }

        public Category(string title)
        {
            Title = title;
        }

        public virtual void OnNewAnnoucementPost(string annoucementtitle) 
        {
            NewAnnoucementPost?.Invoke(this, new AnnoucementEventArgs(annoucementtitle, DateTime.Now));             
        }
    }
}
