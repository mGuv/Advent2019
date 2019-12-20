using System.Collections.Generic;

namespace Advent2019.Problems.Day18
{
    public class KeyPath
    {
        public readonly int Steps;
        public readonly Key DoorsInWay;

        public KeyPath(int steps, Key doorsInWay)
        {
            Steps = steps;
            DoorsInWay = doorsInWay;
        }
    }
}
