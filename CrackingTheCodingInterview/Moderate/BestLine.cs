using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrackingTheCodingInterview.Classes;

namespace CrackingTheCodingInterview.Moderate
{
    class BestLine : ISolution
    {
        Line Find(List<Coordinate> points)
        {
            var countOnLine = 0;
            var lineWithMost = new Line();
            foreach(var point1 in points)
            {
                foreach (var point2 in points.Where(p => p != point1))
                {
                    var line = new Line(point1, point2);
                    var countOnThisLine = 0;
                    foreach(var pointToTest in points.Where(p => p != point1 && p != point2))
                    {
                        if (line.IsOn(pointToTest))
                        {
                            countOnThisLine++;
                        }
                    }
                    if(countOnLine < countOnThisLine)
                    {
                        countOnLine = countOnThisLine;
                        lineWithMost = line;
                    }
                }
            }
            return lineWithMost;
        }

        public void Test()
        {
            List<Coordinate> points = new List<Coordinate>()
            {
                new Coordinate(1,1),
                new Coordinate(0,0),
                new Coordinate(1,2),
                new Coordinate(2,4),
                new Coordinate(3,6),
                new Coordinate(-1,-1)
            };
            var line = Find(points);
            Assert.That(line.Start.X == 0);
            Assert.That(line.Start.Y == 0);
            Assert.That(line.End.X == 3);
            Assert.That(line.End.Y == 6);
            points.Add(new Coordinate(-2, -2));
            points.Add(new Coordinate(-3, -3));
            points.Add(new Coordinate(-4, -4));
            line = Find(points);
            Assert.That(line.Start.X == -4);
            Assert.That(line.Start.Y == -4);
            Assert.That(line.End.X == 1);
            Assert.That(line.End.Y == 1);


        }
    }
}
