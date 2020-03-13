using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    public class Deck
    {
        public enum SortBy
        {
            ValueThenSuit,
            ValueAceHigh,
            SuitThenValue,
            CardName
        }
        /// <summary>
        /// Represents the cards that are stored in the deck.
        /// Marked private so that outside classes can't modify its contents.
        /// </summary>
        private List<Card> cardList = new List<Card>();

        public Deck()
        {

            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };

            foreach (string suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card c = new Card(i, suit);
                    cardList.Add(c);
                }
            }
        }

        /// <summary>
        /// Removes a single card from the top of the deck.
        /// </summary>
        /// <returns>The top card. Null if the deck is empty.</returns>
        public Card DealOne()
        {
            Card result = null;

            // If there are 1 or more cards in the "Cards" list
            if (cardList.Count > 0)
            {
                // Retrieve the first "Card"/element out of the Cards list.
                result = cardList[0];

                // Removing from the card list
                cardList.Remove(result);
            }

            // Give to the class that requested the card
            return result;
        }

        /// <summary>
        /// Randomly shuffle whatever cards are left in the deck
        /// </summary>
        public void Shuffle()
        {
            // First, create a second card list hold hold the cards in a new order.
            List<Card> shuffledCards = new List<Card>();

            // The System.Random class is used for getting random numbers.
            Random random = new Random();

            // We'll be done shuffling when there are no cards left in the original list
            while (cardList.Count > 0)
            {
                // Generate a random number from 0 to the largest List index for the current list.
                int randomIndex = random.Next(cardList.Count);

                // Locate that random card in the cards list, and add it to the shuffled cards list. Then,
                // remove the card from the original cards list
                shuffledCards.Add(cardList[randomIndex]);
                cardList.RemoveAt(randomIndex);
            }

            // We have now move all the cards randomly from the original cards list to the new shuffledCards list.
            // We must now re-point the cards private field to the new shuffled list.
            cardList = shuffledCards;
        }

        /// <summary>
        /// This method deomonstrates four different ways to sort, using an IComparable 
        /// interface or a Comparison delegate method. 
        /// </summary>
        /// <param name="sortBy">SortBy enum specifying sort order</param>
        public void Sort(SortBy sortBy)
        {
            // Each sort will use a different method of sorting
            switch (sortBy)
            {
                case SortBy.ValueThenSuit:
                    // Value, then Suit is the default sort order for a Card object, using its IComparable
                    // implementation.  So we can just call the parameterless Sort method on the list.
                    cardList.Sort();
                    PrintDeck();
                    break;

                case SortBy.SuitThenValue:
                    // We need to supply a Comparison delegate which has a signature like this:
                    // public delegate int Comparison<in T>(T x, T y);
                    // We can do this in a few ways.  For this one, we defined a method with the 
                    // appropriate signature (below).  All we need to do is pass the name of that method
                    // into the sort method.  NOTE the lack of parentheses after SortBySuitComparison. This 
                    // "passes" a reference to the method into Sort, so Sort can call it when it needs to.

                    this.cardList.Sort(SortBySuitComparison);
                    PrintDeck();
                    break;

                case SortBy.ValueAceHigh:
                    // In this version, we will define the delegate method inline, right where we pass it into 
                    // sort. NOTE that this method does not have a name. It is "anonymous".
                    this.cardList.Sort(
                        // This is the inline anonymous delegate
                        delegate (Card c1, Card c2)
                        {
                            if (c1.Value == c2.Value)
                            {
                                // Values are equal, so sort by the secondary dimension, rank
                                return c1.Suit.CompareTo(c2.Suit);
                            }
                            else
                            {
                                // Sort by the primary dimension, value
                                if (c1.Value == 1) return 1;    // c1 is an ace so it wins
                                if (c2.Value == 1) return -1;   // c2 is an ace so it wins
                                return c1.Value - c2.Value;
                            }
                        }
                    );
                    PrintDeck();
                    break;

                case SortBy.CardName:
                    // In this version, we define the delegate using the convenient lambda syntax for 
                    // defining anonymous methods.
                    this.cardList.Sort(
                        (c1, c2) => (c1.ValueName+c1.Suit).CompareTo((c2.ValueName + c2.Suit))
                        );
                    PrintDeck();
                    break;
            }
        }

        /// <summary>
        /// This is used to get a peek at what's in the deck. We really should not have a CW here,
        /// but it convenient for debugging 
        /// </summary>
        private void PrintDeck()
        {
            foreach(Card card in cardList)
            {
                Console.WriteLine(card);
            }
        }

        // This method has the signature required by the Comparison delegate, so a method reference can be 
        // passed into the Sort method.
        private int SortBySuitComparison(Card c1, Card c2)
        {
            int result = c1.Suit.CompareTo(c2.Suit);
            if (result != 0)
            {
                return result;
            }

            // Equal, secondary sort on rank
            return c1.Value - c2.Value;
        }
    }
}
