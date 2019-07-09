using System;
using PokerHandShowdown;
using System.Collections.Generic;

namespace PokerHSApp
{
    public class GameController
    {
        readonly PokerLibrary library;
        List<Player> players;
        public GameController()
        {
            library = new PokerLibrary();
            players = new List<Player>();
            ShowMenu();
        }

        private void ShowMenu()
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
                    players.Add(library.AddPlayer());

                    ShowMenu();
                    break;
                case "2":
                    library.EvaluateHands(players);
                    library.ShowWinner(players);
                    break;
                default:
                    ShowMenu();
                    break;
            }
        }
    }
}
