using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class DivingBoard : ISolution
    {
        public List<int> MakeBoard(int currentLength, int shorter, int longer, int numberOfPlanks)
        {
            // O(2^numberOfPlanks)
            //List<int> lengths = new List<int>();
            //if (numberOfPlanks > 0)
            //{
            //    lengths.AddRange(MakeBoard(currentLength + shorter, shorter, longer, numberOfPlanks - 1));
            //    lengths.AddRange(MakeBoard(currentLength + longer, shorter, longer, numberOfPlanks - 1));
            //}
            //else
            //{
            //    lengths.Add(currentLength);
            //}
            //return lengths.Distinct().ToList();

            // O(numberOfPlanks)
            List<int> lengths = new List<int>();
            for(int i = 0; i <= numberOfPlanks; i++)
            {
                lengths.Add((i * shorter) + ((numberOfPlanks - i) * longer));
            }

            return lengths;

        }

        public void Test()
        {
            List<int> expected = new List<int>()
            {
                4,5,6,7,8
            };
            foreach(var board in MakeBoard(0, 1, 2, 4))
            {
                expected.Remove(board);
            }
            Assert.That(!expected.Any());
        }
    }
}
