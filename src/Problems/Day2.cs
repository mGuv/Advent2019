using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems
{
    public class Day2 : IProblem
    {
        public int Day => 2;
        public string Title => "1202 Program Alarm";
        public string Part1Title => "Gravity Assist Program";
        public string Part2Title => "Gravity Assist around the Moon";

        private Computer computer;
        private IInput computerInput;
        private IOutput computerOutput;

        public Day2(Computer computer, DummyInput dummyInput, DummyOutput dummyOutput)
        {
            this.computer = computer;
            this.computerInput = dummyInput;
            this.computerOutput = dummyOutput;
        }
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();

            Dictionary<int, int> overrides = new Dictionary<int, int>()
            {
                {1, 12},
                {2, 2}
            };
            
            Memory memory = this.computer.Run(input, this.computerInput, this.computerOutput, overrides);
            
            Console.WriteLine(memory.GetAtAddress(0));
            
            
            
            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    Dictionary<int, int> overrides = new Dictionary<int, int>()
                    {
                        {1, noun},
                        {2, verb}
                    };
                    
                    Memory memory = this.computer.Run(input, this.computerInput, this.computerOutput, overrides);

                    if (memory.GetAtAddress(0) == 19690720)
                    {
                        Console.WriteLine($"Program Code: {100 * noun + verb}");
                        return Task.CompletedTask;
                    }
                }
            }
            
            throw new Exception("Solution was not found when it should have been.");
        }
    }
}