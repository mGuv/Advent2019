using System.Drawing;

namespace Advent2019.Problems.Day18
{
    public class Step
    {
        public Point Location;
        public int Steps;

        public Step(Point location, int steps)
        {
            this.Location = location;
            this.Steps = steps;
        }
    }
}
