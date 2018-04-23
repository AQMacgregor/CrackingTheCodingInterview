using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class PatternMatching : ISolution
    {
        bool Matches(string pattern, string value)
        {
            pattern = pattern.ToUpper();
            value = value.ToLower();
            var patternOne = pattern[0];
            var patternTwo = patternOne == 'A' ? 'B' : 'A';
            for(int i = 0; i < value.Length; i++)
            {
                var maybeOne = value.Substring(0, i+1);
                var replaced = value.Replace(maybeOne, patternOne.ToString());
                var others = replaced.Split(patternOne).Distinct().Where(o => !string.IsNullOrEmpty(o));
                if (others.Count() == 1)
                {
                    var maybeTwo = others.Single();
                    if(value.Replace(maybeOne, patternOne.ToString()).Replace(maybeTwo, patternTwo.ToString()) == pattern)
                    {
                        return true;
                    }
                }
                else if(others.Count() == 0) 
                {
                    return true;
                }

            }
            return false;
        }
        public void Test()
        {
            Assert.That(Matches("aabab", "catcatgocatgo"));
            Assert.That(Matches("ab", "catcatgocatgo"));
            Assert.That(Matches("a", "catcatgocatgo"));
            Assert.That(Matches("b", "catcatgocatgo"));
            Assert.That(Matches("bb", "catcat"));
        }
    }
}
