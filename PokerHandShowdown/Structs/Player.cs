﻿using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public struct Player
    {
       public String name;
       public String cardsString;

       public List<Card> cards;
       public Hand hand;

       public Player(String name)
        {
            this.name = name;
            this.cardsString = "";
            this.hand = Hand.HigherCard;
            this.cards = new List<Card>();
        }

        public void SortCards()
        {
            String[] splittedCards = cardsString.ToUpper().Replace(" ","").Split(',');

            for (int i = 0; i < splittedCards.Length; i++)
            {
                Char[] cardArray = splittedCards[i].ToCharArray();
                cards.Add(new Card(value: cardArray[0].ToString(),
                          suit: cardArray[1].ToString()));
            }
            cards.Sort();
        }
    }
}
