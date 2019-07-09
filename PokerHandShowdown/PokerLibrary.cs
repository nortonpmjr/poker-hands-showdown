using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class PokerLibrary
    {
        static public Player AddPlayer()
        {

            Console.WriteLine("Enter player name: ");
            String name = Console.ReadLine();
            Player player = new Player(name: name);

            Console.WriteLine("Enter player cards: ");
            player.cardsString = Console.ReadLine();
            player.SortCards();

            return player;
        }

        static public void EvaluateHands(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Player p = players[i];
                if (VerifyFlush(p: players[i]))
                {
                    p.hand = Hand.Flush;
                } else if (VerifyThreeOfAKind(p: players[i]))
                {
                    p.hand = Hand.ThreeOfAKind;
                } else if (VerifyPair(p: players[i]))
                {
                    p.hand = Hand.OnePair;
                }

                Console.WriteLine("Player: " + p.name + " has a " + p.hand.ToString());

                players[i] = p;
            }
        }

        static public void ShowWinner(List<Player> players)
        {
            Player winner = players[0];

            List<Player> winners = new List<Player>();
            winners.Add(winner);

            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].hand > winner.hand)
                {
                    winner = players[i];
                    winners.Clear();
                    winners.Add(winner);
                }
                else if (players[i].hand == winner.hand)
                {
                    if (winner.hand == Hand.Flush)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (winner.cards[j].intValue < players[i].cards[j].intValue)
                            {
                                winner = players[i];
                                winners.Clear();
                                winners.Add(winner);
                                j = 5;
                            }
                            else if (j == 4)
                            {
                                winners.Add(players[i]);
                            }
                        }
                    } else if (winner.hand == Hand.ThreeOfAKind)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            if (winner.repeatingCards[j].intValue < players[i].repeatingCards[j].intValue)
                            {
                                winner = players[i];
                                winners.Clear();
                                winners.Add(winner);
                                j = 3;
                            } else if (j == 2)
                            {
                                winners.Add(players[i]);
                            }
                        }
                    }
                }
            }
            if (winners.Count > 1)
            {
                Console.WriteLine("It's a Tie!");
                for (int i = 0; i < winners.Count; i++)
                {
                    Console.WriteLine(winners[i].name);
                }
            }
            else
            {
                Console.WriteLine(winner.name + " is the winner");
            }
        }

        static private bool VerifyFlush(Player p)
        {
            bool isFlush = true;
            String suit = p.cards[0].suit;

            // Is Flush?
            for (int i = 1; i < p.cards.Count; i++)
            {
                isFlush = p.cards[i].suit.ToUpper() == suit;
            }

            return isFlush;
        }

        static public bool VerifyThreeOfAKind(Player p)
        {
            bool isThreeOfAKind = true;

            var cardsValue = p.cards.Select(x => x.value);
            isThreeOfAKind = cardsValue.GroupBy(x => x).Any(g => g.Count() == 3);

            Dictionary<int, int> repeatedValues = FindRepeatedValues(p);

            PopulatePlayerRepeatingCards(p, repeatedValues, 3);

            return isThreeOfAKind;
        }

        static public bool VerifyPair(Player p)
        {
            bool isPair = true;
            var cardsValue = p.cards.Select(x => x.value);
            isPair = cardsValue.GroupBy(x => x).Any(g => g.Count() == 2);

            Dictionary<int, int> repeatedValues = FindRepeatedValues(p);

            PopulatePlayerRepeatingCards(p, repeatedValues, 2);

            return isPair;
        }

        static public Dictionary<int, int> FindRepeatedValues(Player p)
        {
            Dictionary<int, int> repeatedValues = new Dictionary<int, int>();

            for (int i = 0; i < p.cards.Count; i++)
            {
                if (repeatedValues.ContainsKey(p.cards[i].intValue))
                {
                    repeatedValues[p.cards[i].intValue]++;
                }
                else
                {
                    repeatedValues.Add(p.cards[i].intValue, 1);
                }
            }

            return repeatedValues;
        }

        static public void PopulatePlayerRepeatingCards(Player p, Dictionary<int, int> repeatedValues, int repetetions)
        {
            for (int i = 0; i < p.cards.Count; i++)
            {
                int tmpValue = p.cards[i].intValue;

                if (repeatedValues.ContainsKey(tmpValue) && repeatedValues[tmpValue] == repetetions)
                {
                    p.repeatingCards.Add(p.cards[i]);
                }
            }
        }
    }
}
