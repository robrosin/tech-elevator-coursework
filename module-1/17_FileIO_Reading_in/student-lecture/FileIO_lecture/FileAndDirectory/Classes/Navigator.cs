using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileAndDirectory.Classes
{
    class Navigator
    {
        public void Run()
        {
            while (true)
            {
                // TODO 01: Get the current working directory dso we can display it.
                string currentPath = "????";
                Console.Clear();

                Console.WriteLine("Windows Navigator");
                Console.WriteLine("-----------------");
                Console.WriteLine($"Current Directory: {currentPath}");
                Console.WriteLine();
                Console.WriteLine("1 - Navigate Directories");
                Console.WriteLine("2 - List Files");
                Console.WriteLine("3 - Read a file");
                Console.WriteLine("Q - Quit Navigator");

                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "q":
                        return;
                    case "1":
                        NavigateDirectories();
                        break;
                    case "2":
                        ListFiles();
                        break;
                    case "3":
                        ReadFile();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void NavigateDirectories()
        {
            while (true)
            {
                Console.Clear();

                // TODO 02: Get current and root directories here...
                string currentPath = "????";
                string root = "??";
                bool hasParent = (currentPath != root);
                Console.WriteLine("Navigate Directories Submenu");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Current Directory: {currentPath}");
                Console.WriteLine();

                /// TODO 03: Get the list of dirs here...
                string[] dirs = new string[] { };

                if (hasParent)
                {
                    Console.WriteLine("0 - UP to Parent");
                }
                for (int i = 0; i < dirs.Length; i++)
                {

                    // TODO 04: Get the relative path here...
                    string relativePath = "????";
                    Console.WriteLine($"{i + 1} - {relativePath}");

                }
                Console.WriteLine("Q - Back to Navigator menu");

                string input = Console.ReadLine().Trim().ToLower();
                if (input == "q")
                {
                    break;
                }
                else if (input == "0" && hasParent)
                {
                    // TODO 05: Calculate parent folder here, and move there...



                }
                else
                {
                    // TODO 06: Navigate to the folder at [selection - 1] here....
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadLine();
                }
            }
        }

        private void ListFiles()
        {
            // List all the files in the current directory
            Console.Clear();

            // Get the current directory here...
            string currentPath = "????";
            Console.WriteLine("List Files Submenu");
            Console.WriteLine("------------------");
            Console.WriteLine($"Current Directory: {currentPath}");
            Console.WriteLine();

            // TODO 07: List all the files here....



            Console.WriteLine();
            Console.WriteLine("Press RETURN to continue");
            Console.ReadLine();
        }

        private void ReadFile()
        {
            // List the files in the current dir and allow the user to select one.
            while (true)
            {
                Console.Clear();

                // TODO 08: Get the current directory here...
                string currentPath = "????";
                Console.WriteLine("Read a File Submenu");
                Console.WriteLine("-------------------");
                Console.WriteLine($"Current Directory: {currentPath}");
                Console.WriteLine();

                // TODO 09: List all the files here....Use the code from ListFiles
                string[] files = new string[] { };
                Console.WriteLine();
                Console.Write("Select a file to Read (Q to Quit): ");

                string input = Console.ReadLine().Trim().ToLower();
                if (input == "q")
                {
                    break;
                }
                else
                {
                    //TODO 10: Check the selection and if it corresponds to an existing file, display the file on the screen.
                    int selection = 0;
                    if (int.TryParse(input, out selection) && selection > 0 && selection <= files.Length)
                    {
                        ReadFile(files[selection - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadLine();
                    }
                }
            }
        }

        private void ReadFile(string path)
        {
            int lineNumber = 1;

            // TODO 11: Open and read each line from the file
            // TODO 12: Read the file in line-by-line, call DisplayLine to show the line with line-number
            DisplayLine(lineNumber, "xxxxxxxxxxxxxxxxx");

            Console.ReadLine();
        }

        private static void DisplayLine(int lineNumber, string line)
        {
            ConsoleColor standardFore = Console.ForegroundColor;
            ConsoleColor standardBack = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write($"{lineNumber:000} ");
            Console.ForegroundColor = standardFore;
            Console.BackgroundColor = standardBack;
            Console.WriteLine(line);
        }
    }
}
