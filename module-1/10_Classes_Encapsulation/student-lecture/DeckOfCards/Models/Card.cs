using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    /// <summary>
    /// Represents a single playing card
    /// </summary>
    public class Card
    {
        #region Private variables
        // NOTE: I added this table to allow us to show suit symbols on the Console
        // TODO: Make the dictionary of values suit symbols static so that only one copy is ever create
        private Dictionary<string, char> suitSymbols = new Dictionary<string, char>()
        {
            {"Spades", '\u2660'},
            {"Diamonds", '\u2666'},
            {"Clubs", '\u2663'},
            {"Hearts", '\u2665'}
        };

        // TODO: Make the dictionary of values static so that only one copy is ever create
        private Dictionary<int, string> valueNames = new Dictionary<int, string>()
        {
            {1, "Ace" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" },
        };



        #endregion

        #region Properties

        // TODO: Make the Suit Property read-only, so that it can ONLY be set in the constructor

        /// <summary>
        /// "Spades", "Clubs", "Hearts" or "Diamonds"
        /// </summary>
        public string Suit { get; set; }

        // TODO: Make the Value of the card read-only, so that it can ONLY be set in the constructor
        /// <summary>
        /// Rank of the card 1 = Ace, 13 = King
        /// </summary>
        public int Value { get; set; }

        public string ValueName
        {
            get 
            {
                if (valueNames.ContainsKey(this.Value))
                {
                    return valueNames[this.Value];
                }
                return "??????";
            }
        }

        // TODO: Add a Property for Suit Symbol
        /// <summary>
        /// Derived property to get the symbol for the suit.
        /// </summary>
        public char Symbol
        {
            get
            {
                return suitSymbols[Suit];
            }
        }

        public string CardName
        {
            get
            {
                // TODO: Add the Symbol to the card name
                return $"{this.ValueName} of {this.Suit}";
            }
        }

        /// <summary>
        /// "Black" or "Red"
        /// </summary>
        public string Color
        {
            get
            {
                if (this.Suit == "Spades" || this.Suit == "Clubs")
                {
                    return "Black";
                }
                return "Red";
            }
        }

        /// <summary>
        /// True if the face of the card is showing
        /// </summary>
        public bool IsFaceUp { get; private set; }


        #endregion

        #region Methods
        /// <summary>
        /// Flip the card over.
        /// </summary>
        public void Flip()
        {
            this.IsFaceUp = !this.IsFaceUp;
        }

        #endregion

        #region Constructors

        // TODO: add a isFaceUp argument and default it to false
        public Card(int value, string suit)
        {
            if (value < 1 || value > 13)
            {
                throw new Exception("Value of a card must be 1 - 13");
            }
            this.Value = value;

            if (suit == "Hearts" || suit == "Diamonds" || suit == "Clubs" || suit == "Spades")
            {
                this.Suit = suit;
            }
            else
            {
                throw new Exception("Suit of a card must be Hearts, Diamonds, Clubs or Spades");
            }

            // TODO: Set the value of IsFaceUp based on the argument value

        }


        #endregion
    }
}
