using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ubix.BlackJack
{
    public partial class GameBoard : Form
    {
        private CardDeck _deck;
        private List<Card> _player;  // the player's hand
        private List<Card> _dealer;  // the dealer's hand

        public GameBoard()
        {
            InitializeComponent();

            // get a fresh deck for this game
            _deck = new CardDeck();

            // both the player's and dealer's hands are empty at initialization
            _player = new List<Card>();
            _dealer = new List<Card>();

            // set the state of the various buttons that will control the game
            hit.Enabled = false;
            stand.Enabled = false;
            next.Enabled = false;
        }

        /// <summary>
        /// the player's hand
        /// </summary>
        public List<Card> Player { get { return _player; } }

        /// <summary>
        /// the dealer's hand
        /// </summary>
        public List<Card> Dealer { get { return _dealer; } }

        /// <summary>
        /// deal a new game
        /// </summary>
        private void deal_Click(object sender, EventArgs e)
        {
            // get a fresh deck
            _deck.ResetDeck();
            outcome.Text = "";

            // reset the hands
            Player.Clear();
            Dealer.Clear();
            playersCards.Items.Clear();
            dealersCards.Items.Clear();

            // deal the 2 player's cards (both face up)
            Player.Add(_deck.DrawCard());
            Player.Add(_deck.DrawCard());
            Player[0].ShowCard();
            Player[1].ShowCard();

            // deal the 2 dealer's cards (first face down)
            Dealer.Add(_deck.DrawCard());
            Dealer.Add(_deck.DrawCard());
            Dealer[1].ShowCard();

            // set the list views to monitor the proper hands
            for (int i = 0; i < 2; i++)
            {
                playersCards.Items.Add(Player[i]);
                dealersCards.Items.Add(Dealer[i]);
            }

            // enable the next actions
            hit.Enabled = true;
            stand.Enabled = true;

            // show the current values
            value_p.Text = "value: " + Scoring.HandValue(Player);
            value_d.Text = "value: " + Scoring.HandValue(Dealer);

            // calculate initial probabilities
            var probabilities = Scoring.CalculateProbabilities(Player, Dealer);
            UpdateProbabilities(probabilities);
        }

        /// <summary>
        /// player hits for a new card
        /// </summary>
        private void hit_Click(object sender, EventArgs e)
        {
            // get a new card from the deck
            var card = _deck.DrawCard();
            card.ShowCard();
            Player.Add(card);

            // show the new card on the player's hand
            playersCards.Items.Add(Player.Last());
            var value = Scoring.HandValue(Player);
            value_p.Text = value <= 21 ? "value: " + value : "busted";

            // calculate new probabilities
            var probabilities = Scoring.CalculateProbabilities(Player, Dealer);
            UpdateProbabilities(probabilities);

            if (value > 21)  // end the hand
                PresentFinalOutcome(probabilities);
        }

        /// <summary>
        /// player stands
        /// </summary>
        private void stand_Click(object sender, EventArgs e)
        {
            // player is done, update state of action buttons
            hit.Enabled = false;
            stand.Enabled = false;

            // reveal the dealer's hidden card
            Dealer[0].ShowCard();
            dealersCards.Items[0] = Dealer[0];
            var value = Scoring.HandValue(Dealer);
            value_d.Text = "value: " + value;

            // calculate new probabilities
            var probabilities = Scoring.CalculateProbabilities(Player, Dealer);
            UpdateProbabilities(probabilities);

            // dealer does not draw on a soft 17
            if (value >= 17)  // end the hand
                PresentFinalOutcome(probabilities);
            else
                next.Enabled = true;
        }

        /// <summary>
        /// dealer gets the next card
        /// </summary>
        private void next_Click(object sender, EventArgs e)
        {
            // get a new card from the deck
            var card = _deck.DrawCard();
            card.ShowCard();
            Dealer.Add(card);

            // show the new card on the player's hand
            dealersCards.Items.Add(Dealer.Last());
            var value = Scoring.HandValue(Dealer);
            value_d.Text = value <= 21 ? "value: " + value : "busted";

            // calculate new probabilities
            var probabilities = Scoring.CalculateProbabilities(Player, Dealer);
            UpdateProbabilities(probabilities);

            if (value >= 17)  // end the hand
                PresentFinalOutcome(probabilities);
        }

        private void UpdateProbabilities(Probabilities probs)
        {
            win.Text  = String.Format("{0:0.00}%", probs.Win);
            push.Text = String.Format("{0:0.00}%", probs.Tie);
            lose.Text = String.Format("{0:0.00}%", probs.Lose);
        }

        private void PresentFinalOutcome(Probabilities probs)
        {
            if (probs.Win > 0.9999)
            {
                outcome.Text = "PLAYER WON!";
            }
            else if (probs.Tie > 0.9999)
            {
                outcome.Text = "IT IS A PUSH!";
            }
            else
            {
                outcome.Text = "PLAYER LOST!";
            }

            hit.Enabled = false;
            stand.Enabled = false;
            next.Enabled = false;
        }
    }
}
