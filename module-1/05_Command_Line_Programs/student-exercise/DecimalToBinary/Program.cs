using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a series of decimal values separated by spaces: ");
            string input = Console.ReadLine();

            string[] decim = input.Split(" ");
            for (int i = 0; i < decim.Length; i++)
            {
                int dec = int.Parse(decim[i]);
                Console.Write($"{dec} in binary is ");

                string binStr = "";
                while (dec > 0)
                {
                    int digit = dec % 2;
                    binStr = digit + binStr;
                    dec = dec / 2;
                }
                Console.WriteLine(binStr);
            }
        }
    }
}
