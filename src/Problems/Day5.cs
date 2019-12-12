using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public class Day5 : IProblem
    {
        public int Day => 5;
        public string Title => "Sunny with a Chance of Asteroids";
        public string Part1Title { get; }
        public string Part2Title { get; }

        private int readValue(string[] memory, string address, char mode)
        {
            if (mode == '1')
            {
                return int.Parse(address);
            }

            return int.Parse(memory[int.Parse(address)]);
        }
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();
            string[] inputs = input.Split(",");
            int i = 0;
            List<int> outputs = new List<int>();
            while (i < inputs.Length)
            {
                string command = inputs[i];
                while (command.Length < 5)
                {
                    command = "0" + command;
                }

                string commandCode = command.Substring(3);

                switch (commandCode)
                {
                    case "01":
                        int aa = this.readValue(inputs, inputs[i + 1], command[2]);
                        int ba = this.readValue(inputs, inputs[i + 2], command[1]);
                        int addressa = int.Parse(inputs[i + 3]);

                        inputs[addressa] = (aa + ba).ToString();
                        i += 4;
                        break;
                    case "02":
                        int am = this.readValue(inputs, inputs[i + 1], command[2]);
                        int bm = this.readValue(inputs, inputs[i + 2], command[1]);
                        int addressm = int.Parse(inputs[i + 3]);
                        inputs[addressm] = (am * bm).ToString();
                        i += 4;
                        break;
                    case "03":
                        string parameter = "5";
                        int addresss =int.Parse(inputs[i + 1]);
                        inputs[addresss] = parameter;
                        i += 2;
                        break;
                    case "04":
                        int address = this.readValue(inputs, inputs[i + 1], command[2]);
                        outputs.Add(address);
                        i += 2;
                        break;
                    default:
                        i = inputs.Length;
                        break;
                }
            }

            foreach (int output in outputs)
            {
                Console.WriteLine(output);
            }
            Console.WriteLine(outputs[outputs.Count - 1]);

            return Task.CompletedTask;

        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
                        Console.WriteLine("Please enter program instructions (comma separated):");
            string input = Console.ReadLine();
            string[] inputs = input.Split(",");
            int i = 0;
            List<int> outputs = new List<int>();
            while (i < inputs.Length)
            {
                string command = inputs[i];
                while (command.Length < 5)
                {
                    command = "0" + command;
                }

                string commandCode = command.Substring(3);

                switch (commandCode)
                {
                    case "01":
                        int aa = this.readValue(inputs, inputs[i + 1], command[2]);
                        int ba = this.readValue(inputs, inputs[i + 2], command[1]);
                        int addressa = int.Parse(inputs[i + 3]);

                        inputs[addressa] = (aa + ba).ToString();
                        i += 4;
                        break;
                    case "02":
                        int am = this.readValue(inputs, inputs[i + 1], command[2]);
                        int bm = this.readValue(inputs, inputs[i + 2], command[1]);
                        int addressm = int.Parse(inputs[i + 3]);
                        inputs[addressm] = (am * bm).ToString();
                        i += 4;
                        break;
                    case "03":
                        string parameter = "5";
                        int addresss =int.Parse(inputs[i + 1]);
                        inputs[addresss] = parameter;
                        i += 2;
                        break;
                    case "04":
                        int address = this.readValue(inputs, inputs[i + 1], command[2]);
                        outputs.Add(address);
                        i += 2;
                        break;
                    case "05":
                        int param1 = this.readValue(inputs, inputs[i + 1], command[2]);
                        if (param1 != 0)
                        {
                            i = this.readValue(inputs, inputs[i + 2], command[1]);
                        }
                        else
                        {
                            i += 3;
                        }
                        break;
                    case "06":
                        int param1a = this.readValue(inputs, inputs[i + 1], command[2]);
                        if (param1a == 0)
                        {
                            i = this.readValue(inputs, inputs[i + 2], command[1]);
                        }
                        else
                        {
                            i += 3;
                        }
                        break;
                    case "07":
                        int param1b = this.readValue(inputs, inputs[i + 1], command[2]);
                        int param2b = this.readValue(inputs, inputs[i + 2], command[1]);

                        if (param1b < param2b)
                        {
                            inputs[int.Parse(inputs[i + 3])] = "1";
                        }
                        else
                        {
                            inputs[int.Parse(inputs[i + 3])] = "0";
                        }

                        i += 4;
                        break;
                    case "08":
                        int param1c = this.readValue(inputs, inputs[i + 1], command[2]);
                        int param2c = this.readValue(inputs, inputs[i + 2], command[1]);

                        if (param1c == param2c)
                        {
                            inputs[int.Parse(inputs[i + 3])] = "1";
                        }
                        else
                        {
                            inputs[int.Parse(inputs[i + 3])] = "0";
                        }

                        i += 4;
                        break;
                    default:
                        i = inputs.Length;
                        break;
                }
            }

            foreach (int output in outputs)
            {
                Console.WriteLine(output);
            }
            Console.WriteLine(outputs[outputs.Count - 1]);

            return Task.CompletedTask;

        }
    }
}
