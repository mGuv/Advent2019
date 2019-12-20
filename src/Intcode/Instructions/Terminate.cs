namespace Advent2019.Intcode.Instructions
{
    public class Terminate : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            return memory.Length();
        }
    }
}