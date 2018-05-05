using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class AddWithoutPlus : ISolution
    {
        int Add(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }
            int sum = a ^ b;
            int carry = (a & b) << 1;
            return Add(sum, carry);
        }
        public void Test()
        {
            Assert.That(Add(1, 2) == 3);
            Assert.That(Add(5, 2) == 7);
        }
    }
}
