using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubix.BlackJack
{
    public static class Scoring
    {
        /// <summary>
        /// calculate the total value of all visible cards
        /// In the event there is an ace in the hand, use higher value, unless it is over 21, then use 1
        /// </summary>
        public static int HandValue(IList<Card> hand)
        {
            var total = hand.Where(card => !card.Hidden).Sum(card => card.Value);

            // in any one hand there is only 1 ace which may be worth 11, otherwise the hand is garanteed to go over 21
            if (hand.Count(card => card.IsAnAce) > 0 && total < 12)
                total += 10;  // transform the 1 into 11

            return total;
        }

        public static Probabilities CalculateProbabilities(IList<Card> player, IList<Card> dealer)
        {
            var playerValue = HandValue(player);
            var dealerValue = HandValue(dealer);

            // are the hands final?
            if (playerValue > 21 || dealerValue >= 17)
                return FinalResult(player, dealer);

            // establish which cards are available to come up with potential combinations
            var visiblePlayerCards = player.Where(card => !card.Hidden).ToList();
            var visibleDealerCards = dealer.Where(card => !card.Hidden).ToList();
            var visibleCards = visiblePlayerCards.Union(visibleDealerCards);

            // probabilities are calculated for a single deck of available cards and a single player
            var availableCards = Enumerable.Range(0, 52)
                                           .Select(num => new Card(num))
                                           .Where(card => !visibleCards.Contains(card))
                                           .ToList();

            var totalCards = availableCards.Count;

            // make all available cards visible, since hidden cards are ignored during hand value calculation
            foreach (var card in availableCards)
                card.ShowCard();

            // calculate probabilities for the current unfinished state
            var probabilities = new Dictionary<string, double> 
            {
                {"17", 0.0},
                {"18", 0.0},
                {"19", 0.0},
                {"20", 0.0},
                {"21", 0.0},
                {"BJ", 0.0},
                {"Bust", 0.0}
            };

            var totalProbability = 1.0;

            // get all distinct values for the currently available cards
            var values = availableCards.GroupBy(card => card.Value);

            // recursively traverse all possibilities stopping on a soft 17
            foreach (var group in values)
            {
                var groupSize = group.Count();
                var groupProb = totalProbability * groupSize / totalCards;  // probability of running into this particular group

                FindProbabilitiesForValue(visibleDealerCards, availableCards, group.Key, groupProb, probabilities);
            }

            // is the player holding on to a blackjack? if so players always wins except when dealer has BJ 
            if (player.Count == 2 && playerValue == 21)
            {
                double bjTie = probabilities["BJ"] * 100.0;
                double bjWin = 100.0 - bjTie;
                return new Probabilities { Win = bjWin, Tie = bjTie };
            }

            // player always wins if dealer busts
            double win = probabilities["Bust"] * 100.0;

            // player always loses if dealer BJ
            double lose = probabilities["BJ"] * 100.0;

            // compare values
            double tie = 0.0;
            foreach(var kvp in probabilities.Where(p => p.Key != "Bust" && p.Key != "BJ"))
            {
                var probabilityValue = int.Parse(kvp.Key);
                var probability = kvp.Value;

                if (playerValue > probabilityValue)
                    win += probability * 100.0;
                else if (playerValue == probabilityValue)
                    tie += probability * 100.0;
                else
                    lose += probability * 100.0;
            }

            return new Probabilities { Win = win, Tie = tie, Lose = lose };
        }

        private static void FindProbabilitiesForValue(IList<Card> hand, IList<Card> availableCards, int cardValue, double totalProb, Dictionary<string, double> probabilities)
        {
            // start by grouping available cards by value
            var available = availableCards.GroupBy(card => card.Value);

            // look for blacjacks first
            if (hand.Count == 1)
            {
                if ((HandValue(hand) == 11 && cardValue == 10) || (HandValue(hand) == 10 && cardValue == 1))
                {
                    probabilities["BJ"] += totalProb;
                    return;
                }
            }
            
            // grab any card of the correct value and add it to the hand
            var cardOfValue = available.Single(g => g.Key == cardValue).Last();

            var updatedHand = new List<Card>(hand);  // essentially clone the hand for eventual recursive call
            updatedHand.Add(cardOfValue);

            var updatedCards = new List<Card>(availableCards);  // clone available cards for eventual recursive call
            updatedCards.Remove(cardOfValue);

            var updatedHandValue = HandValue(updatedHand);

            // is our updated hand value at or above 17, we are done add the results and leave
            if (updatedHandValue >= 17)
            {
                if (updatedHandValue > 21)  // the hand busts!
                {
                    probabilities["Bust"] += totalProb;  // this possibly happens as many times as there are cards of this value
                    return;
                }

                probabilities[updatedHandValue.ToString()] += totalProb;
                return;
            }

            // our new hand value is below 17, continue to recursively look for combinations
            var groups = updatedCards.GroupBy(card => card.Value);
            var totalCards = updatedCards.Count;

            foreach (var group in groups)
            {
                var groupSize = group.Count();
                var groupProb = totalProb * groupSize / totalCards;  // probability of running into this particular group

                FindProbabilitiesForValue(updatedHand, updatedCards, group.Key, groupProb, probabilities);
            }
        }

        public static Probabilities FinalResult(IList<Card> player, IList<Card> dealer)
        {
            var playerValue = HandValue(player);
            var dealerValue = HandValue(dealer);

            // has one of the hands gone over?
            if (playerValue > 21)
                return new Probabilities { Lose = 1.0 };

            if (dealerValue > 21)
                return new Probabilities { Win = 1.0 };

            // is a black jack in play?
            if (dealerValue == 21 && playerValue == 21)
            {
                var playerBJ = player.Count == 2;
                var dealerBJ = dealer.Count == 2;

                if (playerBJ && dealerBJ)
                    return new Probabilities { Tie = 1.0 };

                if (playerBJ)
                    return new Probabilities { Win = 1.0 };

                if (dealerBJ)
                    return new Probabilities { Lose = 1.0 };
            }

            // compare values
            if (playerValue > dealerValue)
                return new Probabilities { Win = 1.0 };

            if (playerValue == dealerValue)
                return new Probabilities { Tie = 1.0 };

            return new Probabilities { Lose = 1.0 };  // only choice left is player < dealer
        }
    }

    /// <summary>
    /// Simple class to gather all probabilities to be returned by the Scoring class (in percentages)
    /// </summary>
    public class Probabilities
    {
        public double Win { get; set; }
        public double Tie { get; set; }
        public double Lose { get; set; }
    }
}