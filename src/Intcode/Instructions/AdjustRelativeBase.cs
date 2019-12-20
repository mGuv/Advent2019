using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class AdjustRelativeBase : IInstruction
    {
        public Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output)
        {
            long a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            
            memory.AdjustRelativeBase(a);

            return Task.FromResult(startingIndex + 2);
        }
    }
}