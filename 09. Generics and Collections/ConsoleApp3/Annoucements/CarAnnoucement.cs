using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class CarAnnoucement : Annoucement
    {
        public CarType Type { get; set; }
        public CarManufacturer Manufacturer { get; set; }
       
        public CarAnnoucement()
        {
            
        }

        public enum CarType
        {
            Hatchback,
            Sedan,
            Crossover,
            Coupe,
            Suv,
            Sportcar
        }

        public enum CarManufacturer
        {
            Wolksvagen,
            Ford,
            Mercedes,
            Bmw,
            Tesla,
            Dacia,
            Open,
            Honda,
            Hyundai,
            Volvo
        }
    }
}
