using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class ContiguousSequence : ISolution
    {
        List<int> Find(List<int> numbers)
        {
            List<int> res = new List<int>();
            for(int i = 0; i < numbers.Count; i++)
            {
                for(int j = numbers.Count - 1; j > i; j--)
                {
                    List<int> subSet = new List<int>();
                    for(int k = i; k < j; k++)
                    {
                        subSet.Add(numbers[k]);
                    }
                    if(subSet.Sum() > res.Sum())
                    {
                        res = subSet;
                    }
                }
            }
            return res;
        }
        
        public void Test()
        {
            var numbers = new List<int>
            {
                2,-8,3,-2,4,-10
            };
            var res = Find(numbers);
            Assert.That(res[0] == 3);
            Assert.That(res[1] == -2);
            Assert.That(res[2] == 4);
        }
    }
}
