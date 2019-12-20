using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class LessThan : IInstruction
    {
        public Task<int> RunAsync(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            int b = memory.Read(startingIndex + 2, command.GetParameterMode(2));
            int address = memory.GetAtAddress(startingIndex + 3);

            if (a < b)
            {
                memory.Write(address, 1);
            }
            else
            {
                memory.Write(address, 0);
            }

            return Task.FromResult(startingIndex + 4);
        }
    }
}