using System;
using System.Collections.Generic;
using Advent2019.Intcode.Instructions;

namespace Advent2019.Intcode
{
    public class Computer
    {
        private readonly MemoryFactory memoryFactory;
        private readonly Dictionary<int, IInstruction> instructions;

        public Computer(MemoryFactory memoryFactory, Add addInstruction, Multiply multiplyInstruction, Terminate terminateInstruction)
        {
            this.memoryFactory = memoryFactory;

            instructions = new Dictionary<int, IInstruction>()
            {
                {1, addInstruction},
                {2, multiplyInstruction},
                {99, terminateInstruction}
            };
        }
        
        public Memory Run(string program, IInput input, IOutput output, Dictionary<int, int> overrides = null)
        {
            Memory memory = this.memoryFactory.Create(program);

            if (overrides != null)
            {
                foreach (KeyValuePair<int,int> keyValuePair in overrides)
                {
                    memory.Write(keyValuePair.Key, keyValuePair.Value);
                }
            }
            
            int currentIndex = 0;

            while (currentIndex < memory.Length())
            {
                Command nextCommand = new Command(memory.GetAtAddress(currentIndex));
                currentIndex = this.instructions[nextCommand.GetIntCode()].Run(memory, currentIndex, nextCommand, input, output);
            }

            return memory;
        }
    }
}