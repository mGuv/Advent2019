using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class WriteOutput : IInstruction
    {
        public async Task<int> RunAsync(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int value = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            await output.WriteAsync(value);

            return startingIndex + 2;
        }
    }
}