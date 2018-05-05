using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class MissingNumber : ISolution
    {
        int Find(List<int> numbers)
        {
            for(int i = 0; i < numbers.Count; i++)
            {
                for(int j = 0; j< 32; j++)
                {
                    if(GetBit(i, j) != GetBit(numbers[i], j))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        int GetBit(int number, int bitNumber)
        {
            return Convert.ToInt16((number & (1 << bitNumber - 1)) != 0);
        }
        public void Test()
        {
            List<int> numbers = new List<int>()
            {
                0,1,2,3,4,6
            };
            Assert.That(Find(numbers) == 5);
            numbers.Add(5);
            numbers.Sort();
            Assert.That(Find(numbers) == -1);

        }
    }
}
