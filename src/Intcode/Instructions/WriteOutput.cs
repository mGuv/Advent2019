using System;

namespace Advent2019.Intcode.Instructions
{
    public class WriteOutput : IInstruction
    {
        public int Run(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
        {
            int value = memory.Read(startingIndex + 1, command.GetParameterMode(1));
            output.Write(value);

            return startingIndex + 2;
        }
    }
}