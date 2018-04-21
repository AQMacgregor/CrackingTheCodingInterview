using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class WordFrequencies : ISolution
    {
        Dictionary<string, int> m_book = new Dictionary<string, int>();
        string m_bookText = string.Empty;
        // Design a method to find the frequency of occurrences of any given word in a book. 
        // What if we were running this algorithm multiple times?
        public int FindFrequency(string word, string book)
        {
            if(m_bookText != book)
            {
                m_bookText = book;
                foreach(var workInBook in book.Split(' '))
                {
                    if(!m_book.ContainsKey(workInBook.ToUpper()))
                    {
                        m_book.Add(workInBook.ToUpper(), 0);
                    }
                    m_book[workInBook.ToUpper()]++;
                }
            }
            if (m_book.ContainsKey(word.ToUpper()))
            {
                return m_book[word.ToUpper()];
            }
            else
            {
                return 0;
            }
        }

        public void Test()
        {
            Assert.That(FindFrequency("the", "The quick brown fox jumped over the lazy dogs") == 2);
            Assert.That(FindFrequency("one", "The quick brown fox jumped over the lazy dogs") == 0);
            Assert.That(FindFrequency("quick", "The quick brown fox jumped over the lazy dogs") == 1);
        }
    }
}
