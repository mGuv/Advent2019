using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public interface IInstruction
    { 
        Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output);
    }
}