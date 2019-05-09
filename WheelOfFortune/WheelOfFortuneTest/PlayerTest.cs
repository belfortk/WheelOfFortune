using System;
using Xunit;
using WheelOfFortune;


namespace WheelOfFortuneTest
{
    public class PlayerTest
    {
        private Player player = new Player("Kyle");

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal("Kyle", this.player.Name);
            Assert.Equal(0, this.player.Bank);
            Assert.Equal(0, this.player.RoundMoney);
        }


        [Fact]
        public void SpinTest() {
            Assert.InRange<int>(this.player.Spin(), 0, 15);
        }


        [Fact]
        public void addMoneyToBankTest() {
            this.player.AddMoneyToBank(100);
            Assert.Equal(100, this.player.Bank);
        }

        [Fact]
        public void addRoundMoneyTest() {
            this.player.AddRoundMoney(300);
            Assert.Equal(300, this.player.RoundMoney);
        }
 
        [Fact]
        public void ResetRoundMoneyTest() {
            this.player.ResetRoundMoney();
            Assert.Equal(0, this.player.RoundMoney);
        }

        [Fact]
        public void SolveTest() {
            Assert.True(this.player.Solve("microsoft", "microsoft"));
            Assert.False(this.player.Solve("microsoft", "software"));
        }

        [Fact]
        public void GuessTest() {
            var answer = "hello";
            char[] state = new char[answer.Length];
            for (var i = 0; i < state.Length; i++)
            {
                state[i] = '_';
            }
            Assert.Equal("h _ _ _ _", this.player.Guess('h', answer, state, 200));
            Assert.Equal("h e _ _ _", this.player.Guess('e', answer, state, 400));
            Assert.Equal("Incorrect guess", this.player.Guess('m', answer, state, 300));
        }
    }
}
