using System;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public delegate bool IsThing(int x);

    public class Day4 : IProblem
    {
        public int Day => 4;
        public string Title => "Secure Container";
        public string Part1Title => "";
        public string Part2Title => "";
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter the password range (x-y):");
            string input = Console.ReadLine();
            string[] parts = input.Split("-");

            int lower = int.Parse(parts[0]);
            int upper = int.Parse(parts[1]);

            int valid = 0;
            Console.WriteLine($"Running between {lower} and {upper}");
            while (lower <= upper)
            {
                string asString = lower.ToString();

                if (asString.Length != 6)
                {
                    continue;
                }

                bool hasDouble = false;
                bool isIncreasing = true;
                bool wasLastDouble = false;

                for (int i = 0; i < asString.Length - 1; i++)
                {
                    if (asString[i] > asString[i + 1])
                    {
                        isIncreasing = false;
                    }

                    if (asString[i] == asString[i + 1] && !wasLastDouble)
                    {
                        hasDouble = true;
                        wasLastDouble = true;
                    }
                    else
                    {
                        wasLastDouble = false;
                    }
                }

                if (hasDouble && isIncreasing)
                {
                    valid++;
                }

                lower++;
            }

            Console.WriteLine($"There are {valid} valid passwords");

            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter the password range (x-y):");
            string input = Console.ReadLine();
            string[] parts = input.Split("-");

            int lower = int.Parse(parts[0]);
            int upper = int.Parse(parts[1]);

            int valid = 0;
            Console.WriteLine($"Running between {lower} and {upper}");
            while (lower <= upper)
            {
                string asString = lower.ToString();

                if (asString.Length != 6)
                {
                    continue;
                }

                bool hasDouble = false;
                bool isIncreasing = true;
                bool wasLastDouble = false;
                int digitCount = 0;
                for (int i = 0; i < asString.Length - 1; i++)
                {
                    if (asString[i] > asString[i + 1])
                    {
                        isIncreasing = false;
                    }

                    if (asString[i] == asString[i + 1])
                    {
                        digitCount++;
                        if (i == 4 && digitCount == 1)
                        {
                            hasDouble = true;
                        }
                    }

                    if (asString[i] != asString[i + 1])
                    {
                        if (digitCount == 1)
                        {
                            hasDouble = true;
                        }

                        digitCount = 0;
                    }
                }

                if (hasDouble && isIncreasing)
                {
                    valid++;
                }

                lower++;
            }

            Console.WriteLine($"There are {valid} valid passwords");

            return Task.CompletedTask;
        }
    }
}
