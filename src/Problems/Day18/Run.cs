using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Advent2019.Problems.Day18
{
    public class Run
    {
        public Point Start;
        public HashSet<char> Keys;
        public int StepsSoFar;

        public Run(Point location, int steps, HashSet<char> keys)
        {
            this.Start = location;
            this.StepsSoFar = steps;
            char[] keysRaw = new char[keys.Count];
            keys.CopyTo(keysRaw);
            this.Keys = new HashSet<char>(keysRaw);
        }

        public override int GetHashCode()
        {
            return this.Start.X <<
                   16 + this.Start.Y + string.Concat(this.Keys.OrderBy(c => c)).GetHashCode() + StepsSoFar;
        }

        public bool Equals(Run run)
        {
            return run.Start.Equals(this.Start) && string.Concat(this.Keys.OrderBy(c => c)) == string.Concat(run.Keys.OrderBy(c => c)) && this.StepsSoFar == run.StepsSoFar;
        }

        public override bool Equals(object obj)
        {
            if (obj is Run)
            {
                return this.Equals((Run) obj);
            }

            return false;
        }
    }
}
