using System;
using System.Collections.Generic;
using System.Linq;


namespace Customer
{
    class CustomerTester
    {
        static void Main()
        {
            var paymentKocev = new Payment("LG G3", 1200);
            var kocev = new DiamondCustomer("Milen", "Rusev", "Kocev", "38394A", "Varna, Bulgaria", "+359 899 123001", "milenkocev@yahoo.com", CustomerType.Diamond);
            kocev.Payments.Add(paymentKocev);

            var paymentStoyanov = new Payment("Football Gloves Adidas", 300);
            var stoyanov = new GoldenCustomer("Vladislav", "Boykov", "Stoyanov", "820129ZX", "Razgrad, Bulgaria",
                "+359 2 392910", "vstoyanov@ludogoretz.bg", CustomerType.Golden, paymentStoyanov);
            var stoyanov2 = new GoldenCustomer("Vladislav", "Boykov", "Stoyanov", "820129ZX", "Razgrad, Bulgaria",
                "+359 2 392910", "vstoyanov@ludogoretz.bg", CustomerType.Golden, paymentStoyanov);
            

            Console.WriteLine(kocev);
            Console.WriteLine(stoyanov);

            var isCustomerEqual = stoyanov2.Equals(stoyanov);
            Console.WriteLine(isCustomerEqual);

            Console.WriteLine(stoyanov.GetHashCode() + "\n" + stoyanov2.GetHashCode());
            Console.WriteLine(kocev.GetHashCode() + "\n" + stoyanov.GetHashCode());

            if (stoyanov == kocev)
            {
                Console.WriteLine("The objects are equal");
            }

            if (stoyanov != kocev)
            {
                Console.WriteLine("The objects are not equal");
            }

            Console.WriteLine();
            var clonedCustomer = (Customer)kocev.Clone();
            Console.WriteLine(clonedCustomer);

            Console.WriteLine("Testing CompareTo:");

            if (kocev.CompareTo(clonedCustomer) == 0)
            {
                Console.WriteLine("The two objects are equal.");
            }
        }
    }
}