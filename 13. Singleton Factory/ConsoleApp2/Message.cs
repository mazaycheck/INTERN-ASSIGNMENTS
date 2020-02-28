using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public struct Message
    {
        public Message(User from, User to, string messagebody)
        {
            From = from;
            To = to;
            MessageBody = messagebody;
            Date = DateTime.Now;
        }

        public User From { get; set; }
        public User To { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; }

        public override string ToString()
        {
            return $"\nFrom {From.Name}  \nTo {To.Name} \nMessage {MessageBody} \n{Date}\n";
        }
    }
}
