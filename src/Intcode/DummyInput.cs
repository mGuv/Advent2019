using System.Threading.Tasks;

namespace Advent2019.Intcode
{
    public class DummyInput : IInput
    {
        public Task<int> GetNextAsync()
        {
            return Task.FromResult(0);
        }
    }
}