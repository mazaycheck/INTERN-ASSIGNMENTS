using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class MessageFactory
    {
        public static Message CreateEmptyMessage(User u1, User u2) => new Message() { From = u1, To = u2, MessageBody = "" };
        
        public static Message CreateHelloMessage(User u1, User u2) => new Message() { From = u1, To = u2, MessageBody = "Hello friend" };
        
        public static Message CreateAnonimousMessage(User u2, string message)
        {
            User anonim = new User("Anonimous", "00000000");
            Message empty = new Message() { From = anonim, To = u2, MessageBody = "Hello from anonimous" };
            return empty;
        }

    }
}
