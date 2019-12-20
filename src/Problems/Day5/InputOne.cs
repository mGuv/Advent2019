using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day5
{
    public class InputOne : IInput
    {
        public Task<long> GetNextAsync()
        {
            return Task.FromResult((long)1);
        }
    }
}