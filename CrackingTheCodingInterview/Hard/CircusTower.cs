using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Hard
{
    class CircusTower : ISolution
    {
        class Person
        {
            public Person()
            {
                Height = 0;
                Weight = 0;
            }
            public int Height;
            public int Weight;
            public Person(int height, int weight)
            {
                Height = height;
                Weight = weight;
            }
        }
        List<Person> Make(List<Person> people)
        {
            var returnList = new List<Person>();
            Person smallest = null;
            foreach(var person in people)
            {
                if(smallest == null || (person.Height < smallest.Height && person.Weight < smallest.Weight))
                {
                    smallest = person;
                }
            }
            if (smallest != null)
            {
                returnList.Add(smallest);
                people.Remove(smallest);
                var nextLevel = Make(people);
                returnList.AddRange(nextLevel);
            }
            return returnList;
        }
        public void Test()
        {
            List<Person> people = new List<Person>()
            {
                new Person(65,100),
                new Person(70,150),
                new Person(56,90),
                new Person(75,190),
                new Person(60,95),
                new Person(68,110)
            };
            var tower = Make(people);
            Assert.That(tower.Count() == 6);
            Assert.That(tower[0].Height == 56);
            Assert.That(tower[0].Weight == 90);
            Assert.That(tower[1].Height == 60);
            Assert.That(tower[1].Weight == 95);
            Assert.That(tower[2].Height == 65);
            Assert.That(tower[2].Weight == 100);
            Assert.That(tower[3].Height == 68);
            Assert.That(tower[3].Weight == 110);
            Assert.That(tower[4].Height == 70);
            Assert.That(tower[4].Weight == 150);
            Assert.That(tower[5].Height == 75);
            Assert.That(tower[5].Weight == 190);

        }
    }
}
