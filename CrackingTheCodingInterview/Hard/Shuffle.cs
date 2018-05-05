using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class Shuffle : ISolution
    {
        Random rand = new Random();

        List<int> ShuffleDeck(List<int> cards)
        {
            List<int> newCards = new List<int>();
            var count = cards.Count;
            for (int i = 0; i < count; i++)
            {
                var randIndex = (int)Math.Round(((rand.NextDouble() * cards.Count()) + 0.5)) - 1;
                var randCard = cards[randIndex];
                cards.RemoveAt(randIndex);
                newCards.Add(randCard);
            }
            return newCards;
        }
        public void Test()
        {
            List<int> cards = new List<int>();
            for(int i = 0; i < 52; i++)
            {
                cards.Add(i + 1);
            }
            var shuffled = ShuffleDeck(cards);
        }
    }
}
