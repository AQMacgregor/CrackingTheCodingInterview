using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class NumberSwapper : ISolution
    {
        // Write a function to swap a number in place (that is, without temporary variables)
        public void Swap(ref int a, ref int b)
        {
            if (a != b)
            {
                a = b - a;
                b = b - a;
                a = b + a;
            }
        }
        public void Test()
        {
            int a = 3;
            int b = 4;
            Swap(ref a, ref b);
            Assert.That(a == 4 && b == 3);
            Swap(ref a, ref b);
            Assert.That(a == 3 && b == 4);
            int c = 1;
            int d = 1;
            Assert.That(c == 1 && d == 1);
            int e = 5;
            Swap(ref e, ref e);
            Assert.That(e == 5);
        }
    }
}
