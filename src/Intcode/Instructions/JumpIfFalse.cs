namespace Advent2019.Intcode.Instructions
{
    public class JumpIfFalse : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int a = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            if (a == 0)
            {
                return memory.Read(startingIndex + 2, command.GetParameterMode(2));
            }

            return startingIndex + 3;
        }
    }
}