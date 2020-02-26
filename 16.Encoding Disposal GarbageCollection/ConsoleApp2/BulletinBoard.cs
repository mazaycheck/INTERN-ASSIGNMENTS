using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp2
{
    public class BulletinBoard
    {
        private static BulletinBoard Instance = null;
        private static readonly object padlock = new object();

        public List<Advert> AdvertList;
        private BulletinBoard()
        {
            AdvertList = new List<Advert>();
        }
        public static BulletinBoard GetInstance()
        {
            if(Instance == null)
            {
                lock (padlock)
                {
                    if(Instance == null)
                    {
                        Instance = new BulletinBoard();
                    }
                }
            }
            return Instance;
        }

        public bool PostAdvert(User user, Advert ad)
        {
            if (!CheckIfUserPostedMoreThanOneADay(user, ad))
            {
                ad.SetUser(user);
                AdvertList.Add(ad);                
                $"{ad.Title} Posted".Print(ConsoleColor.Yellow);
                return true;
            }
            else
            {
                $"Sorry you cannot post more than 1 Advert a day".Print(ConsoleColor.Red);
                return false;
            }

        }

        private bool CheckIfUserPostedMoreThanOneADay(User user, Advert ad)
        {
            return AdvertList.Any(x => (x.User == user && (ad.Date - x.Date) < TimeSpan.FromHours(24)));
        }
    }
}
