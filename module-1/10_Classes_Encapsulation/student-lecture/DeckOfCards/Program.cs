using System;
using System.Collections.Generic;
using DeckOfCards.Models;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default output encoding (character set) is ASCII
            // Set it to Unicode so we can display card symbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CardDeck();
        }

        static void CardDeck()
        {
            // TODO: Declare a Deck to work with 

            // Create the menu loop
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new deck of cards");
                Console.WriteLine("2. Shuffle cards");
                Console.WriteLine("3. Deal Cards");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine().ToLower();
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
                        // TODO: Create a new deck of cards
                        break;
                    case "2":
                        // TODO: Shuffle the deck
                        break;
                    case "3":
                        // TODO: Deal cards from the deck
                        break;
                    default:
                        continue;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
            }

        }
        
    }
}
