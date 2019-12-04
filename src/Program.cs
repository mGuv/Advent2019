using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Advent2019.DI;
using Advent2019.Problems;

namespace Advent2019
{
    class Program
    {
        static async Task Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, args) =>
            {
                args.Cancel = true;
                Console.WriteLine("Stopped by user");
                cts.Cancel(true);
            };
            
            DI.ProviderBuilder providerBuilder = new ProviderBuilder();
            IServiceProvider serviceProvider = providerBuilder.WithAutowire().Build();

            List<IProblem> problems = new List<IProblem>();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                if (!typeof(IProblem).IsAssignableFrom(type))
                {
                    continue;
                }

                if (type.IsInterface)
                {
                    continue;
                }

                IProblem problem = (IProblem) serviceProvider.GetService(type);
                problems.Add(problem);
            }

            Console.WriteLine("Please enter a Day to run:");
            for (int i = 1; i <= problems.Count; i++)
            {
                Console.WriteLine($"Day {problems[i-1].Day} - {problems[i-1].Title}");
                Console.WriteLine($"{i}.1 - {problems[i-1].Part1Title}");
                Console.WriteLine($"{i}.2 - {problems[i-1].Part2Title}");
            }

            Console.WriteLine("Please enter day and part to run (e.g. 1.1):");
            string input = Console.ReadLine();
            string[] parts = input.Split(".");
            int dayIndex = int.Parse(parts[0]);

            if (parts[1] == "1")
            {
                await problems[dayIndex - 1].RunPart1Async(cts.Token);
            }
            else if (parts[1] == "2")
            {
                await problems[dayIndex - 1].RunPart2Async(cts.Token);
            }
        }
    }
}
