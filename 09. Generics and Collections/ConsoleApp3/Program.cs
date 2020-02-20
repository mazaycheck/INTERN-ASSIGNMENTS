using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User("Vasea") { PhoneNumber = "029383832" };

            Category vehicles = new Category() { Title= "Vehicles" };
            Category electronics = new Category() { Title= "Electronics" };

            Subcategory cars = new Subcategory("Cars", vehicles);
            Subcategory phones = new Subcategory("Mobile phones", electronics);

            CarAnnoucement carannoucement1 = new CarAnnoucement()
            {
                Subcategory = cars,
                User = u1,
                Title = "Selling a volvo",
                Text = "Nice condition",
                Price = 5000,
                Type = CarAnnoucement.CarType.Crossover,
                Manufacturer = CarAnnoucement.CarManufacturer.Honda
            };

            PhoneAnnoucement phoneannoucement1 = new PhoneAnnoucement()
            {
                Subcategory = cars,
                User = u1,
                Title = "Selling iphone",
                Text = "Excelent condition",
                Price = 350,
                Type = PhoneAnnoucement.PhoneType.SmartPhone,
                Manuf = PhoneAnnoucement.PhoneBrand.Nokia                          
            };
            // Generic Type List
            List<Annoucement> allannoucements = new List<Annoucement> 
            { 
                carannoucement1,
                phoneannoucement1
            };
           
            Console.WriteLine("Annoucement id " + phoneannoucement1.Id);
            Console.WriteLine("Annoucement id " + carannoucement1.Id);
            //Equality Comparer
            Annoucement copy = new Annoucement() { Id = carannoucement1.Id, Title = carannoucement1.Title };
            var annoucementEqualityComparer = new AnnoucementEqualityComparer();
            Console.WriteLine(annoucementEqualityComparer.Equals(carannoucement1, phoneannoucement1));
            Console.WriteLine(annoucementEqualityComparer.Equals(carannoucement1, copy));
            
            //Dicionaries and enums
            Dictionary<CurrencyPairs, double> ExchangeRates = new Dictionary<CurrencyPairs, double>();
            ExchangeRates.Add(CurrencyPairs.MDLEUR, 19.5);
            ExchangeRates.Add(CurrencyPairs.MDLUSD, 17.5);
            ExchangeRates.Add(CurrencyPairs.MDLRUB, 0.33);
            Console.WriteLine(ExchangeRates[CurrencyPairs.MDLEUR]);
            Console.WriteLine(ExchangeRates[CurrencyPairs.MDLUSD]);
            Console.WriteLine(ExchangeRates[CurrencyPairs.MDLRUB]);
            List<int> ls = new List<int>() { 1, 2, 3, 4, 5, 6, 8 };

            //Generic Repository
            AnnoucementsRepo repo = new AnnoucementsRepo();
            repo.Insert(phoneannoucement1);
            repo.Insert(carannoucement1);
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.Title);
            }
            
            repo.Delete(phoneannoucement1.Id);
            Console.WriteLine("After delete");
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.Title);
            }
            var annouce1 = repo.GetById(carannoucement1.Id);
            annouce1.Text = "Changed text";
            repo.Update(annouce1);

            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.Text);
            }

            // Get By user
            Console.WriteLine("Get by user");
            foreach (var item in repo.GetByUserName("Vasea"))
            {
                Console.WriteLine(item);
            } 


        }
    }
}
