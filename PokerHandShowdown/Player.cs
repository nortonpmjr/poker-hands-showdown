using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public struct Player
    {
        public String name;
        public String cards;

       public Player(String name)
        {
            this.name = name;
            this.cards = "";
        }
    }
}
