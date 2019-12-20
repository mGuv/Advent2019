namespace Advent2019.Intcode.Instructions
{
    public class Terminate : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command)
        {
            return memory.Length();
        }
    }
}