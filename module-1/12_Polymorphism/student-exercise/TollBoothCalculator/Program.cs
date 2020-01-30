using System;
using System.Collections.Generic;

namespace TollBoothCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            Car vehicle1 = new Car(true);
            Car vehicle2 = new Car(false);
            Truck vehicle3 = new Truck(4);
            Truck vehicle4 = new Truck(6);
            Truck vehicle5 = new Truck(8);
            Tank vehicle6 = new Tank();

            vehicles.Add(vehicle1);
            vehicles.Add(vehicle2);
            vehicles.Add(vehicle3);
            vehicles.Add(vehicle4);
            vehicles.Add(vehicle5);
            vehicles.Add(vehicle6);

            Random random = new Random();
            int totalDistance = 0;
            double totalTolls = 0;
            Console.WriteLine("=================================================");
            Console.WriteLine("Vehicle Type    || Distance Traveled    || Tolls Collected");


            foreach (IVehicle vehicle in vehicles)
            {
                int distance = random.Next(10, 240);
                totalDistance += distance;
                double tollsOwed = vehicle.CalculateToll(distance);
                totalTolls += tollsOwed;

                Console.WriteLine($"{vehicle.Name,-10 } {totalDistance, 10}\t {totalTolls,10:C}");
            }
            Console.WriteLine("Total Distance \t\t || Total Tolls ");
            Console.WriteLine($"{totalDistance,-30} {totalTolls,10:C}");
            Console.WriteLine("=================================================");
        }
    }
}