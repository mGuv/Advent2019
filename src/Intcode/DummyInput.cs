using System.Threading.Tasks;

namespace Advent2019.Intcode
{
    public class DummyInput : IInput
    {
        public Task<long> GetNextAsync()
        {
            return Task.FromResult((long)0);
        }
    }
}