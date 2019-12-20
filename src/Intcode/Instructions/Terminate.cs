using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class Terminate : IInstruction
    {
        public Task<int> RunAsync(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            return Task.FromResult(memory.Length());
        }
    }
}