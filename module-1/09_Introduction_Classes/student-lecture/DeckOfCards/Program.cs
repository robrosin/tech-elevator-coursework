using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDemo();

            //CreateCards();

        }

        private static void CardDemo()
        {
        }

        static void CreateCards()
        {
            // 1. Create a list to hold some cards
            object cards = null;

            // Create the menu loop
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new card.");
                Console.WriteLine("2. Display all of the cards.");
                Console.WriteLine("3. Flip all of the cards face down");
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
                        AddCard(cards);
                        break;
                    case "2":
                        DisplayCards(cards);
                        break;
                    case "3":
                        FlipCards(cards);
                        break;
                    default:
                        continue;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
            }

        }


        /// <summary>
        /// Prompt the user for details, and add a card to the list
        /// </summary>
        /// <param name="cards"></param>
        private static void AddCard(object cards)
        {
            // Get the card value
            string input;
            int value = 0;
            while (value == 0)
            {
                // Get the value for the new card
                Console.Write("What is the value of the card (1-13): ");
                input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    if (value < 1 || value > 13)
                    {
                        value = 0;
                    }
                }

            }

            // Get the suit for the new card
            string suit = "";
            while (suit == "")
            {
                Console.Write("What suit does the card have: (H)earts, (D)iamonds, (C)lubs, (S)pades? ");
                input = Console.ReadLine();
                if (input.Length > 0)
                {
                    input = input.Substring(0, 1).ToUpper();
                }
                if (input == "H")
                {
                    suit = "Hearts";
                }
                else if (input == "D")
                {
                    suit = "Diamonds";
                }
                else if (input == "C")
                {
                    suit = "Clubs";
                }
                else if (input == "S")
                {
                    suit = "Spades";
                }
            }

            // Is the card face up or face down
            Console.Write("Is the card face up (Y/N): ");
            input = Console.ReadLine();
            bool isFaceUp = false;
            if (input.Length > 0 && input.ToLower().StartsWith("y"))
            {
                isFaceUp = true;
            }

            // Create the card and add to the list
        }


        /// <summary>
        /// Display all the cards in the list
        /// </summary>
        /// <param name="cards"></param>
        private static void DisplayCards(object cards)
        {
            Console.WriteLine("Displaying all of the cards.");

            // Loop through each of the cards and display values

        }


        /// <summary>
        /// Turn all the cards face-down
        /// </summary>
        /// <param name="cards"></param>
        private static void FlipCards(object cards)
        {
            Console.WriteLine($"Flipping the cards.");

            // Loop through each of the cards and flip them

        }
    }
}
