namespace Advent2019.Intcode.Instructions
{
    public interface IInstruction
    { 
        int Run(Memory memory, int startingIndex, Command command);
    }
}