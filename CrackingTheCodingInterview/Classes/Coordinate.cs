using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Classes
{
    public class Coordinate : ISolution
    {
        public Coordinate() { }
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X;
        public double Y;

        public void Test()
        {
            var c1 = new Coordinate(5, 5);
            var c2 = new Coordinate(5, 5);
            var c3 = new Coordinate(5, 6);
            Assert.That(c1 != c2);
            Assert.That(c1 != c3);
            Assert.That(c1.SameAs(c2));
            Assert.That(c2.SameAs(c1));
            Assert.That(!c1.SameAs(c3));
        }
        public bool SameAs(Coordinate c)
        {
            return c != null && c.X == X && c.Y == Y;
        }

    }
}
