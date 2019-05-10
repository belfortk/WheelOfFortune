using System;
using Xunit;
using System.Collections.Generic;
using WheelOfFortune;


namespace WheelOfFortuneTest
{
    public class TurnTest
    {
        private static char[] state = new char[3] { 'c', '_', 't' };
        private Turn _turn = new Turn("cat", state, new Player("Kyle"), new HashSet<char>(), new Wheel(1));

        [Fact]
        public void ConstructorTest() {
            var turn = new Turn("cat", state, new Player("Kyle"), new HashSet<char>(), new Wheel(1));
            Assert.Equal("cat", turn.Answer);
            Assert.Equal("Kyle", turn.Player.Name);
            Assert.Equal(new char[3] {'c', '_', 't' }, turn.CharacterState);
        }

        [Fact]
        public void DisplayCharacterStateTest() {
            Assert.Equal("c _ t", this._turn.DisplayCharacterState(TurnTest.state));
        }


    }
}

