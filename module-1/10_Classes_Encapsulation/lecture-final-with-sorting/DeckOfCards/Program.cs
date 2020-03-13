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
            Deck deck = new Deck();

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
                        // Create a new deck of cards
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
                    // Hidden menu items for Sorting
                    case "4":
                        deck.Sort(Deck.SortBy.ValueThenSuit);
                        break;
                    case "5":
                        deck.Sort(Deck.SortBy.ValueAceHigh);
                        break;
                    case "6":
                        deck.Sort(Deck.SortBy.SuitThenValue);
                        break;
                    case "7":
                        deck.Sort(Deck.SortBy.CardName);
                        break;
                    default:
                        continue;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
            }

        }

        private static void DealCards(Deck deck)
        {
            List<Card> hand1 = new List<Card>();
            List<Card> hand2 = new List<Card>();
            int count = 0;
            
            for (Card card = deck.DealOne(); card != null; card = deck.DealOne())
            {
                count++;
                if (count > 10)
                {
                    break;
                }

                if (count % 2 == 1)
                {
                    hand1.Add(card);
                }
                else
                {
                    hand2.Add(card);
                }
            }

            if (hand2.Count < 5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Not enough cards in the deck for two hands!");
                return;
            }

            // Print the hands

            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine("*** Player 1 Hand ***");
            Console.WriteLine("*********************");
            PrintHand(hand1);

            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine("*** Player 2 Hand ***");
            Console.WriteLine("*********************");
            PrintHand(hand2);

        }

        private static void PrintHand(List<Card> hand)
        {
            foreach(Card card in hand)
            {
                if (card.Color == "Red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(card.CardName);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
