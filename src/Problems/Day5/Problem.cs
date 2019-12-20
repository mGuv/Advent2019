using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day5
{
    public class Problem : IProblem
    {
        public int Day => 5;
        public string Title => "Sunny with a Chance of Asteroids";
        public string Part1Title { get; }
        public string Part2Title { get; }

        private Computer computer;
        private RememberLastOutput part1Output;
        private IInput part1Input;
        private RememberLastOutput part2Output;
        private IInput part2Input;

        public Problem(Computer computer, RememberLastOutput rememberLastOutput, InputOne inputOne, InputFive inputFive)
        {
            this.computer = computer;
            this.part1Output = rememberLastOutput;
            this.part1Input = inputOne;
            this.part2Output = rememberLastOutput;
            this.part2Input = inputFive;
        }
        
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();
            this.computer.Run(input, this.part1Input, this.part1Output);
            
            Console.WriteLine(this.part1Output.GetLastOutput());
            
            return Task.CompletedTask;

        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();
            this.computer.Run(input, this.part2Input, this.part2Output);
            
            Console.WriteLine(this.part2Output.GetLastOutput());
            
            return Task.CompletedTask;
        }
    }
}
