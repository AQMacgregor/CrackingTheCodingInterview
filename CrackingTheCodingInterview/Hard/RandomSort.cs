using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class RandomSort : ISolution
    {
        Random rand = new Random();
        List<int> GetInts(List<int> n, int m)
        {
            List<int> returnList = new List<int>();
            while(returnList.Count() < m)
            {
                int index = (int)Math.Round(((rand.NextDouble() * n.Count()) + 0.5)) - 1;
                returnList.Add(n[index]);
                n.RemoveAt(index);
            }
            return returnList;
        }
        public void Test()
        {
            List<int> n = new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };
            var randList = GetInts(n, 2);
            Assert.That(randList.Count() == 2);
        }
    }
}
