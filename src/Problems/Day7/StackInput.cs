using System.Collections.Generic;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day7
{
    public class StackInput : IInput
    {
        private Stack<int> inputs = new Stack<int>();

        public Task<int> GetNextAsync()
        {
            return Task.FromResult(inputs.Pop());
        }

        public void Push(int value)
        {
            this.inputs.Push(value);
        }

        public void Reset()
        {
            this.inputs.Clear();
        }
    }
}