using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    /// <summary>
    /// The main Wheel class.
    /// </summary>
    public class Wheel
    {
        /// <summary>
        /// Makes a new wheel with 16 prize values. 
        /// The last 2 are "Bankrupt" and "Lose Turn".
        /// The remaining values are (100 < x < 1400).
        /// The numerical prize values are multiplied by the factor provided
        /// </summary>
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
