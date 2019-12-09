using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public class Marker
    {
        public int FirstWire;
        public int[] Steps = new int[2];
    }

    public class Day3 : IProblem
    {
        public int Day => 3;
        public string Title => "Crossed Wires";
        public string Part1Title => "TBC";
        public string Part2Title => "TBC";
        public Task RunPart2Async(CancellationToken cancellationToken)
        {


            Console.WriteLine("Enter the path of wires (comma separated):");
            string input = Console.ReadLine();
            string[] wires = input.Split(" ");

            Dictionary<string, Marker> hitLocations = new Dictionary<string, Marker>();
            HashSet<string> collisions = new HashSet<string>();

            for (int wire = 0; wire < wires.Length; wire++)
            {
                string[] inputs = wires[wire].Split(",");
                int currentX = 0;
                int currentY = 0;
                int count = 1;

                foreach (string currentPath in inputs)
            {

                if (currentPath[0] == 'R')
                {
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentX += 1;

                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY].FirstWire != wire)
                            {

                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            Marker newMarker = new Marker();
                            newMarker.FirstWire = wire;
                            hitLocations.Add(currentX + ":" + currentY, newMarker);
                        }

                        if (hitLocations[currentX + ":" + currentY].Steps[wire] == 0)
                        {
                            hitLocations[currentX + ":" + currentY].Steps[wire] = count;
                        }
                        count++;

                    }
                }
                if (currentPath[0] == 'L')
                {
                    // loop to the right
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentX -= 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY].FirstWire != wire)
                            {

                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            Marker newMarker = new Marker();
                            newMarker.FirstWire = wire;
                            hitLocations.Add(currentX + ":" + currentY, newMarker);
                        }

                        if (hitLocations[currentX + ":" + currentY].Steps[wire] == 0)
                        {
                            hitLocations[currentX + ":" + currentY].Steps[wire] = count;
                        }
                        count++;
                    }
                }
                if (currentPath[0] == 'U')
                {
                    // loop to the right
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentY += 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY].FirstWire != wire)
                            {

                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            Marker newMarker = new Marker();
                            newMarker.FirstWire = wire;
                            hitLocations.Add(currentX + ":" + currentY, newMarker);
                        }

                        if (hitLocations[currentX + ":" + currentY].Steps[wire] == 0)
                        {
                            hitLocations[currentX + ":" + currentY].Steps[wire] = count;
                        }
                        count++;
                    }
                }
                if (currentPath[0] == 'D')
                {
                    // loop to the right
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentY -= 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY].FirstWire != wire)
                            {
                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            Marker newMarker = new Marker();
                            newMarker.FirstWire = wire;
                            hitLocations.Add(currentX + ":" + currentY, newMarker);
                        }

                        if (hitLocations[currentX + ":" + currentY].Steps[wire] == 0)
                        {
                            hitLocations[currentX + ":" + currentY].Steps[wire] = count;
                        }
                        count++;
                    }
                }




            }

            }

            int closestDistance = -1;
            foreach (string collision in collisions)
            {
                int total = hitLocations[collision].Steps[0] + hitLocations[collision].Steps[1];

                if (total < closestDistance || closestDistance == -1)
                {
                    closestDistance = total;
                }
            }

            Console.WriteLine("Closest path distance: " + closestDistance);

            return Task.CompletedTask;
        }

        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Enter the path of wires (comma separated):");
            string input = Console.ReadLine();
            string[] wires = input.Split(" ");

            Dictionary<string, int> hitLocations = new Dictionary<string, int>();
            HashSet<string> collisions = new HashSet<string>();

            for (int wire = 0; wire < wires.Length; wire++)
            {
                string[] inputs = wires[wire].Split(",");
                int currentX = 0;
                int currentY = 0;

                foreach (string currentPath in inputs)
            {
                if (currentPath[0] == 'R')
                {
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentX += 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY] != wire)
                            {
                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            hitLocations.Add(currentX + ":" + currentY, wire);
                        }
                    }
                }
                if (currentPath[0] == 'L')
                {
                    // loop to the right
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentX -= 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY] != wire)
                            {
                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            hitLocations.Add(currentX + ":" + currentY, wire);
                        }
                    }
                }
                if (currentPath[0] == 'U')
                {
                    // loop to the right
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentY += 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY] != wire)
                            {
                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            hitLocations.Add(currentX + ":" + currentY, wire);
                        }
                    }
                }
                if (currentPath[0] == 'D')
                {
                    // loop to the right
                    int steps = int.Parse(currentPath.Substring(1));
                    for (int x = 0; x < steps; x++)
                    {
                        currentY -= 1;
                        if (hitLocations.ContainsKey(currentX + ":" + currentY))
                        {
                            if (hitLocations[currentX + ":" + currentY] != wire)
                            {
                                collisions.Add(currentX + ":" + currentY);
                            }
                        }
                        else
                        {
                            hitLocations.Add(currentX + ":" + currentY, wire);
                        }
                    }
                }
            }

            }

            int closestDistance = -1;
            foreach (string collision in collisions)
            {
                string[] part = collision.Split(":");
                int x = int.Parse(part[0]);
                int y = int.Parse(part[1]);

                int total = Math.Abs(x) + Math.Abs(y);

                if (total < closestDistance || closestDistance == -1)
                {
                    closestDistance = total;
                }
            }

            Console.WriteLine("Closest overlap distance: " + closestDistance);

            return Task.CompletedTask;
        }
    }
}
