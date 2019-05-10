using System;
using Xunit;
using WheelOfFortune;
using System.IO;


namespace WheelOfFortuneTest
{
    public class GameTest
    {
        private Game game = new Game(3, 3);

        private void ResetConsole()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [Fact]
        public void ConstructorTest()
        {
            ResetConsole();
            Assert.Equal(3, game.NumberOfPlayers);
            Assert.Equal(3, game.Rounds);
            Assert.Equal(3, game.Players.Length);
            Assert.Equal(new Player[3], game.Players);
            ResetConsole();

        }

        [Fact]
        public void DisplayRoundWinnerTest()
        {
            ResetConsole();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game(1, 1);
                var winner = new Player("Kyle");
                winner.AddRoundMoney(200);
                game.AddPlayer(0, winner);
                game.DisplayRoundWinner(winner, 1);
                string expected = string.Format($"{Environment.NewLine}Congrats {winner.Name}!{Environment.NewLine}You won $200 that for Round 1.{Environment.NewLine}");
                Assert.Equal(expected, sw.ToString());
            }
            ResetConsole();

        }

        [Fact]
        public void DisplayWinnerTest()
        {
            ResetConsole();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game(1, 1);
                var winner = new Player("Kyle");
                game.DisplayWinner(winner);

                string expected = string.Format($"{Environment.NewLine}GG, Well Played All{Environment.NewLine}The winner is Kyle. You take home $0{Environment.NewLine}");
                Assert.Equal(expected, sw.ToString());
            }
            ResetConsole();

        }

        [Fact]
        public void DisplayEndRoundMessageTest()
        {
            ResetConsole();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game(1, 1);
                var winner = new Player("Kyle");
                winner.AddMoneyToBank(100);
                game.AddPlayer(0, winner);
                game.DisplayEndRoundMessage(game.Players);
                string expected = string.Format($"{Environment.NewLine}Total earnings thus far:{Environment.NewLine}Kyle: $100{Environment.NewLine}");
                Assert.Equal(expected, sw.ToString());

            }
            ResetConsole();

        }


        [Fact]
        public void AddPlayerTest()
        {
            ResetConsole();

            Assert.Equal(new Player[3], game.Players);
            game.AddPlayer(0, new Player("Kyle"));
            var expected = new Player[3];
            expected[0] = new Player("Kyle");
            Assert.Equal(expected[0].Name, game.Players[0].Name);
            Assert.Equal(expected[0].Bank, game.Players[0].Bank);
            Assert.Equal(expected[0].RoundMoney, game.Players[0].RoundMoney);

            Assert.NotEmpty(expected);
            ResetConsole();

        }

        [Fact]
        public void FindWinnerWithOnePlayerTest()
        {
            ResetConsole();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var newGame = new Game(1, 1);
                var winner = new Player("Kyle");
                winner.AddMoneyToBank(100);
                newGame.AddPlayer(0, winner);
                var players = newGame.Players;
                newGame.FindWinner(players);
                string expected = string.Format($"{Environment.NewLine}Kyle: $100{Environment.NewLine}{Environment.NewLine}GG, Well Played All{Environment.NewLine}The winner is Kyle. You take home $100{Environment.NewLine}");
                Assert.Equal(expected, sw.ToString());
            }
            ResetConsole();

        }
        [Fact]
        public void FindWinnerWithMoreThanOnePlayerTest()
        {
            ResetConsole();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game(1, 2);
                var winner = new Player("Kyle");
                winner.AddMoneyToBank(200);
                var loser = new Player("Mark");
                loser.AddMoneyToBank(100);
                game.AddPlayer(0, winner);
                game.AddPlayer(1, loser);
                game.FindWinner(game.Players);
                string expected = string.Format($"{Environment.NewLine}Kyle: $200{Environment.NewLine}Mark: $100{Environment.NewLine}{Environment.NewLine}GG, Well Played All{Environment.NewLine}The winner is Kyle. You take home $200{Environment.NewLine}");
                Assert.Equal(expected, sw.ToString());
            }
            ResetConsole();

        }

        [Fact]
        public void HandleTieGame()
        {
            ResetConsole();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var game = new Game(1, 2);
                var winner = new Player("Kyle");
                winner.AddMoneyToBank(200);
                var loser = new Player("Mark");
                loser.AddMoneyToBank(200);
                game.AddPlayer(0, winner);
                game.AddPlayer(1, loser);
                game.FindWinner(game.Players);
                string expected = string.Format($"{Environment.NewLine}Kyle: $200{Environment.NewLine}Mark: $200{Environment.NewLine}{Environment.NewLine}GG, Well Played All{Environment.NewLine}Tie game.{Environment.NewLine}");
                Assert.Equal(expected, sw.ToString());
            }
            ResetConsole();

        }

    }
}

