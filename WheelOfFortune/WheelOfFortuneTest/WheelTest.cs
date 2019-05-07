using System;
using Xunit;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    public class WheelTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var wheel = new Wheel(2);

            Assert.Equal(16, wheel.values.Length);
            Assert.Equal(200, wheel.values[0]);
            Assert.Equal("Bankrupt", wheel.values[14]);
            Assert.Equal("Lose a Turn", wheel.values[15]);
        }



    }
}

