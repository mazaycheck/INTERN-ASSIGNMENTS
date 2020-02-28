using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp2
{
    public sealed class BulletinLazyBoard
    {
        private static readonly Lazy<BulletinLazyBoard> lazy = new Lazy<BulletinLazyBoard>(() => new BulletinLazyBoard(), true);

        public List<Advert> AdvertList;

        public static BulletinLazyBoard Instance { get { return lazy.Value; } }

        private BulletinLazyBoard()
        {
            AdvertList = new List<Advert>();
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
