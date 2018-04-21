using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class Operations : ISolution
    {
        int Add(int a, int b)
        {
            return a + b;
        }
        int Subtract(int a, int b)
        {
            int subtract = 0;
            if(a < b)
            {
                for(; subtract + a < b; subtract++) { }
                subtract = -subtract;
            }
            else
            {
                for (; subtract + b < a; subtract++) { }
            }
            return subtract;
        }
        int Divide(int a, int b)
        {
            int divide = 0;
            if (b < a)
            {
                for (int i = 0; i < a; i += b)
                {
                    divide++;
                }
            }
            return divide;
        }
        int Times(int a, int b)
        {
            int times = 0;
            for(int i = 1; i <= a; i++)
            {
                for(int j = 1; j <= b;j++)
                {
                    times++;
                }
            }
            return times;
        }
        public void Test()
        {
            Assert.That(Add(1, 2) == 3);
            Assert.That(Add(2, 1) == 3);
            Assert.That(Subtract(1, 3) == -2);
            Assert.That(Subtract(3, 1) == 2);
            Assert.That(Divide(4, 2) == 2);
            Assert.That(Divide(2, 4) == 0);
            Assert.That(Times(2, 3) == 6);
            Assert.That(Times(3, 2) == 6);
        }
    }
}
