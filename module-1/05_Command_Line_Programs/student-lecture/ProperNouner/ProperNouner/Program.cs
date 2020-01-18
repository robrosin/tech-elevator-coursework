using System;

namespace ProperNouner
{
    class Program
    {
        static void ProperNouner()
            {

                while (true)
                {
                    string input;

                    // Prompt the user for a sentence

                    Console.WriteLine("Enter a sentence: ");
                    input = Console.ReadLine();

                    // Split into words using space counter

                    string[] words = input.Split(" ");

                    // Loop through the words...

                    for (int i = 0; i < words.Length; i++)
                    {
                        // Capitalize the first letter and lower the rest

                        string word = words[i];
                        word = word.ToLower();

                        // Upper case first letter and concatenate the rest of the word
                        word = word[0].ToString().ToUpper() + word.Substring(1);

                        // Replace the word in the array
                        words[i] = word;
                    }

                    // Join the updated array into a new sentence

                    string sentence = string.Join(" ", words);

                    // Display the Proper-nouned sentence to the user
                    Console.WriteLine(sentence);

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
