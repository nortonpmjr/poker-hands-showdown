using System;
using System.Collections.Generic;

// N player with 5 cards each

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
            player.cards = Console.ReadLine();

            return player;
        }
    }
}
