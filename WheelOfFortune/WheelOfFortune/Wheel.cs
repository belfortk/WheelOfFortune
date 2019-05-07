using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    public class Wheel
    {
        public Object[] values = new object[16];
        public Wheel(int factor)
        {
            for (var i = 0; i < 14; i++) {
                values[i] = (100* (i+1)) * factor;
            }

            values[14] = "Bankrupt";
            values[15] = "Lose a Turn";
            
        }
    }
}
