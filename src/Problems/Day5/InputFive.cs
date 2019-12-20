using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day5
{
    public class InputFive : IInput
    {
        public Task<int> GetNextAsync()
        {
            return Task.FromResult(5);
        }
    }
}