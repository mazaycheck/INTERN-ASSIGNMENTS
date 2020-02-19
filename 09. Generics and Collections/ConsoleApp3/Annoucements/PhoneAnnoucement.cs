using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class PhoneAnnoucement : Annoucement
    {

        public PhoneType Type { get; set; }
        public PhoneBrand Manuf { get; set; }


        public enum PhoneType
        {
            SmartPhone,
            BudgetPhone,
            BusinessPhone,
            FashionPhone,
            OutdoorPhone
        }
        public enum PhoneBrand
        {
            Apple,
            Samsung,
            Huawei,
            Nokia,
            Xiaomi
        }
    }
}
