using System.Threading.Tasks;

namespace Advent2019.Intcode
{
    public class DummyOutput : IOutput
    {
        public Task WriteAsync(long value)
        {
            return Task.CompletedTask;
        }
    }
}