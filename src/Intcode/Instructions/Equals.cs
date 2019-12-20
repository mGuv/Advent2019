using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class Equals : IInstruction
    {
        public Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output)
        {
            long a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            long b = memory.Read(startingIndex + 2, command.GetParameterMode(2));
            long address = memory.GetIndex(startingIndex + 3, command.GetParameterMode(3));

            if (a == b)
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