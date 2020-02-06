using System;
using System.IO;

namespace file_io_part1_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is fully qualified name of the file that should be searched?");
            string filePath = Console.ReadLine().Trim().Replace("\"", "");

            Console.WriteLine("What is the search word you are looking for?");
            string searchTerm = Console.ReadLine();

            Console.WriteLine("Is the search term case sensitive? Y/N");
            string caseSensitive = Console.ReadLine().Trim();

            using (StreamReader sw = new StreamReader(filePath))
            {
                int lineCounter = 0;

                while (!sw.EndOfStream)
                {
                    string oneLine = sw.ReadLine();
                    string[] singleWord = oneLine.Trim().Split("\n");
                    if (caseSensitive.ToUpper() == "Y")
                    {
                        for (int i = 0; i < singleWord.Length; i++)
                        {
                            if (singleWord[i] != " ")
                            {
                                lineCounter++;
                                if (singleWord[i].Contains(char.ToUpper(searchTerm[0]) + searchTerm.Substring(1)))
                                {
                                    Console.WriteLine($"{lineCounter}) {oneLine}");
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < singleWord.Length; i++)
                        {
                            if (singleWord[i] != " ")
                            {
                                lineCounter++;
                                if (singleWord[i].Contains(searchTerm))
                                {
                                    Console.WriteLine($"{lineCounter}) {oneLine}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
