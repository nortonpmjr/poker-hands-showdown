using System;
using System.Collections.Generic;
using PokerHandShowdown;

namespace PokerHSApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            ShowMenu(players: players);
        }

        static private void ShowMenu(List<Player> players)
        {
            Console.Clear();
            Console.WriteLine("Select an action");
            Console.WriteLine("1) Add a new player");
            Console.WriteLine("2) Show winners");

            String menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    Console.Clear();
                    players.Add(PokerLibrary.AddPlayer());

                    ShowMenu(players: players);
                    break;
                case "2":
                    break;
                default:
                    ShowMenu(players: players);
                    break;
            }
        }
    }
}
