using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Other
{
    class MinChange : ISolution
    {
        // 1, 20, 50, 100
        // input 170 -> output 3 (20 + 50 + 100)

        public List<int> coins = new List<int>() { 100, 50, 20, 1 };

        public Dictionary<int, int> cache = new Dictionary<int, int>();

        public int GetChange(int number)
        {
            return GetChangeImp(number, number);
        }

        public int GetChangeImp(int number, int minCoins)
        {
            if (number == 0)
            {
                return 0;
            }
            foreach (var coin in coins)
            {
                if (number >= coin)
                {
                    var newNumber = number - coin;
                    int coinsUsed;
                    if (!cache.ContainsKey(newNumber))
                    {
                        coinsUsed = GetChange(newNumber);
                        cache.Add(newNumber, coinsUsed);
                    }
                    else
                    {
                        coinsUsed = cache[newNumber];
                    }
                    coinsUsed = 1 + coinsUsed;
                    if (coinsUsed < minCoins)
                    {
                        minCoins = coinsUsed;
                    }
                }
            }
            return minCoins;
        }
        public void Test()
        {
            Assert.That(GetChange(0) == 0);
            Assert.That(GetChange(100) == 1);
            Assert.That(GetChange(50) == 1);
            Assert.That(GetChange(20) == 1);
            Assert.That(GetChange(1) == 1);
            Assert.That(GetChange(170) == 3);
        }
    }
}




// 1, 20, 50, 100
// input 170 -> output 3 (20 + 50 + 100)

//public list<int> coins = new List<int>() { 100, 50, 20, 1 };

//public Dictionary<int, int> cache = new Dictionary<int, int>();

//public int GetChange(int number, int minCoins)
//{
//    if (number == 0)
//    {
//        return 0;
//    }
//    foreach (var coin in coins)
//    {
//        if (number > coin)
//        {
//            var newNumber = number - coin;
//            var coinsUsed;
//            if (!cache.containsKey(newNumber))
//            {
//                coinsUsed = GetChange(newNumber);
//                cache.add(newNumber, coinsUsed);
//            }
//            else
//            {
//                coinsUsed = cache[newNumber];
//            }
//            coinsUsed = 1 + coinsUsed;
//            if (coinsUsed < minCoins)
//            {
//                minCoins = coinsUsed;
//            }
//            return coinsUsed
//        }
//    }
//}

//Unit tests
//170 
//0
//100, 50, 20, 1
//INT_MAX

// complexity
// exponential