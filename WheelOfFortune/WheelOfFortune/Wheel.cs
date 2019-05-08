using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    public class Wheel
    {
        public Object[] values = new object[4];
        public Wheel(int factor)
        {
            for (var i = 0; i < 2; i++) {
                values[i] = (100* (i+1)) * factor;
            }

            values[2] = "Bankrupt";
            values[3] = "Lose a Turn";
            
        }
    }
}
