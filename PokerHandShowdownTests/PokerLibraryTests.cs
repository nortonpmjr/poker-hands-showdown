using NUnit.Framework;
using PokerHandShowdown;
using System.Collections.Generic;

namespace Tests
{
    public class libraryTests
    {
        PlayerFactory factory = new PlayerFactory();
        readonly PokerLibrary library = new PokerLibrary();

        [Test]
        public void TestPlayerHandSorting()
        {
            List<Player> players = factory.CreatePlayers();
            library.EvaluateHands(players);

            Assert.AreEqual(players[0].hand, Hand.OnePair);
            Assert.AreEqual(players[1].hand, Hand.Flush);
            Assert.AreEqual(players[2].hand, Hand.Flush);
            Assert.AreEqual(players[3].hand, Hand.ThreeOfAKind);

            library.ShowWinner(players);
        }

        [Test]
        public void TestVerifyFlush()
        {
            Player p = factory.CreateSinglePlayer();

            bool isFlush = library.VerifyFlush(p);
            Assert.IsFalse(isFlush);
        }

        [Test]
        public void TestThreeOfaKindComparsion()
        {
            List<Player> players = factory.CreateThreeOFAKindPlayers();
            library.EvaluateHands(players);

            library.ShowWinner(players);
        }

        [Test]
        public void TestVerifyThreeOfAKind()
        {
            Player p = factory.CreateSinglePlayer();

            library.VerifyThreeOfAKind(p);

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
            Player p = factory.CreateSinglePlayer();

            library.VerifyPair(p);

            Card one = new Card(value: "A", suit: "S");
            Card two = new Card(value: "A", suit: "C");

            Assert.True(p.repeatingCards.Contains(one));
            Assert.True(p.repeatingCards.Contains(two));
        }


        [Test]
        public void TestFindRepeatedValues()
        {
            Player p = factory.CreateSinglePlayer();

            Dictionary<int, int> repeatedValues = library.FindRepeatedValues(p);

            Assert.IsNotEmpty(repeatedValues);
        }

        [Test]
        public void TestPopulateRepeatingCards()
        {
            Player p = factory.CreateSinglePlayer();

            Dictionary<int, int> repeatedValues = library.FindRepeatedValues(p);
            library.PopulatePlayerRepeatingCards(p, repeatedValues, 3);

            Assert.IsNotEmpty(p.repeatingCards);
        }

        [Test]
        public void TestRepeatingCardsAreEqual()
        {
            List<Player> players = factory.CreateThreeOFAKindPlayers();
            library.EvaluateHands(players);
            _ = library.VerifyThreeOfAKind(players[0]);
            _ = library.VerifyThreeOfAKind(players[1]);

            Assert.True(library.RepeatingCardAreEqual(players[0], players[1]));
        }

        [Test]
        public void TestTie()
        {
            List<Player> players = factory.CreateTiePlayers();
            library.EvaluateHands(players);
            library.ShowWinner(players);
        }

        [Test]
        public void TestHigherOrderTie()
        {
            List<Player> players = factory.CreateHigherOrderTiePlayers();
            library.EvaluateHands(players);
            library.ShowWinner(players);
        }

        [Test]
        public void TestHigherOrder()
        {
            List<Player> players = factory.CreateHigherOrder();
            library.EvaluateHands(players);
            library.ShowWinner(players);
        }

        
    }
}
