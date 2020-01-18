using System;

namespace CommandLineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("Hello World!");
            //}
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.Write("Hello World!");
            //}

            //Console.Write("What is your name?");
            //string name = Console.ReadLine();

            //Console.Write($"Hello {name}. How old are you?");
            //string input = Console.ReadLine();
            //int age = int.Parse(input);

            //Console.WriteLine($"Wow, {name}, {age}? That's really old!");


            //string sentence = "Now is the time for all good people to come to the aid of their country";
            //string[] words = sentence.Split(" ");

            //for (int i = 0; i < words.Length; i++)
            //{
            //    Console.WriteLine(words[i]);
            //}

            //sentence = string.Join(" : ", words);

            //Console.WriteLine(sentence);

            GetNumbersFromUser();

        }

        static public void GetNumbersFromUser()
        {
            // Loop if user wants to run program again

            while (true)
            {
                Console.Clear();

                // Greet the user and ask for a comma-delimited list of integers

                Console.Write("Please enter a list of comma-delimited integers. Please be careful!");
                string input = Console.ReadLine();

                // Split the string into individual "number-strings"

                string[] numberStrings = input.Split(",");

                // Parse each number-string into an integer and place into a new array

                int[] nums = new int[numberStrings.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = int.Parse(numberStrings[i]);
                }

                // Iterate numbers to get sum

                int sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                }

                // Display the count, sum and average to the user

                Console.WriteLine($"Here are your answers:\r\n  Count: {nums.Length}\r\n  Sum: {sum}\r\n  Average: {(double)sum / nums.Length}");

                // Ask user if they want to do it again and get answer

                Console.WriteLine("Do you want to do another? (y/n)");
                input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
            }
        }
    }
}

