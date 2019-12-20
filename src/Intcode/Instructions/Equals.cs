namespace Advent2019.Intcode.Instructions
{
    public class Equals : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            int b = memory.Read(startingIndex + 2, command.GetParameterMode(2));
            int address = memory.GetAtAddress(startingIndex + 3);

            if (a == b)
            {
                memory.Write(address, 1);
            }
            else
            {
                memory.Write(address, 0);
            }

            return startingIndex + 4;
        }
    }
}