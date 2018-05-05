using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Other
{
    class BitStuff : ISolution
    {
        public void Test()
        {
            Assert.That(ReverseHash("Alex") == ReverseHash("xelA"));
        }
        int ReverseHash(string text)
        {
            return text.GetHashCode() + string.Join("", text.Reverse()).GetHashCode();
        }
    }
}
