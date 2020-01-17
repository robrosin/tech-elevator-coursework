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
            //Console.WriteLine();
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.Write("Hello World!");
            //}

            //Console.Write("What is your name? ");
            //string name = Console.ReadLine();

            //Console.Write($"Hello, {name}. How old are you? ");
            //string input = Console.ReadLine();
            //int age = int.Parse(input);

            //Console.WriteLine($"Wow {name}, {age}?  That's really old!");

            //string sentence = "Now is the time for all good people to come to the aid of their country";
            //string[] words = sentence.Split(" ");


            //for (int i = 0; i < words.Length; i++)
            //{
            //    Console.Write(words[i]);
            //}
            //Console.WriteLine();
            //sentence = string.Join(" : ", words);

            //Console.WriteLine(sentence);

            //GetNumbersFromUser();

            ProperNouner();
        }

        //static public void GetNumbersFromUser()
        //{
        //    // Greet the user and ask for a comma-delimited list of integers
        //    Console.Write("Please enter a list of comma-delimited numbers.  Please be careful!");
        //    string input = Console.ReadLine();

        //    // Split the string into individual "number-strings"
        //    string[] numberStrings = input.Split(",");

        //    // Parse each number-string into an integer and place into a new array
        //    int[] nums = new int[numberStrings.Length];
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        nums[i] = int.Parse(numberStrings[i]);
        //    }

        //    // iterate numbers to get sum
        //    int sum = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        sum += nums[i];

        //    }

        //    // Display the count, sum and average to the user
        //    Console.WriteLine($"Here are your answers:\r\n  Count: {nums.Length}\r\n  Sum: {sum}\r\n  Average: {(double)sum / nums.Length}");

        //}


        static public void ProperNouner()
        {
            while (true)
            {
                string input;

                // Prompt the user for a sentence
                Console.Write("Enter a sentence: ");
                input = Console.ReadLine();

                // Split into words using space character
                string[] words = input.Split(" ");

                // Loop through the words...
                for (int i = 0; i < words.Length; i++)
                {
                    // Capitalize the first letter and lower the rest
                    string word = words[i];
                    word = word.ToLower();

                    // upper case the first letter and concat the rest of the word
                    word = word[0].ToString().ToUpper() + word.Substring(1);

                    // Replace the word in the array
                    words[i] = word;
                }

                // Join the updated array into a new sentence
                string sentence = string.Join(" ", words);

                // Display the Proper-nouned sentence to the user.
                Console.WriteLine(sentence);



                Console.Write("Do you want to do another? (y/n)");
                input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
            }
        }

        static public void GetNumbersFromUser()
        {
            while (true)
            {
                Console.Clear();
                // Greet the user and ask for a comma-delimited list of integers
                Console.Write("Please enter a list of comma-delimited numbers.  Please be careful!");
                string input = Console.ReadLine();

                // Split the string into individual "number-strings"
                string[] numberStrings = input.Split(",");

                // Parse each number-string into an integer and place into a new array
                int sum = 0;
                for (int i = 0; i < numberStrings.Length; i++)
                {
                    int num = int.Parse(numberStrings[i]);
                    sum += num;
                }

                // Display the count, sum and average to the user
                Console.WriteLine($"Here are your answers:\r\n  Count: {numberStrings.Length}\r\n  Sum: {sum}\r\n  Average: {(double)sum / numberStrings.Length}");

                Console.Write("Do you want to do another? (y/n)");
                input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
            }

        }
    }
}
