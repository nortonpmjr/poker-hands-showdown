using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public struct Player: IEquatable<Player>
    {
       public String name;
       public String cardsString;

       public List<Card> cards;
       public Hand hand;
       public List<Card> repeatingCards;

       public Player(String name)
        {
            this.name = name;
            this.cardsString = "";
            this.hand = Hand.HigherCard;
            this.cards = new List<Card>();
            this.repeatingCards = new List<Card>();
        }

        public void SortCards()
        {
            String[] splittedCards = cardsString.ToUpper().Replace(" ","").Split(',');

            for (int i = 0; i < splittedCards.Length; i++)
            {
                Char[] cardArray = splittedCards[i].ToCharArray();
                if (cardArray.Length == 2)
                {
                    cards.Add(new Card(value: cardArray[0].ToString(),
                        suit: cardArray[1].ToString()));
                } else
                {
                    cards.Add(new Card(cardArray[0].ToString() + cardArray[1].ToString(),
                               cardArray[2].ToString()));
                }
            }
            cards.Sort();
        }

        public bool Equals(Player other)
        {
            return cards == other.cards && name == other.name;
        }
    }
}
