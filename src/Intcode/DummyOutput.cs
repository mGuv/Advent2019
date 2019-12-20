using System.Threading.Tasks;

namespace Advent2019.Intcode
{
    public class DummyOutput : IOutput
    {
        public Task WriteAsync(int value)
        {
            return Task.CompletedTask;
        }
    }
}