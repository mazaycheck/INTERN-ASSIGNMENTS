using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace ConsoleApp2
{
    public class BulletinBoard
    {
        private static BulletinBoard _instance;
        private static readonly object padlock = new object();
        public List<Advert> AdvertList;
        public Dictionary<IObserver,List<Categories>> Subscribers;          

        private BulletinBoard()
        {
            AdvertList = new List<Advert>();
            Subscribers = new Dictionary<IObserver, List<Categories>>();
            
        }
        public static BulletinBoard GetInstance()
        {
            if(_instance == null)
            {
                lock (padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new BulletinBoard();
                    }
                }
            }
            return _instance;
        }

        public void PostAdvert(User user, Advert ad)
        {
            if (!CheckIfUserPostedMoreThanOneADay(user, ad))
            {
                ad.SetUser(user);
                AdvertList.Add(ad);
                Console.WriteLine($"{ad.Title} Posted");
                NotifyUsers(ad.Category);

            }
            else
            {                
                MyConsole.WriteRedLine($"Sorry you cannot post more than 1 Advert a day");
            }

            

        }

        public void NotifyUsers(Categories cat)
        {
            foreach (var user in Subscribers)
            {
                if (Subscribers[user.Key].Contains(cat))
                {
                    ((IObserver)user.Key).Update(cat);
                }
            }
        }

        private bool CheckIfUserPostedMoreThanOneADay(User user, Advert ad)
        {
            return AdvertList.Any(x => (x.User == user && (ad.Date - x.Date) < TimeSpan.FromHours(24)));
        }

        public void Subscribe(IObserver user, Categories cat)
        {
            if (!Subscribers.ContainsKey(user))
            {
                Subscribers.Add(user, new List<Categories>());                
            }
            Subscribers[user].Add(cat);
        }
        public void UnSubscribe(IObserver user, Categories cat)
        {
            Subscribers[user].RemoveAll(x => x == cat);
        }

        public void PrintSubscriptionsOfUser(IObserver user)
        {                    
            foreach (var cat in Subscribers[user])
            {
                Console.WriteLine(cat);
            }            
        }

    }
}
