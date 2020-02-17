using System;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Mouse m1 = new LazerMouse();
            Mouse m2 = new TrackBall();
            User Oleg = new User("Oleg");
            User Vasea = new User("Vasea");
            Oleg.BrowseInternet(m1);
            Console.WriteLine("");
            Vasea.BrowseInternet(m2);            
        }
    }

    public abstract class Mouse
    {
        public abstract void Move(int coordX, int coordY);
        public void click() { Console.WriteLine("You clicked"); }
                            
    }

    public class LazerMouse : Mouse
    {
        public override void Move(int coordX, int coordY)
        {
            Console.WriteLine($"Moving mouse to coord {coordX} and {coordY}");
        }

    }

    public class TrackBall : Mouse
    {
        public override void Move(int coordX, int coordY)
        {
            Console.WriteLine("You are moving the mouse but nothing happens, please use the scroll wheel");
        }
    }

    public class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }

        public void BrowseInternet(Mouse m)
        {
            openBrowser();
            m.Move(5, 5);
            m.click();
        }

        public void openBrowser()
        {
            Console.WriteLine("Opening favorite website");
        }

    }


}
