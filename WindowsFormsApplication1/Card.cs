using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubix.BlackJack
{
    /// <summary>
    /// This class is for cards that will be used in our black jack game
    /// 
    /// Note: I thought of creating a BlackJackCard that inherits from Card, so to keep Card very generic,
    ///       but thought it would be somewhat overkill for this exercise.
    /// </summary>
    public class Card
    {
        private int _number;
        private int _rank;
        private int _suit;

        /// <summary>
        /// constructor from a card number ranging between 0 & 51
        /// </summary>
        /// <param name="number"></param>
        public Card(int number)
        {
            if (number < 0 || number > 51)
                throw new Exception("Card number is invalid");

            _number = number;
            _suit = number / 13;
            _rank = number % 13;

            Label = "<hidden>";
            Hidden = true;
        }

        /// <summary>
        /// Human readable label to show on the game board
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// is the card currently visible to the player?
        /// </summary>
        public bool Hidden { get; private set; }

        /// <summary>
        /// BlackJack value of the card
        /// </summary>
        public int Value { get { return (_rank < 10) ? _rank + 1 : 10; } }

        /// <summary>
        /// Since this As is special in BlackJack let's make it easily identifiable
        /// </summary>
        public bool IsAnAce { get { return _rank == 0; } }

        /// <summary>
        /// make the label available again
        /// </summary>
        public void ShowCard()
        {
            Label = PrepareLabel(_rank, _suit);
            Hidden = false;
        }

        /// <summary>
        /// map the card rank and suit to a human readable label that corresponds
        /// </summary>
        private static string PrepareLabel(int rank, int suit)
        {
            var ranks = new Dictionary<int, string> 
            {
                { 0, "A" },
                { 1, "2" },
                { 2, "3" },
                { 3, "4" },
                { 4, "5" },
                { 5, "6" },
                { 6, "7" },
                { 7, "8" },
                { 8, "9" },
                { 9, "10" },
                { 10, "J" },
                { 11, "Q" },
                { 12, "K" },
            };

            var suits = new Dictionary<int, string> 
            { 
                { 0, "Spades" }, 
                { 1, "Hearts" }, 
                { 2, "Diamonds" }, 
                { 3, "Clubs" } 
            };

            return ranks[rank] + " of " + suits[suit];
        }

        /// <summary>
        /// ToString() gives us the label of the card
        /// </summary>
        public override string ToString()
        {
            return Label;
        }

        /// <summary>
        /// override of the hashcode
        /// </summary>
        public override int GetHashCode()
        {
            return _number;
        }

        /// <summary>
        /// is a card the same as the other card?
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as Card;

            if (other == null)  // is other a card?
                return false;

            return other._number == this._number;
        }
    }
}
