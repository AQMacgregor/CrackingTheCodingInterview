using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class EnglishInt : ISolution
    {
        Dictionary<int, string> Numbers = new Dictionary<int, string>() {
            { 1, "One" },
            {2 , "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Eleven" },
            {12, "Twelve" },
            {13, "Thirteen" },
            {14, "Fourteen" },
            {15, "Fifteen" },
            {16, "Sixteen" },
            {17, "Seventeen" },
            {18,"Eighteen" },
            {19, "Nineteen" },
            {20, "Twentie" },
            {30,"Thirty" },
            {40, "Fourty" },
            {50, "Fifty" },
            {60, "Sixty" },
            {70, "Seventy" },
            {80, "Eighty" },
            {90, "Ninety" },
            {100, "Hundred" },
            {1000, "Thousand" },
            {100000, "Million" },
        };
        string ToEnglish(int number)
        {
            var words = ToEnglishImp(number);
            return String.Join(" ", words).Replace(" ,", ",");
        }
        List<string> ToEnglishImp(int number, bool addJoin = false)
        {
            List<string> words = new List<string>();
            if(number == 0)
            {
                // Do nothing
            }
            else if (number < 21)
            {
                words.Add(Numbers[number]);
            }
            else if(number < 100)
            {
                if (addJoin)
                {
                    words.Add("and");
                }
                words.Add(Numbers[(number / 10) * 10]);
                words.AddRange(ToEnglishImp(number % 10));
            }
            else if(number < 1000)
            {
                if (addJoin)
                {
                    words.Add(",");
                }
                words.AddRange(ToEnglishImp((number / 100)));
                words.Add(Numbers[100]);
                words.AddRange(ToEnglishImp((number % 100), true));
            }
            else if (number < 1000000)
            {
                if (addJoin)
                {
                    words.Add(",");
                }
                words.AddRange(ToEnglishImp((number / 1000)));
                words.Add(Numbers[1000]);
                words.AddRange(ToEnglishImp(number % 1000, true));
            }
            else if (number < 100000000)
            {
                if (addJoin)
                {
                    words.Add(",");
                }
                words.AddRange(ToEnglishImp((number / 1000000)));
                words.Add(Numbers[100000]);
                words.AddRange(ToEnglishImp(number % 1000000, true));
            }

            return words;

        }
        public void Test()
        {
            Assert.That(ToEnglish(1) == "One");
            Assert.That(ToEnglish(19) == "Nineteen");
            Assert.That(ToEnglish(99) == "Ninety Nine");
            Assert.That(ToEnglish(749) == "Seven Hundred and Fourty Nine");
            Assert.That(ToEnglish(7149) == "Seven Thousand, One Hundred and Fourty Nine");
            Assert.That(ToEnglish(60149) == "Sixty Thousand, One Hundred and Fourty Nine");
            Assert.That(ToEnglish(600149) == "Six Hundred Thousand, One Hundred and Fourty Nine");
            Assert.That(ToEnglish(6000149) == "Six Million, One Hundred and Fourty Nine");


        }
    }
}
