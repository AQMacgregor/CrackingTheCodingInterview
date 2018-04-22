using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Classes
{
    public class Square : ISolution
    {
        public Square() { }
        public Square(Coordinate bl, Coordinate tr)
        {
            BottomLeft = bl;
            TopRight = tr;
        }
        public Coordinate BottomLeft;
        public Coordinate TopRight;
        public Coordinate FindCenter()
        {
            return new Coordinate(BottomLeft.X + (TopRight.X - BottomLeft.X) / 2, BottomLeft.Y + (TopRight.Y - BottomLeft.Y) / 2);
        }

        public void Test()
        {
            var square = new Square(new Coordinate(0, 0), new Coordinate(1, 1));
            Assert.That(square.FindCenter().X == 0.5);
            Assert.That(square.FindCenter().Y == 0.5);
        }
    }
}
