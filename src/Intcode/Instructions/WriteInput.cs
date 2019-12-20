namespace Advent2019.Intcode.Instructions
{
    public class WriteInput : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int value = input.GetNext();
            int address = memory.GetAtAddress(startingIndex + 1);
            
            memory.Write(address, value);

            return startingIndex + 2;
        }
    }
}