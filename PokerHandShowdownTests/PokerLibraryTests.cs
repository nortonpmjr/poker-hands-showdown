using NUnit.Framework;
using PokerHandShowdown;
using System.Collections.Generic;

namespace Tests
{
    public class PokerLibraryTests
    {
        [Test]
        public void TestPlayerHandSorting()
        {
            List<Player> players = CreatePlayers();
            PokerLibrary.EvaluateHands(players);

            Assert.AreEqual(players[0].hand, Hand.OnePair);
            Assert.AreEqual(players[1].hand, Hand.Flush);
            Assert.AreEqual(players[2].hand, Hand.Flush);
            Assert.AreEqual(players[3].hand, Hand.ThreeOfAKind);

            PokerLibrary.ShowWinner(players);
        }

        [Test]
        public void TestVerifyFlush()
        {
            Player zelda = new Player("zelda");
            zelda.cardsString = "AS, AD, AC, 6D, 4C";
            zelda.SortCards();

            bool isFlush = PokerLibrary.VerifyFlush(zelda);
            Assert.IsFalse(isFlush);
        }

        [Test]
        public void TestThreeOfaKindComparsion()
        {
            List<Player> players = CreateThreeOFAKindPlayers();
            PokerLibrary.EvaluateHands(players);

            PokerLibrary.ShowWinner(players);
        }

        [Test]
        public void TestVerifyThreeOfAKind()
        {
            Player p = new Player("zelda");
            p.cardsString = "AS, AC, AD, 6D, 4C";
            p.SortCards();

            PokerLibrary.VerifyThreeOfAKind(p);

            Card one = new Card(value: "A", suit: "S");
            Card two = new Card(value: "A", suit: "C");
            Card three = new Card(value: "A", suit: "D");

            Assert.True(p.repeatingCards.Contains(one));
            Assert.True(p.repeatingCards.Contains(two));
            Assert.True(p.repeatingCards.Contains(three));
        }

        [Test]
        public void TestVerifyPair()
        {
            Player p = new Player("zelda");
            p.cardsString = "AS, AC, 9D, 8C, 4C";
            p.SortCards();

            PokerLibrary.VerifyPair(p);

            Card one = new Card(value: "A", suit: "S");
            Card two = new Card(value: "A", suit: "C");

            Assert.True(p.repeatingCards.Contains(one));
            Assert.True(p.repeatingCards.Contains(two));
        }


        [Test]
        public void TestFindRepeatedValues()
        {
            Player p = new Player("zelda");
            p.cardsString = "AS, AC, AD, 6D, 4C";
            p.SortCards();

            Dictionary<int, int> repeatedValues = PokerLibrary.FindRepeatedValues(p);

            Assert.IsNotEmpty(repeatedValues);
        }

        [Test]
        public void TestPopulateRepeatingCards()
        {
            Player p = new Player("zelda");
            p.cardsString = "AS, AC, AD, 6D, 4C";
            p.SortCards();

            Dictionary<int, int> repeatedValues = PokerLibrary.FindRepeatedValues(p);
            PokerLibrary.PopulatePlayerRepeatingCards(p, repeatedValues, 3);

            Assert.IsNotEmpty(p.repeatingCards);
        }

        [Test]
        public void TestRepeatingCardsAreEqual()
        {
            List<Player> players = CreateThreeOFAKindPlayers();
            PokerLibrary.EvaluateHands(players);
            _ = PokerLibrary.VerifyThreeOfAKind(players[0]);
            _ = PokerLibrary.VerifyThreeOfAKind(players[1]);

            Assert.True(PokerLibrary.RepeatingCardAreEqual(players[0], players[1]));
        }

        [Test]
        public void TestTie()
        {
            List<Player> players = CreateTiePlayers();
            PokerLibrary.EvaluateHands(players);
            PokerLibrary.ShowWinner(players);
        }

        [Test]
        public void TestHigherOrderTie()
        {
            List<Player> players = CreateHigherOrderTiePlayers();
            PokerLibrary.EvaluateHands(players);
            PokerLibrary.ShowWinner(players);
        }

        [Test]
        public void TestHigherOrder()
        {
            List<Player> players = CreateHigherOrder();
            PokerLibrary.EvaluateHands(players);
            PokerLibrary.ShowWinner(players);
        }

        private List<Player> CreateThreeOFAKindPlayers()
        {
            List<Player> players = new List<Player>();

            Player zelda = new Player("zelda");
            zelda.cardsString = "AS, AD, AC, 6D, 4H";
            zelda.SortCards();

            Player sally = new Player("sally");
            sally.cardsString = "AS, AD, AC, QC, 8D";
            sally.SortCards();

            players.Add(zelda);
            players.Add(sally);

            return players;
        }

        private List<Player> CreatePlayers()
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

        private List<Player> CreateTiePlayers()
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

        private List<Player> CreateHigherOrderTiePlayers()
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

        private List<Player> CreateHigherOrder()
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
