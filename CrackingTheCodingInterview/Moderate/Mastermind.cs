using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class Mastermind : ISolution
    {
        class Responce
        {
            public int Hit = 0;
            public int PHit = 0;
        }
        Responce Play(string actual, string guess)
        {
            var responce = new Responce();
            List<int> correct = new List<int>();
            for(int i = 0; i < actual.Length; i ++)
            {
                if(actual[i] == guess[i])
                {
                    correct.Add(i);
                    responce.Hit++;
                }
            }
            foreach (var correctIndex in correct.OrderByDescending(i => i))
            {
                actual = actual.Remove(correctIndex, 1);
                guess = guess.Remove(correctIndex, 1);
            }
            foreach(var slot in actual.Distinct())
            {
                if (guess.Contains(slot))
                {
                    responce.PHit++;
                }
            }
            return responce;
        }
        
        public void Test()
        {
            var responce = Play("RGBY", "GGRR");
            Assert.That(responce.Hit == 1);
            Assert.That(responce.PHit == 1);
            responce = Play("YYYY", "YYYY");
            Assert.That(responce.Hit == 4);
            Assert.That(responce.PHit == 0);
            responce = Play("GGGG", "YYYY");
            Assert.That(responce.Hit == 0);
            Assert.That(responce.PHit == 0);
            responce = Play("GGYY", "YYGG");
            Assert.That(responce.Hit == 0);
            Assert.That(responce.PHit == 2);
        }
    }
}
