using System;
using Xunit;
using WheelOfFortune;
using System.Collections.Generic;
using System.IO;

namespace WheelOfFortuneTest
{
    public class RoundTest
    {
        private void ResetConsole()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        private Round round = new Round("dog", new Player[] { new Player("Kyle") }, new Wheel(1));
        [Fact]
        public void ConstructorTest()
        {
            ResetConsole();
            var round = new Round("dog", new Player[] { new Player("Kyle") }, new Wheel(1));
            //var players = new Player[] { new Player("Kyle") };
            //Assert.Equal(round.Players, players);
            Assert.Equal("dog", round.Answer);
            Assert.Equal(new char[] { '_','_','_'}, round._characterState);
            Assert.Equal(new HashSet<char>(), round.previousGuesses);

        }

        [Fact]
        public void ResetAllPlayerRoundMoneyTest()
        {
            ResetConsole();

            Player player = round.Players[0];
            player.AddRoundMoney(200);
            Assert.Equal(200, player.RoundMoney);
            round.ResetAllPlayerRoundMoney();
            Assert.Equal(0, player.RoundMoney);
        }


    }
}

