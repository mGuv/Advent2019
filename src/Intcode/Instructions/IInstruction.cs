using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
{
    public interface IInstruction
    { 
        Task<int> RunAsync(Memory memory, int startingIndex, Command command, IInput input, IOutput output);
    }
}