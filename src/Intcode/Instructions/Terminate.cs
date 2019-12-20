using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class Terminate : IInstruction
    {
        public Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output)
        {
            memory.Terminated = true;
            return Task.FromResult(startingIndex);
        }
    }
}