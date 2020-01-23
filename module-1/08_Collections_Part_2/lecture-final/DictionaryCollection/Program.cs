using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DictionaryDemo();

            //HashSetDemo();

            // Build a name / height database and search it
            RunHeightDatabase();
            //Console.ReadLine();
        }

        static void DictionaryDemo()
        {
            // Demonstrate creating and searching a dictionary
            SortedDictionary<string, string> states = new SortedDictionary<string, string>()
            {
                {"AK", "Alaska" },
                {"AL", "Alabama"},
                {"", "*** unknown ***" },
                {"AZ", "Arizona"},
                {"CO", "Colorado"},
                {"AR", "Arkansas" },
                {"CA", "California"},
                {"PA", "Pennsylvania" }
            };

            // Does the dict contain AZ?
            bool exists = states.ContainsKey("AZ");
            Console.WriteLine($"ContainsKey(AZ): {exists} ");

            // Does the dictionary  contain "OH"?
            exists = states.ContainsKey("OH");
            if (!exists)
            {
                states.Add("OH", "ohio");
            }
            Console.WriteLine($"The value at OH is {states["OH"]} ");

            // Correct the capitalization
            states["OH"] = "Ohio";
            Console.WriteLine($"The value at OH is {states["OH"]} ");

            // Print the codes and states
            foreach (KeyValuePair<string, string> entry in states)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }


            // Print a list sorted by state code (key)
            Console.WriteLine("Sorted by state code");
            List<string> codes = new List<string>(states.Keys);
            codes.Sort();
            foreach (string code in codes)
            {
                Console.WriteLine($"{code} : {states[code]}");
            }

        }

        static void HashSetDemo()
        {
            // Demonstrate a few HashSet methods
            HashSet<string> hs1 = new HashSet<string>() { "A", "B", "C" };
            HashSet<string> hs2 = new HashSet<string>() { "F", "E", "D", "C" };
            HashSet<string> hs3 = new HashSet<string>() { "F", "A", "X", "Y", "Z" };

            Console.WriteLine("HashSet 2:");
            foreach (string s in hs2)
            {
                Console.WriteLine(s);
            }

            hs1.UnionWith(hs2);
            Console.WriteLine(string.Join(",", hs1));
            Console.WriteLine(string.Join(",", hs2));

            hs1.IntersectWith(hs3);
            Console.WriteLine(string.Join(",", hs1));


        }
        static void RunHeightDatabase()
        {
            // Display a greeting and menu

            //// 1. Let's create a new Dictionary that could hold string, ints
            ////      | "Josh"    | 70 |
            ////      | "Bob"     | 72 |
            ////      | "John"    | 75 |
            ////      | "Jack"    | 73 |
            Dictionary<string, int> heightDB = new Dictionary<string, int>()
            {
                {"AMY", 62 },
                {"KARINA", 67 },
                {"JAKE", 73 },
                {"DAN", 71 },
                {"RICHARD", 74 },
                {"JOAN", 68 },
            };

            string input;
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine(@"     _       _        _                    ");
                Console.WriteLine(@"    | |     | |      | |                   ");
                Console.WriteLine(@"  __| | __ _| |_ __ _| |__   __ _ ___  ___ ");
                Console.WriteLine(@" / _` |/ _` | __/ _` | '_ \ / _` / __|/ _ \");
                Console.WriteLine(@"| (_| | (_| | || (_| | |_) | (_| \__ \  __/");
                Console.WriteLine(@" \__,_|\__,_|\__\__,_|_.__/ \__,_|___/\___|");
                Console.WriteLine(@"                                           ");
                Console.WriteLine("1) Add / update data");
                Console.WriteLine("2) Search the database");
                Console.WriteLine("3) Print the database");
                Console.WriteLine("4) Get Average Height");
                Console.WriteLine("Q) Quit");
                Console.WriteLine("");
                Console.Write("Please enter selection: ");
                input = Console.ReadLine().ToLower();
                if (input.Length > 0)
                {
                    input = input.Substring(0, 1);
                }

                switch (input)
                {
                    case "q":
                        keepGoing = false;
                        continue;
                    case "1":
                        AddEditDB(heightDB);
                        break;
                    case "2":
                        SearchDB(heightDB);
                        break;
                    case "3":
                        PrintDB(heightDB);
                        break;
                    case "4":
                        ShowAverageHeight(heightDB);
                        break;
                    default:
                        continue;
                }

                //if (input == "q")
                //{
                //    break;
                //}
                //else if (input == "1")
                //{
                //    AddEditDB(heightDB);
                //}
                //else if (input == "2")
                //{
                //    SearchDB(heightDB);
                //}
                //else if (input == "3")
                //{
                //    PrintDB(heightDB);
                //}
                //else if (input == "4")
                //{
                //    ShowAverageHeight(heightDB);
                //}
                //else
                //{
                //    continue;
                //}
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

            }

            Console.WriteLine();
            Console.WriteLine("Done...");


        }

        public static void ShowAverageHeight(Dictionary<string, int> heightDB)
        {
            //7. Let's get the average height of the people in the dictionary
            int sum = 0;

            foreach(int height in heightDB.Values)
            {
                sum += height;
            }

            Console.WriteLine($"The average height in the class is {  Math.Round(sum / (double)heightDB.Count, 2)} inches.");
        }

        public static void PrintDB(Dictionary<string, int> heightDB)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
            Console.WriteLine("Printing...");

            foreach(var kvp in heightDB)
            {
                Console.WriteLine($"{kvp.Key,-10} {kvp.Value} inches");
            }
        }

        public static void AddEditDB(Dictionary<string, int> db)
        {
            Console.Write("What is the person's name?: ");
            string name = Console.ReadLine().ToUpper().Trim();

            Console.Write("What is the person's height (in inches)?: ");
            int height = int.Parse(Console.ReadLine());

            // 2. Check to see if that name is in the dictionary
            //      bool exists = dictionaryVariable.ContainsKey(key)
            bool exists = db.ContainsKey(name);

            if (!exists)
            {
                Console.WriteLine($"Adding {name} with new value.");
                // 3. Put the name and height into the dictionary
                //      dictionaryVariable[key] = value;
                //      OR dictionaryVariable.Add(key, value);
                db.Add(name, height);

            }
            else  // Name DOES exist
            {
                Console.WriteLine($"Overwriting {name} with new value.");
                // 4. Overwrite the current key with a new value
                //      dictionaryVariable[key] = value;
                db[name] = height;
            }
        }
        public static void SearchDB(Dictionary<string, int> db)
        {
            Console.Write("Which name are you looking for? ");
            string input = Console.ReadLine().ToUpper().Trim();

            //5. Let's get a specific name from the dictionary
            if (db.ContainsKey(input))
            {
                Console.WriteLine($"{input} is in the database, and is {db[input]} inches tall");
            }
            else  // "input" is NOT in the DB
            {
                Console.WriteLine($"{input} was not found in the db!");
            }


        }
    }
}
