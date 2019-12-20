using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day7
{
    public class ReadWriteBlocker : IInput, IOutput
    {
        private Queue<long> values;
        private SemaphoreSlim gate;

        public ReadWriteBlocker()
        {
            this.values = new Queue<long>();
            this.gate = new SemaphoreSlim(0);
        }
        public async Task<long> GetNextAsync()
        {
            await this.gate.WaitAsync();
            return this.values.Dequeue();
        }

        public Task WriteAsync(long value)
        {
            this.values.Enqueue(value);
            this.gate.Release();
            return Task.CompletedTask;
        }
    }
}