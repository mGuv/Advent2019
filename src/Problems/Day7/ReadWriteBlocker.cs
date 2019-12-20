using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day7
{
    public class ReadWriteBlocker : IInput, IOutput
    {
        private Queue<int> values;
        private SemaphoreSlim gate;

        public ReadWriteBlocker()
        {
            this.values = new Queue<int>();
            this.gate = new SemaphoreSlim(0);
        }
        public async Task<int> GetNextAsync()
        {
            await this.gate.WaitAsync();
            return this.values.Dequeue();
        }

        public Task WriteAsync(int value)
        {
            this.values.Enqueue(value);
            this.gate.Release();
            return Task.CompletedTask;
        }
    }
}