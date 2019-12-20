using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public class Add : IInstruction
    {
        public Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output)
        {
            long a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            long b = memory.Read(startingIndex + 2, command.GetParameterMode(2));
            long c = memory.GetIndex(startingIndex + 3, command.GetParameterMode(3));

            memory.Write(c, a + b);
            
            return Task.FromResult(startingIndex + 4);
        }
    }
}