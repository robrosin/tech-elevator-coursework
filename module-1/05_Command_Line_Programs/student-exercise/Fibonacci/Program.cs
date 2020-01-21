using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prompt user for fibonacci number

            Console.WriteLine("Please enter the Fibonacci number: ");

            //Read input

            string input = Console.ReadLine();

            //Convert to integer

            int limit = int.Parse(input);

            //Calculate fibonacci series up to input

            int prevNum = 0;
            int currentNum = 1;

            Console.WriteLine(prevNum);

            while (currentNum <= limit)
            {
                Console.WriteLine($", {currentNum}");
                int newValue = prevNum + currentNum;
                prevNum = currentNum;
                currentNum = newValue;
            }
        }
    }
}