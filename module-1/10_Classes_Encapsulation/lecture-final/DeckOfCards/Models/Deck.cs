using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    public class Deck
    {
        // Private members

        // The internal list of cards left in the deck
        private List<Card> cards;

        // Default Constructor
        public Deck()
        {
            // Create a newly unwrapped deck of cards
            string[] suits = new string[] { "Spades", "Hearts", "Clubs", "Diamonds" };


            this.cards = new List<Card>();
            foreach (string suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, suit);
                    cards.Add(card);
                }
            }
        }

        /// <summary>
        /// Returns the top card in the deck
        /// </summary>
        /// <returns>The top card in the deck. If the deck is empty, returns NULL.</returns>
        public Card DealOne()
        {
            if (this.cards.Count == 0)
            {
                return null;
            }
            // The deck is not empty, so deal the first card
            Card result = this.cards[0];
            this.cards.RemoveAt(0);

            return result;
        }

        public void Shuffle()
        {
            // Make sure the deck has more than 1 card
            if (cards.Count <= 1)
            {
                return;
            }

            // Loop N times (don't know what N is yet)
            int loopTimes = 100;

            // Generate a random number between 1 and Count-1
            Random random = new Random();

            for (int i = 1; i <= loopTimes; i++)
            {
                int index = random.Next(1, cards.Count+1);

                // Sometimes we move the first card, sometimes we move the last
                if (i % 2 == 1)
                {
                    // Take the first card and insert it at the new index
                    cards.Insert(index, cards[0]);

                    // Remove the first card
                    cards.RemoveAt(0);
                }
                else
                {
                    // Take the first card and insert it at the new index
                    cards.Insert(index, cards[cards.Count - 1]);

                    // Remove the first card
                    cards.RemoveAt(cards.Count - 1);

                }
            }
        }

    }
}
