using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class LivingPeople : ISolution
    {

        class Person
        {
            public Person(int by, int dy) :
                this(new DateTime(by,01,01), new DateTime(dy,01,01))
            {

            }
            public Person(DateTime b, DateTime d)
            {
                Birth = b;
                Death = d;
            }
            public DateTime Birth;
            public DateTime Death;
        }
        int GetYear(List<Person> people)
        {
            Dictionary<int, int> alivePerYear = new Dictionary<int, int>();
            foreach(var person in people)
            {
                for (int i = person.Birth.Year; i <= person.Death.Year; i++)
                {
                    if (!alivePerYear.ContainsKey(i))
                    {
                        alivePerYear.Add(i, 0);
                    }
                    alivePerYear[i]++;
                }
            }
            return alivePerYear.OrderByDescending(y => y.Value).First().Key;
        }
        
        public void Test()
        {
            List<Person> people = new List<Person>()
            {
                new Person(1900, 1905),
                new Person(1901, 1905),
                new Person(1903, 1904),
                new Person(1904, 1904),
            };
            Assert.That(GetYear(people) == 1904);
        }
    }
}
