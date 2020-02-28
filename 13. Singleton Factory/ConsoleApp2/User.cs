using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp2
{
    public class User
    {
        public EventHandler<Message> MessageRecieved;
        
        public List<Message> MessageBox;
        public User(string name, dynamic phone)
        {
            Name = name;
            Phone = phone;
            MessageBox = new List<Message>();
            MessageRecieved += OnMessageRecieved;
        }

        public string Name { get; }
        public dynamic Phone { get; }

        public void RequestPostAdvert(Advert ad, BulletinBoard board)
        {
            board.PostAdvert(this, ad);
        }

        public void SendMessage(User to, string text = "Empty string")
        {
            var message = new Message(this, to, text);
            //user.MessageBox.Add(message);            
            to.MessageRecieved.Invoke(this, message);
        }

        public void OnMessageRecieved(object sender, Message message)
        {
            Console.WriteLine($"{Name} ! You recieved a new message FROM : {message.From.Name} TIME : {message.Date}");
            MessageBox.Add(message);
        }
        

    }
}
