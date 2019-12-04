using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public class Day1 : IProblem
    {
        public int Day => 1;
        public string Title => "The Tyranny of the Rocket Equation";
        public string Part1Title => "Module Fuel Requirement without Fuel mass";
        public string Part2Title => "Module Fuel Requirement with Fuel mass";
        
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            double total = 0;
            foreach (double mass in this.GetInput())
            {
                total += this.CalculateFuelRequired(mass);
            }
            
            Console.WriteLine($"Fuel Required: {total}");
            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            double total = 0;
            foreach (double mass in this.GetInput())
            {
                double massLeft = mass;
                while (true)
                {
                    massLeft = this.CalculateFuelRequired(massLeft);
                    if (massLeft <= 0)
                    {
                        break;
                    }
                    total += massLeft;
                }
            }
            
            Console.WriteLine($"Fuel Required: {total}");
            return Task.CompletedTask;
        }
        
        private IEnumerable<double> GetInput()
        {
            Console.WriteLine("Please enter module mass list, space separated:");
            string input = Console.ReadLine();
            string[] parts = input.Split(" ");
            foreach (string part in parts)
            {
                yield return double.Parse(part);
            }
        }

        private double CalculateFuelRequired(double mass)
        {
            return mass = Math.Floor(mass / 3) - 2;
        }
    }
}