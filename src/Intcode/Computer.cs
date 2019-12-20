using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advent2019.Intcode.Instructions;

namespace Advent2019.Intcode
{
    public class Computer
    {
        private readonly MemoryFactory memoryFactory;
        private readonly Dictionary<int, IInstruction> instructions;

        public Computer(MemoryFactory memoryFactory, Add addInstruction, Multiply multiplyInstruction,
            Terminate terminateInstruction, WriteInput writeInstruction, WriteOutput outputInstruction,
            JumpIfTrue jumpIfTrueInstruction, JumpIfFalse jumpIfFalseInstruction, LessThan lessThanInstruction, Equals equalsInstruction, AdjustRelativeBase adjustRelativeBase)
        {
            this.memoryFactory = memoryFactory;

            instructions = new Dictionary<int, IInstruction>()
            {
                {1, addInstruction},
                {2, multiplyInstruction},
                {3, writeInstruction},
                {4, outputInstruction},
                {5, jumpIfTrueInstruction},
                {6, jumpIfFalseInstruction},
                {7,lessThanInstruction},
                {8, equalsInstruction},
                {9, adjustRelativeBase},
                {99, terminateInstruction}
            };
        }

        public async Task<Memory> RunAsync(string program, IInput input, IOutput output, Dictionary<long, long> overrides = null)
        {
            Memory memory = this.memoryFactory.Create(program);

            if (overrides != null)
            {
                foreach (KeyValuePair<long, long> keyValuePair in overrides)
                {
                    memory.Write(keyValuePair.Key, keyValuePair.Value);
                }
            }

            long currentIndex = 0;

            while (!memory.Terminated)
            {
                Command nextCommand = new Command(memory.GetAtAddress(currentIndex));
                currentIndex = await this.instructions[nextCommand.GetIntCode()]
                    .RunAsync(memory, currentIndex, nextCommand, input, output);
            }

            return memory;
        }
    }
}