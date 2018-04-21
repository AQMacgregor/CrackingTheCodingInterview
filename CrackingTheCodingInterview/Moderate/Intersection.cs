using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class Intersection : ISolution
    {
        class Point
        {
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
            public double X { get; private set; }
            public double Y { get; private set; }
        }
        class Line
        {
            public Line(Point s, Point e)
            {
                // Swap the points over to make the lowest one the start
                if (s.Y <= e.Y)
                {
                    StartPoint = s;
                    EndPoint = e;
                }
                else
                {
                    StartPoint = e;
                    EndPoint = s;
                }
            }
            public Point StartPoint { get; private set; }
            public Point EndPoint { get; private set; }

            public double GetSlope()
            {
                // todo fix div 0
                return (EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X);
            }
            public double GetYIntercept()
            {
                return EndPoint.Y - (GetSlope() * EndPoint.X);
            }
            public bool IsOn(Point point)
            {
                return (IsBetween( StartPoint.X, point.X, EndPoint.X)
                    && IsBetween(StartPoint.Y, point.Y, EndPoint.Y));
            }
            private bool IsBetween(double start, double middle, double end)
            {
                if(start > end)
                {
                    return end <= middle && middle <= start;
                }
                else
                {
                    return start <= middle && middle <= end;
                }
            }
        }
        // Given two straight line segments (represented as a start point and an end point)
        // compute the point of intersection, if any.
        Point FindIntersection(Line line1, Line line2)
        {
            // lines are either the same or done intersect
            if (line1.GetSlope() == line2.GetSlope())
            {
                if(line1.GetYIntercept() == line2.GetYIntercept())
                {
                    return line1.StartPoint;
                }
                return null;
            }
            else
            {
                var xIntersect = (line2.GetYIntercept() - line1.GetYIntercept()) / (line1.GetSlope() - line2.GetSlope());
                var yIntersect = (xIntersect * line1.GetSlope()) + line1.GetYIntercept();
                var intersectPoint = new Point(xIntersect, yIntersect);
                return line1.IsOn(intersectPoint) && line2.IsOn(intersectPoint) ? intersectPoint : null;
            }
        }
        public void Test()
        {
            {
                var line1 = new Line(new Point(0, 0), new Point(1, 1));
                Assert.That(line1.GetSlope() == 1);
                var line2 = new Line(new Point(0, 1), new Point(1, 0));
                Assert.That(line2.GetSlope() == -1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection.X == 0.5);
                Assert.That(intersection.Y == 0.5);
            }
            {
                var line1 = new Line(new Point(0, 0), new Point(1, 1));
                Assert.That(line1.GetSlope() == 1);
                var line2 = new Line(new Point(0, 2), new Point(1,1));
                Assert.That(line2.GetSlope() == -1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection.X == 1);
                Assert.That(intersection.Y == 1);
            }

            {
                var line1 = new Line(new Point(0, 0), new Point(1, 1));
                Assert.That(line1.GetSlope() == 1);
                var line2 = new Line(new Point(0, 3), new Point(2, 1));
                Assert.That(line2.GetSlope() == -1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection == null);
            }

            {
                var line1 = new Line(new Point(0, 0), new Point(2, 0));
                Assert.That(line1.GetSlope() == 0);
                var line2 = new Line(new Point(0, -1), new Point(2, 1));
                Assert.That(line2.GetSlope() == 1);
                var intersection = FindIntersection(line1, line2);
                Assert.That(intersection.X == 1);
                Assert.That(intersection.Y == 0);
            }
            {
                var line1 = new Line(new Point(0, 0), new Point(0, 2));
                Assert.That(double.IsInfinity(line1.GetSlope()));
                var line2 = new Line(new Point(-1, 0), new Point(1, 2));
                Assert.That(line2.GetSlope() == 1);
                //var intersection = FindIntersection(line1, line2);
                //Assert.That(intersection.X == 0);
                //Assert.That(intersection.Y == 1);
            }
        }
    }
}
