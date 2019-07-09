using PokerHandShowdown;
using System.Collections.Generic;

namespace Tests
{
    public class PlayerFactory
    {
        public PlayerFactory()
        {

        }

        public Player CreateSinglePlayer() {
            Player p = new Player("zelda");
            p.cardsString = "AS, AC, AD, 6D, 4C";
            p.SortCards();

            return p;
        }

        public List<Player> CreateThreeOFAKindPlayers()
        {
            List<Player> players = new List<Player>();

            Player zelda = new Player("zelda")
            {
                cardsString = "AS, AD, AC, 6D, 4H"
            };
            zelda.SortCards();

            Player sally = new Player("sally");
            sally.cardsString = "AS, AD, AC, QC, 8D";
            sally.SortCards();

            players.Add(zelda);
            players.Add(sally);

            return players;
        }

        public List<Player> CreatePlayers()
        {
            List<Player> players = new List<Player>();
            Player joe = new Player("joe");
            joe.cardsString = "8S, 8D, AD, QD, JH";
            joe.SortCards();

            Player bob = new Player("bob");
            bob.cardsString = "AS, QS, 8S, 6S, 4S";
            bob.SortCards();

            Player zelda = new Player("zelda");
            zelda.cardsString = "AS, KS, QS, 6S, 4S";
            zelda.SortCards();

            Player sally = new Player("sally");
            sally.cardsString = "4S, 4H, 4H, QC, 8C";
            sally.SortCards();

            players.Add(joe);
            players.Add(bob);
            players.Add(zelda);
            players.Add(sally);

            return players;
        }

        public List<Player> CreateTiePlayers()
        {
            List<Player> players = new List<Player>();
            Player joe = new Player("joe");
            joe.cardsString = "4S, 4H, 3H, QC, 8C";
            joe.SortCards();

            Player sally = new Player("sally");
            sally.cardsString = "4S, 4H, 3H, QC, 8C";
            sally.SortCards();

            players.Add(joe);
            players.Add(sally);

            return players;
        }

        public List<Player> CreateHigherOrderTiePlayers()
        {
            List<Player> players = new List<Player>();
            Player joe = new Player("joe");
            joe.cardsString = "4S, 2D, 3H, QC, 8C";
            joe.SortCards();

            Player sally = new Player("sally");
            sally.cardsString = "4S, 2D, 3H, QC, 8C";
            sally.SortCards();

            players.Add(joe);
            players.Add(sally);

            return players;
        }

        public List<Player> CreateHigherOrder()
        {
            List<Player> players = new List<Player>();
            Player joe = new Player("joe");
            joe.cardsString = "4S, 2D, 3H, QC, 8C";
            joe.SortCards();

            Player sally = new Player("sally");
            sally.cardsString = "4S, 2D, 3H, QC, AC";
            sally.SortCards();

            players.Add(joe);
            players.Add(sally);

            return players;
        }
    }
}
