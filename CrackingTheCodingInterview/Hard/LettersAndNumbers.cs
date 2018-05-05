using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class LettersAndNumbers : ISolution
    {
        string Find(List<char> array)
        {
            var longest = new List<char>();
            for(int i = 0; i < array.Count(); i++)
            {
                for(int j = i; j < array.Count(); j++)
                {
                    List<char> arrayToTest = new List<char>();
                    for (int k = i; k <= j; k++)
                    {
                        arrayToTest.Add(array[k]);
                    }
                    var numbersNumbers = NumberNumbers(arrayToTest);
                    if (numbersNumbers == (arrayToTest.Count() - numbersNumbers))
                    {
                        if(arrayToTest.Count() > longest.Count())
                        {
                            longest = arrayToTest;
                        }
                    }
                }
            }
            return string.Join("", longest);
        }
        int NumberNumbers(List<char> array)
        {
            int count = 0;
            foreach(var obj in array)
            {
                int notUsed;
                if(int.TryParse(obj.ToString(), out notUsed))
                {
                    count++;
                }
            }
            return count;
        }
        public void Test()
        {
            List<char> array = new List<char>()
            {
                'A', '1', 'A', '1', '1', '1', '1', 'A', 'A'
            };
            Assert.That(Find(array) == "A1A1");
            array.Add('A');
            Assert.That(Find(array) == "A1A1111AAA");
            array = new List<char>()
            {
                'A','A','A','1','1','A','A','A'
            };
            Assert.That(Find(array) == "AA11");
        }
    }
}
