using System.Collections.Generic;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day7
{
    public class StackInput : IInput
    {
        private Stack<long> inputs = new Stack<long>();

        public Task<long> GetNextAsync()
        {
            return Task.FromResult(inputs.Pop());
        }

        public void Push(long value)
        {
            this.inputs.Push(value);
        }

        public void Reset()
        {
            this.inputs.Clear();
        }
    }
}