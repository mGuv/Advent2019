using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class JumpIfFalse : IInstruction
    {
        public Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output)
        {
            long a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            if (a == 0)
            {
                return Task.FromResult(memory.Read(startingIndex + 2, command.GetParameterMode(2)));
            }

            return Task.FromResult(startingIndex + 3);
        }
    }
}