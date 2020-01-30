using System;
using System.Collections.Generic;


namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the weight of the package?");
            string weight = Console.ReadLine();
            double weight2 = Convert.ToDouble(weight);

            Console.WriteLine("(P)ounds or (O)unces?");
            string poundsOrOunces = Console.ReadLine();
            string poundsOrOunces2 = poundsOrOunces.ToUpper();
            if (poundsOrOunces2 == "P")
            {
                weight2 = (weight2 * 16);
            }

            Console.WriteLine("What distance will it be traveling?");
            string distance = Console.ReadLine();
            int distance2 = Convert.ToInt32(distance);

            List<IDeliveryDriver> drivers = new List<IDeliveryDriver>();

            FexEd driver1 = new FexEd();
            PostalService1 driver2 = new PostalService1();
            PostalService2 driver3 = new PostalService2();
            PostalService3 driver4 = new PostalService3();
            SPU1Day driver5 = new SPU1Day();
            SPU2Day driver6 = new SPU2Day();
            SPU4Day driver7 = new SPU4Day();

            drivers.Add(driver1);
            drivers.Add(driver2);
            drivers.Add(driver3);
            drivers.Add(driver4);
            drivers.Add(driver5);
            drivers.Add(driver6);
            drivers.Add(driver7);

            Console.WriteLine("Delivery Method\t\t $ cost");
            Console.WriteLine("-------------------------------");

            double charges = 0.0;

            foreach (IDeliveryDriver driver in drivers)
            {
                charges = driver.CalculateRate(distance2, weight2);


                Console.WriteLine($"{driver.Name, -10}  {charges:C}");
            }




            //if weight is in pounds, multiply by 16
        }
    }
}