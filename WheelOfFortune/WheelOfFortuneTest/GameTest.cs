using System;
using Xunit;
using WheelOfFortune;


namespace WheelOfFortuneTest
{
    public class GameTest
    {
        private Game game = new Game(3, 3);

        [Fact]
        public void ConstructorTest() {
            
            Assert.Equal(3, game.NumberOfPlayers);
            Assert.Equal(3, game.Rounds);

        }

        [Fact]
        public void FindWinnerTest() {
            
        }


    }
}

