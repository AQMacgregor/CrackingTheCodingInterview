using CrackingTheCodingInterview.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class Intersection : ISolution
    {
        // Given two straight line segments (represented as a start point and an end point)
        // compute the point of intersection, if any.
        Coordinate FindIntersection(Line line1, Line line2)
        {
            // lines are either the same or dont intersect
            if (line1.GetSlope() == line2.GetSlope())
            {
                if(line1.GetYIntercept() == line2.GetYIntercept())
                {
                    return line1.Start;
                }
                return null;
            }
            else
            {
                var xIntersect = (line2.GetYIntercept() - line1.GetYIntercept()) / (line1.GetSlope() - line2.GetSlope());
                var yIntersect = (xIntersect * line1.GetSlope()) + line1.GetYIntercept();
                var intersectPoint = new Coordinate(xIntersect, yIntersect);
                return line1.IsOn(intersectPoint) && line2.IsOn(intersectPoint) ? intersectPoint : null;
            }
        }
        public void Test()
        {
            {
                var line1 = new Line(new Coordinate(0, 0), new Coordinate(1, 1));
                Assert.That(line1.GetSlope() == 1);
                var line2 = new Line(new Coordinate(0, 1), new Coordinate(1, 0));
                Assert.That(line2.GetSlope() == -1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection.X == 0.5);
                Assert.That(intersection.Y == 0.5);
            }
            {
                var line1 = new Line(new Coordinate(0, 0), new Coordinate(1, 1));
                Assert.That(line1.GetSlope() == 1);
                var line2 = new Line(new Coordinate(0, 2), new Coordinate(1,1));
                Assert.That(line2.GetSlope() == -1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection.X == 1);
                Assert.That(intersection.Y == 1);
            }

            {
                var line1 = new Line(new Coordinate(0, 0), new Coordinate(1, 1));
                Assert.That(line1.GetSlope() == 1);
                var line2 = new Line(new Coordinate(0, 3), new Coordinate(2, 1));
                Assert.That(line2.GetSlope() == -1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection == null);
            }

            {
                var line1 = new Line(new Coordinate(0, 0), new Coordinate(2, 0));
                Assert.That(line1.GetSlope() == 0);
                var line2 = new Line(new Coordinate(0, -1), new Coordinate(2, 1));
                Assert.That(line2.GetSlope() == 1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection.X == 1);
                Assert.That(intersection.Y == 0);
            }
            {
                var line1 = new Line(new Coordinate(0, 0), new Coordinate(0, 2));
                Assert.That(double.IsInfinity(line1.GetSlope()));
                var line2 = new Line(new Coordinate(-1, 0), new Coordinate(1, 2));
                Assert.That(line2.GetSlope() == 1);
                //var intersection = FindIntersection(line1, line2);
                //Assert.That(intersection.X == 0);
                //Assert.That(intersection.Y == 1);
            }
        }
    }
}
