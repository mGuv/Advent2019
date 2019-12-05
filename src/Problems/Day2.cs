using System;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public class Day2 : IProblem
    {
        public int Day => 2;
        public string Title => "1202 Program Alarm";
        public string Part1Title => "Gravity Assist Program";
        public string Part2Title => "Gravity Assist around the Moon";
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();
            string[] inputs = input.Split(",");
            int[] parsedInput = new int[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                parsedInput[i] = int.Parse(inputs[i]);
            }

            parsedInput[1] = 12;
            parsedInput[2] = 2;
            
            // run the program
            int currentPointer = 0;
            while (parsedInput[currentPointer] == 1 || parsedInput[currentPointer] == 2)
            {
                if (parsedInput[currentPointer] == 1)
                {
                    parsedInput[parsedInput[currentPointer + 3]] =
                        parsedInput[parsedInput[currentPointer + 1]] + parsedInput[parsedInput[currentPointer + 2]];
                } else if (parsedInput[currentPointer] == 2)
                {
                    parsedInput[parsedInput[currentPointer + 3]] =
                        parsedInput[parsedInput[currentPointer + 1]] * parsedInput[parsedInput[currentPointer + 2]];
                }

                currentPointer += 4;
            }
            
            Console.WriteLine($"Value at position 0: {parsedInput[0]}");
            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();
            string[] inputs = input.Split(",");

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    int[] parsedInput = new int[inputs.Length];
                    for (int i = 0; i < inputs.Length; i++)
                    {
                        parsedInput[i] = int.Parse(inputs[i]);
                    }
                    
                    parsedInput[1] = noun;
                    parsedInput[2] = verb;
                    
                    int currentPointer = 0;
                    while (parsedInput[currentPointer] == 1 || parsedInput[currentPointer] == 2)
                    {
                        if (parsedInput[currentPointer] == 1)
                        {
                            parsedInput[parsedInput[currentPointer + 3]] =
                                parsedInput[parsedInput[currentPointer + 1]] + parsedInput[parsedInput[currentPointer + 2]];
                        }
                        else if (parsedInput[currentPointer] == 2)
                        {
                            parsedInput[parsedInput[currentPointer + 3]] =
                                parsedInput[parsedInput[currentPointer + 1]] * parsedInput[parsedInput[currentPointer + 2]];
                        }

                        currentPointer += 4;
                    }

                    if (parsedInput[0] == 19690720)
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