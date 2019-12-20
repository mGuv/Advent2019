using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day5
{
    public class RememberLastOutput : IOutput
    {
        private int lastOutput;
        
        public Task WriteAsync(int value)
        {
            this.lastOutput = value;
            return Task.CompletedTask;
        }

        public int GetLastOutput()
        {
            return this.lastOutput;
        }
    }
}