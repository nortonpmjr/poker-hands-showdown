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

        static private bool VerifyThreeOfAKind(Player p)
        {
            bool isThreeOfAKind = true;

            var cardsValue = p.cards.Select(x => x.value);
            isThreeOfAKind = cardsValue.GroupBy(x => x).Any(g => g.Count() == 3);

            Dictionary<int, int> repeatingValue = new Dictionary<int, int>();

            for (int i = 0; i < p.cards.Count; i++)
            {
                if (repeatingValue.ContainsKey(p.cards[i].intValue))
                {
                    repeatingValue[p.cards[i].intValue] += 1;
                } else
                {
                    repeatingValue.Add(p.cards[i].intValue, 1);
                }
            }

            List<Card> repeatingCards = new List<Card>();

            for (int i = 0; i < p.cards.Count; i++)
            {
                int tmpValue = p.cards[i].intValue;
                if (repeatingValue.ContainsKey(tmpValue))
                {
                    if (repeatingValue[tmpValue] == 3)
                    {
                        repeatingCards.Add(p.cards[i]);
                    }
                }
            }

            p.repeatingCards = repeatingCards;

            return isThreeOfAKind;
        }

        static private bool VerifyPair(Player p)
        {
            bool isPair = true;
            var cardsValue = p.cards.Select(x => x.value);
            isPair = cardsValue.GroupBy(x => x).Any(g => g.Count() == 2);

            return isPair;
        }
    }
}
