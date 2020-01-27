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
            // Declare a Deck to work with 
            Deck deck = new Deck();

            //// TEMPORARY: See if the constructor and DealOne work
            //for (int i = 1; i <= 10; i++)
            //{
            //    Card card = deck.DealOne();
            //    Console.WriteLine(card.CardName);

            //}

            //Console.ReadLine();

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
                        deck = new Deck();
                        break;
                    case "2":
                        // Shuffle the deck
                        deck.Shuffle();
                        break;
                    case "3":
                        // Deal cards from the deck
                        DealCards(deck);
                        break;
                    default:
                        continue;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
            }

        }

        static private void DealCards(Deck deck)
        {
            // Deal two hands of five cards each
            List<Card> hand1 = new List<Card>();
            List<Card> hand2 = new List<Card>();

            for (int i = 1; i <= 10; i++)
            {
                Card card = deck.DealOne();
                if (card == null)
                {
                    Console.WriteLine("Not enough cards in the deck!");
                    return;
                }

                if (i % 2 == 1)
                {
                    hand1.Add(card);
                }
                else
                {
                    hand2.Add(card);
                }
            }

            // Print the hands

            Console.WriteLine();
            Console.WriteLine("**************");
            Console.WriteLine("** Player 1 **");
            Console.WriteLine("**************");
            foreach (Card card in hand1)
            {
                Console.WriteLine(card.CardName);
            }

            Console.WriteLine();
            Console.WriteLine("**************");
            Console.WriteLine("** Player 2 **");
            Console.WriteLine("**************");
            foreach (Card card in hand2)
            {
                Console.WriteLine(card.CardName);
            }

        }

    }
}
