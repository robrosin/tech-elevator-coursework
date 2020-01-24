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

        /// <summary>
        /// "Spades", "Clubs", "Hearts" or "Diamonds"
        /// </summary>
        public string Suit { get; set; }

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

        public string CardName
        {
            get
            {
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

        /// <summary>
        /// Flip the card over.
        /// </summary>
        public void Flip()
        {
            this.IsFaceUp = !this.IsFaceUp;
        }

        #endregion

        #region Constructors


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
        }


        #endregion
    }
}
