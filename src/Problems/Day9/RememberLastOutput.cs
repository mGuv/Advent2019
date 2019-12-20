using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day9
{
    public class RememberLastOutput : IOutput
    {
        private long lastOutput;
        
        public Task WriteAsync(long value)
        {
            this.lastOutput = value;
            return Task.CompletedTask;
        }

        public long GetLastOutput()
        {
            return this.lastOutput;
        }
    }
}