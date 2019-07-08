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
                    PokerLibrary.EvaluateHands(players);
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
                        } else if (players[i].hand == winner.hand)
                        {
                            if (winner.hand == Hand.Flush)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    if (winner.cards[j].intValue < players[i].cards[j].intValue)
                                    {
                                        winner = players[i];
                                        j = 5;
                                    } else if (j == 4)
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
                        for(int i = 0; i < winners.Count; i++)
                        {
                            Console.WriteLine(winners[i].name);
                        }
                    } else
                    {
                        Console.WriteLine(winner.name);
                    }
                    break;
                default:
                    ShowMenu(players: players);
                    break;
            }
        }
    }
}
