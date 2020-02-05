using States.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace States
{
    class Program
    {
        // Declare and create a dictionary to hold state codes and names
        static private StateDictionary stateCodes;
        static void Main(string[] args)
        {
            //DoFileIOStuff();
            //return;

            // The state genie looks up state codes and magically displays information!
            StateGenie();
            

            Console.WriteLine("Thanks for using our awesome program! Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void DoFileIOStuff()
        {
            // Practice some File IO methods
            string path = "AFewStates.txt";
            using (StreamReader rdr = new StreamReader(path))
            {
                string wholeFile = rdr.ReadToEnd();
                //int i = 1;
                //while (!rdr.EndOfStream)
                //{
                //    string nextLine = rdr.ReadLine();
                //    Console.WriteLine($"{i} {nextLine}");
                //    i++;
                //}
            
            }

        }

        private static void StateGenie()
        {
            LoadStateDictionary();
            while (true)
            {
                Console.Write("Please enter a state code (Q to Quit): ");
                string stateCode = Console.ReadLine().ToUpper().Trim();

                if (stateCode == "Q")
                {
                    break;
                }

                State state = LookupStateName(stateCode);

                if (state == null)
                {
                    Console.WriteLine($"Code {stateCode} was not found");
                }
                else
                {
                    Console.WriteLine($"The name of the state with code '{stateCode}' is {state.Name}. Its capital is {state.Capital}, and the its largest city is {state.LargestCity}.");
                }
            }
        }

        private static void LoadStateDictionary()
        {
            // TODO 22: Replace this hard-coded data with a call to the StateFileLoader.
            StateFileLoader loader = new StateFileLoader("States.txt");
            stateCodes = new StateDictionary(loader.StateList);
        }

        static public State LookupStateName(string stateCode)
        {
            // Lookup the given state code in the State Dictionary
            if (stateCodes.ContainsKey(stateCode))
            {
                return stateCodes[stateCode];
            }
            else
            {
                return null;
            }
        }
    }
}
