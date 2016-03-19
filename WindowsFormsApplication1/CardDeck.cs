using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubix.BlackJack
{
    /// <summary>
    /// Class managing the card deck from which all players cards come from
    /// this is also where all players hands are managed
    /// </summary>
    public class CardDeck
    {
        private Random _random;
        private List<Card> _cards;

        /// <summary>
        /// constructor with all cards of a single deck (no jokers)
        /// </summary>
        public CardDeck()
        {
            _random = new Random(DateTime.Now.Millisecond);
            ResetDeck();
        }

        public void ResetDeck()
        {
            _cards = Enumerable.Range(0, 52).Select(number => new Card(number)).ToList();
        }

        /// <summary>
        /// draw a card at random from the deck
        /// </summary>
        public Card DrawCard() 
        {
            // pick a card at random in what is left of the deck
            var index = _random.Next(_cards.Count);
            var card = _cards[index];

            // remove the card from the deck and return it
            _cards.RemoveAt(index);
            return card;
        }
    }
}
