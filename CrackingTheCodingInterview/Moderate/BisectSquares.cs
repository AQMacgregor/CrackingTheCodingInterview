using CrackingTheCodingInterview.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class BisectSquares : ISolution
    {
        Line Bisect(Square s1, Square s2)
        {
            if (s1.BottomLeft.Y > s2.BottomLeft.Y)
            {
                return Bisect(s2, s1);
            }
            else
            {
                Line centerToCenter = new Line(s1.FindCenter(), s2.FindCenter());
                double lineSlope = centerToCenter.GetSlope();
                double startingX;
                double endingX;
                double startingY;
                double endingY;
                if (lineSlope < 1)
                {
                    startingX = s1.BottomLeft.X;
                    endingX = s2.TopRight.X;
                    startingY = centerToCenter.Start.Y -  (centerToCenter.Start.X- startingX)  * lineSlope;
                    endingY = centerToCenter.End.Y +  (endingX - centerToCenter.End.X)  * lineSlope;
                }
                else
                {
                    startingY = s1.BottomLeft.Y;
                    endingY = s2.TopRight.Y;
                    startingX = centerToCenter.Start.X - (centerToCenter.Start.Y - startingY) * lineSlope;
                    endingX = centerToCenter.End.X + (endingY - centerToCenter.End.Y) * lineSlope;
                }
                return new Line(new Coordinate(startingX, startingY), new Coordinate(endingX, endingY));
            }

        }
        public void Test()
        {
            var s1 = new Square(new Coordinate(1, 0), new Coordinate(2, 1));
            var center = s1.FindCenter();
            Assert.That(center.X == 1.5);
            Assert.That(center.Y == 0.5);
            var s2 = new Square(new Coordinate(3, 1), new Coordinate(4, 2));
            center = s2.FindCenter();
            Assert.That(center.X == 3.5);
            Assert.That(center.Y == 1.5);
            var line = Bisect(s1, s2);
            Assert.That(line.Start.X == 1);
            Assert.That(line.Start.Y == 0.25);
            Assert.That(line.End.X == 4);
            Assert.That(line.End.Y == 1.75);

        }
    }
}
