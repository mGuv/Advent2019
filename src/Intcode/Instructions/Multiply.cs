namespace Advent2019.Intcode.Instructions
{
    public class Multiply : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            int b = memory.Read(startingIndex + 2, command.GetParameterMode(2));
            int c = memory.GetAtAddress(startingIndex + 3);
            
            memory.Write(c, a * b);
            
            return startingIndex + 4;
        }
    }
}