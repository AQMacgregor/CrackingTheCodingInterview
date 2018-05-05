using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class NumberOfNinM : ISolution
    {
        int Find(int n, int m)
        {
            int found = 0;
            while(m != 0)
            {
                if(m % 10 == n)
                {
                    found++;
                }
                m /= 10;
            }
            return found;
        }
        public void Test()
        {
            Assert.That(Find(2, 222) == 3);
            Assert.That(Find(2, 515) == 0);
            Assert.That(Find(2, 123) == 1);
        }
    }
}
