using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace Advent2019.Problems.Day18
{
    public class PathNode
    {
        public Point Location;
        public int Steps;
        public HashSet<char> Keys = new HashSet<char>();
        public HashSet<Point> closedSet = new HashSet<Point>();

        public PathNode(Point location, int steps)
        {
            this.Location = location;
            this.Steps = steps;
        }

        public PathNode(Point location, int steps, HashSet<char> keys, HashSet<Point> closedSet)
        {
            this.Location = location;
            this.Steps = steps;
            char[] keysRaw = new char[keys.Count];
            keys.CopyTo(keysRaw);
            this.Keys = new HashSet<char>(keysRaw);

            Point[] points = new Point[closedSet.Count];
            closedSet.CopyTo(points);
            this.closedSet = new HashSet<Point>(points);
        }
    }
}
