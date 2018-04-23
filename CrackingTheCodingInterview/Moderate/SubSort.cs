using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class SubSort : ISolution
    {
        class Pair
        {
            public int N;
            public int M;
        }

        Pair FindSub(List<int> numbers)
        {
            var pair = new Pair();
            for (int i = 0; i < numbers.Count; i++)
            {
                var smaller = false;
                for (int j = i; j < numbers.Count; j++)
                {
                    if(numbers[i] > numbers[j])
                    {
                        smaller = true;
                        break;
                    }
                }
                if (smaller)
                {
                    pair.M = i;
                    break;
                }
            }
            for (int i = numbers.Count -1; i > pair.M; i--)
            {
                var larger = false;
                for (int j = numbers.Count - 1; j > i; j--)
                {
                    if (numbers[i] > numbers[j])
                    {
                        larger = true;
                        pair.N = j;
                        break;
                    }
                }
                if (larger)
                {
                    break;
                }
            }
            return pair;
        }

        public void Test()
        {
            var list = new List<int>()
            {
                1,2,4,7,10,11,7,12,6,7,16,18,19
            };
            var pair = FindSub(list);
            Assert.That(pair.M == 3);
            Assert.That(pair.N == 9);

            list = new List<int>()
            {
                1,2,4,7,10,11
            };
            pair = FindSub(list);
            Assert.That(pair.M == 0);
            Assert.That(pair.N == 0);

            list = new List<int>()
            {
                2,2,4,7,10,11,1
            };
            pair = FindSub(list);
            Assert.That(pair.M == 0);
            Assert.That(pair.N == 6);
        }
    }
}
