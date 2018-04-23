using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class NumberMax : ISolution
    {
        int Max(int a, int b)
        {
            var aBigger = ((a - b) >> 31) + 1;
            var bBigger = ((b - a) >> 31) + 1;
            return a * aBigger + b * bBigger;
        }
        public void Test()
        {
            Assert.That(Max(0, 1) == 1);
            Assert.That(Max(2, 1) == 2);
            //Assert.That(Max(3, 3) == 3);
        }
    }
}
