using System.Collections.Generic;
using System.Drawing;

namespace Advent2019.Problems.Day18
{
    public class PathNode
    {
        public Point Point;
        public int Steps;
        public float Heuristic;
        public Key KeysRequired;

        public PathNode(Point point, int steps, float heuristic, Key keysRequired)
        {
            Point = point;
            Steps = steps;
            Heuristic = heuristic;
            KeysRequired = keysRequired;
        }
    }
}
