using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prompt user to enter whether length is in meters or feet

            Console.WriteLine("Is the length in (M)eters or (F)eet?");
            string lengthChoice = Console.ReadLine();

            //Prompt user to enter a temperature

            Console.WriteLine("Please enter the length as an integer:");
            string length = Console.ReadLine();
            int lengthInt = int.Parse(length);

            //Separate calculations into meters and feet
            {
                if ((lengthChoice == "M") || (lengthChoice == "m"))
                {
                    int mToF = (int)(lengthInt * 3.2808399);
                    Console.WriteLine($"{length}M is {mToF}F");
                }
                if ((lengthChoice == "F") || (lengthChoice == "f"))
                {
                    int fToM = (int)(lengthInt * 0.3048);
                    Console.WriteLine($"{length}F is {fToM}M");
                }
            }
        }
    }
}      