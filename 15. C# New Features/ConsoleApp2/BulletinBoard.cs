using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class BulletinBoard
    {
        private static BulletinBoard Instance = null;
        private static readonly object padlock = new object();
        private BulletinBoard()
        {

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
    }
}
