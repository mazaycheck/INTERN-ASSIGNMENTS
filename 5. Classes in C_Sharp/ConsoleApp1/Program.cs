using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BakingFactory FranzeutaFactory = new BakingFactory("Franze213123123213213luta", empl: 500, bal: 1000000, avg: 200);
            CarpetFactory FloareCarpet = new CarpetFactory("Floarea Carpet", empl: 200, bal: 2000000, avg: 250);

            ProductType bread =  FranzeutaFactory.MakeProduct();
            ProductType carpet =  FloareCarpet.MakeProduct();
       

            FranzeutaFactory.SellProduct(bread);
            FloareCarpet.SellProduct(carpet);
     
            FranzeutaFactory.GiveOutSalary();
            FloareCarpet.GiveOutSalary(bonus: 300);

            Console.WriteLine($"{FranzeutaFactory.Title} Balance : {FranzeutaFactory.Balance}");
            Console.WriteLine($"{FloareCarpet.Title} Balance : {FloareCarpet.Balance}");
        }

        public enum ProductType
        {
            Bread = 50,
            Beer = 60,
            Carpet = 70
        }

        public interface IFactory
        {
            ProductType MakeProduct();
        }

        abstract class Factory : IFactory
        {
            protected ProductType ProductType { get; set; }

            protected string title;
            public string Title { get { return title; } protected set { if (value.Length < 15) title = value; else title = "DefaultFactoryName"; } }            
            public int Employees { get; protected set; }
            protected int AvgSalary { get; set; }
            protected List<string> PrimaryProducts { get; set; }
            public int Balance { get; protected set; }
            
            public Factory(string name, int empl, int bal, int avg)
            {
                AvgSalary = avg;
                Balance = bal;
                Title = name;
                Employees = empl;
                PrimaryProducts = new List<string>();
                
            }

            public virtual ProductType MakeProduct()
            {
                Console.WriteLine($"Started a production of {ProductType} at {Title}");
                GetPrimaryProducts();
                LoadPrimaryForProduction();
                Console.WriteLine($"Finished Making a {ProductType}");
                Console.WriteLine();
                return ProductType;
            }
      
            protected abstract void GetPrimaryProducts();
            protected void LoadPrimaryForProduction()
            {
                foreach (var item in PrimaryProducts)
                {
                    Console.WriteLine($"\tUsing {item} for production");
                }
                PrimaryProducts.Clear();
            }


            

            public void GiveOutSalary()
            {
                Balance -= (Employees * AvgSalary);
            }

            public void GiveOutSalary(int bonus)
            {
                Balance -= (Employees * (AvgSalary + bonus));
            }         
            

            public void SellProduct(ProductType pr)
            {
                Balance += (int)pr;
            }

        }


        class BakingFactory : Factory
        {           
            public BakingFactory(string name, int empl, int bal, int avg) : base(name, empl, bal, avg)
            {
                ProductType = ProductType.Bread;
            }
            protected override void GetPrimaryProducts()
            {
                string[] supply = new string[]{ "millet", "water", "yeast"};
                PrimaryProducts.AddRange(supply);
            }   
        }
        
        class CarpetFactory : Factory
        {
            public CarpetFactory(string name, int empl, int bal, int avg) : base(name, empl, bal, avg)
            {
                ProductType = ProductType.Carpet;
            }

            protected override void GetPrimaryProducts()
            {
                string[] supply = new string[] { "threads", "paint" };
                PrimaryProducts.AddRange(supply);
            }
        }
    }
}
