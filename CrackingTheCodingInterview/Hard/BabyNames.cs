using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class BabyNames : ISolution
    {
        Dictionary<string, int> FindFrequency(Dictionary<string, int> frequencies, Dictionary<string, string> synonyms)
        {
            foreach (var pair in synonyms)
            {
                if (frequencies.ContainsKey(pair.Key))
                {
                    frequencies[pair.Key] += Check(frequencies, synonyms, pair.Value);
                }
            }
            return frequencies;
        }
        int Check(Dictionary<string, int> frequencies, Dictionary<string, string> synonyms, string name)
        {
            int returnValue = 0;
            if (synonyms.ContainsKey(name))
            {
                returnValue += Check(frequencies, synonyms, synonyms[name]);
            }
            if (frequencies.ContainsKey(name))
            {
                returnValue += frequencies[name];
                frequencies.Remove(name);
            }
            return returnValue;
        }
        public void Test()
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>()
            {
                {"John", 15 },
                {"Jon", 12 },
                {"Chris", 13 },
                {"Kris", 4 },
                {"Christopher", 19 },
            };
            Dictionary<string, string> synonyms = new Dictionary<string, string>()
            {
                {"Jon", "John" },
                {"John", "Johnny" },
                {"Chris", "Kris" },
                {"Kris", "Christopher" },
            };
            var freq = FindFrequency(frequencies, synonyms);
            Assert.That(freq.Count() == 2);
            Assert.That(freq.Values.Sum() == frequencies.Values.Sum());
        }
    }
}
