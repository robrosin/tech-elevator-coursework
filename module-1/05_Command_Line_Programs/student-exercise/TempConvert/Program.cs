using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prompt user to enter whether temp is in celcius or fahrenheit
            //Use tempChoice.ToLower to make input lower case

            Console.WriteLine("Is the temperature in (C)elcius or (F)ahrenheit?");
            string tempChoice = Console.ReadLine();

            //Prompt user to enter a temperature

            Console.WriteLine("Please enter the temperature as an integer:");
            string temp = Console.ReadLine();
            int tempInt = int.Parse(temp);

            //Separate calculations into C and F
            {
                //If temperature is f, convert fahrenheit to celcius
                if (tempChoice == "F" || tempChoice == "f")
                {
                    int fToC = (int)((tempInt - 32) / 1.8);
                    Console.WriteLine($"{tempInt}F is {fToC}C");
                }
                if (tempChoice == "C" || tempChoice == "c")
                {
                    int cToF = (int)((tempInt * 1.8) + 32);
                    Console.WriteLine($"{tempInt}C is {cToF}F");
                }

            }
        }
    }
}

