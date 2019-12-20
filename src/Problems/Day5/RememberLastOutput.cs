using Advent2019.Intcode;

namespace Advent2019.Problems.Day5
{
    public class RememberLastOutput : IOutput
    {
        private int lastOutput;
        
        public void Write(int value)
        {
            this.lastOutput = value;
        }

        public int GetLastOutput()
        {
            return this.lastOutput;
        }
    }
}