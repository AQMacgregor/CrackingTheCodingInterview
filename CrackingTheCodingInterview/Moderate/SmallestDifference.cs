using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class SmallestDifference : ISolution
    {
        int Run(List<int> firstList, List<int> secondList)
        {
            var smallest = int.MaxValue;
            foreach(var firstNumber in firstList)
            {
                foreach(var secondNumber in secondList)
                {
                    var dif = 0;
                    if(firstNumber < secondNumber)
                    {
                        dif = secondNumber - firstNumber;
                    }
                    else
                    {
                        dif = firstNumber - secondNumber;
                    }
                    if(dif < smallest)
                    {
                        smallest = dif;
                    }
                }

            }
            return smallest;
        }
        public void Test()
        {
            {
                var firstList = new List<int>()
                {
                    1,3,15,11,2
                };
                var secondList = new List<int>()
                {
                    23,127,235,19,8
                };
                Assert.That(Run(firstList, secondList) == 3);
            }
            {
                var firstList = new List<int>()
                {   
                    1,3,15,11,8
                };
                var secondList = new List<int>()
                {
                    23,127,235,19,8
                };
                Assert.That(Run(firstList, secondList) == 0);
            }
        }
    }
}
