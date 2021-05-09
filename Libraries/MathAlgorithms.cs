using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries
{
    public static class MathAlgorithms
    {
        public static int TrailingZeros(int n)
        {
            var sum = 0;
            var power = 5;
            while (n/power >= 1)
            {
                sum += (int)n / power;
                power *= 5; 
            }
            return sum;
        }
    }
}
