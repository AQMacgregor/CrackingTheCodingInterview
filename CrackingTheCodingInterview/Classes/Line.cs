using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Classes
{
    public class Line : ISolution
    {
        public Line() { }
        public Line(Coordinate s, Coordinate e)
        {
            if (s.Y <= e.Y)
            {
                Start = s;
                End = e;
            }
            else
            {
                End = s;
                Start = e;
            }
        }
        public Coordinate Start;
        public Coordinate End;
        public double GetSlope()
        {
            //dy/dx
            return (End.Y - Start.Y) / (End.X - Start.X);
        }
        public double GetYIntercept()
        {
            return End.Y - (GetSlope() * End.X);
        }
        public bool IsOn(Coordinate point)
        {
            if (point.SameAs(Start) || point.SameAs(End))
            {
                return true;
            }
            else
            {
                return (IsBetween(Start.X, point.X, End.X)
                    && IsBetween(Start.Y, point.Y, End.Y)
                    && new Line(Start, point).GetSlope() == new Line(point, End).GetSlope());
            }
        }
        private bool IsBetween(double start, double middle, double end)
        {
            if (start > end)
            {
                return end <= middle && middle <= start;
            }
            else
            {
                return start <= middle && middle <= end;
            }
        }

        public void Test()
        {
            var line = new Line(new Coordinate(0, 0), new Coordinate(1, 1));
            Assert.That(line.GetSlope() == 1);
            Assert.That(line.GetYIntercept() == 0);
            Assert.That(line.IsOn(new Coordinate(0.5, 0.5)));
            Assert.That(!line.IsOn(new Coordinate(1, 0)));
            line = new Line(new Coordinate(0, 0), new Coordinate(1, 2));
            Assert.That(line.GetSlope() == 2);
            Assert.That(line.GetYIntercept() == 0);
            Assert.That(line.IsOn(new Coordinate(1, 2)));
            Assert.That(!line.IsOn(new Coordinate(0.5, 0.5)));
            line = new Line(new Coordinate(0, 0), new Coordinate(2, 1));
            Assert.That(line.GetSlope() == 0.5);
            Assert.That(line.GetYIntercept() == 0);
            line = new Line(new Coordinate(1, 1), new Coordinate(0, 0));
            Assert.That(line.GetSlope() == 1);
            Assert.That(line.GetYIntercept() == 0);
            line = new Line(new Coordinate(1, 1), new Coordinate(3, 2));
            Assert.That(line.GetSlope() == 0.5);
            Assert.That(line.GetYIntercept() == 0.5);
        }
    }
}
