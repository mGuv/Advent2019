using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advent2019.Intcode;

namespace Advent2019.Problems.Day7
{
    public class Problem : IProblem
    {
        public int Day => 7;
        public string Title => "Amplification Circuit";
        public string Part1Title { get; }
        public string Part2Title { get; }

        private Computer computer;
        private StackInput stackInput;
        private RememberLastOutput lastOutput;

        public Problem(Computer computer, StackInput stackInput, RememberLastOutput lastOutput)
        {
            this.computer = computer;
            this.stackInput = stackInput;
            this.lastOutput = lastOutput;
        }

        private int readValue(string[] memory, string address, char mode)
        {
            if (mode == '1')
            {
                return int.Parse(address);
            }

            return int.Parse(memory[int.Parse(address)]);
        }

        private IEnumerable<int[]> generatePhaseSequences()
        {
            List<int[]> list = new List<int[]>();

            for (int x1 = 0; x1 <= 4; x1++)
            {
                for (int x2 = 0; x2 <= 4; x2++)
                {
                    for (int x3 = 0; x3 <= 4; x3++)
                    {
                        for (int x4 = 0; x4 <= 4; x4++)
                        {
                            for (int x5 = 0; x5 <= 4; x5++)
                            {
                                int[] set = new int[] {x1, x2, x3, x4, x5};
                                if (set.Distinct().Count() == set.Length)
                                {
                                    yield return set;
                                }
                            }
                        }
                    }
                }
            }
        }

        private IEnumerable<int[]> generatePhaseSequences2()
        {
            List<int[]> list = new List<int[]>();

            for (int x1 = 5; x1 <= 9; x1++)
            {
                for (int x2 = 5; x2 <= 9; x2++)
                {
                    for (int x3 = 5; x3 <= 9; x3++)
                    {
                        for (int x4 = 5; x4 <= 9; x4++)
                        {
                            for (int x5 = 5; x5 <= 9; x5++)
                            {
                                int[] set = new int[] {x1, x2, x3, x4, x5};
                                if (set.Distinct().Count() == set.Length)
                                {
                                    yield return set;
                                }
                            }
                        }
                    }
                }
            }
        }

        private string getRawProgramInstructions()
        {
            return
                "3,8,1001,8,10,8,105,1,0,0,21,42,67,84,109,126,207,288,369,450,99999,3,9,102,4,9,9,1001,9,4,9,102,2,9,9,101,2,9,9,4,9,99,3,9,1001,9,5,9,1002,9,5,9,1001,9,5,9,1002,9,5,9,101,5,9,9,4,9,99,3,9,101,5,9,9,1002,9,3,9,1001,9,2,9,4,9,99,3,9,1001,9,2,9,102,4,9,9,101,2,9,9,102,4,9,9,1001,9,2,9,4,9,99,3,9,102,2,9,9,101,5,9,9,1002,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,99,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,99";
        }

        public async Task RunPart1Async(CancellationToken cancellationToken)
        {
            long maxSignal = 0;
            int[] code = new int[0];

            foreach (int[] sequence in this.generatePhaseSequences())
            {
                // Reset output between sequences
                await this.lastOutput.WriteAsync(0);
                foreach (int i1 in sequence)
                {
                    // build the two inputs it needs
                    this.stackInput.Reset();
                    this.stackInput.Push(this.lastOutput.GetLastOutput());
                    this.stackInput.Push(i1);

                    // run an isolated memory with the two inputs and an output layer that'll remember the last output
                    await this.computer.RunAsync(this.getRawProgramInstructions(), this.stackInput, this.lastOutput);
                }

                // sequence done, see if it's the highest signal
                if (this.lastOutput.GetLastOutput() > maxSignal)
                {
                    code = sequence;
                    maxSignal = this.lastOutput.GetLastOutput();
                }
            }

            Console.WriteLine($"MaxSignal: {maxSignal}");
        }

        public async Task RunPart2Async(CancellationToken cancellationToken)
        {
            long maxSignal = 0;
            int[] code = new int[0];

            foreach (int[] sequence in this.generatePhaseSequences2())
            {
                // Wire each amp together with blocking input/output pairs
                ReadWriteBlocker EtoA = new ReadWriteBlocker();
                await EtoA.WriteAsync(sequence[0]);
                await EtoA.WriteAsync(0);
                ReadWriteBlocker AtoB = new ReadWriteBlocker();
                await AtoB.WriteAsync(sequence[1]);
                ReadWriteBlocker BtoC = new ReadWriteBlocker();
                await BtoC.WriteAsync(sequence[2]);
                ReadWriteBlocker CtoD = new ReadWriteBlocker();
                await CtoD.WriteAsync(sequence[3]);
                ReadWriteBlocker DtoE = new ReadWriteBlocker();
                await DtoE.WriteAsync(sequence[4]);

                // run five copies async until they all finish
                Task ampA = this.computer.RunAsync(this.getRawProgramInstructions(), EtoA, AtoB);
                Task ampB = this.computer.RunAsync(this.getRawProgramInstructions(), AtoB, BtoC);
                Task ampC = this.computer.RunAsync(this.getRawProgramInstructions(), BtoC, CtoD);
                Task ampD = this.computer.RunAsync(this.getRawProgramInstructions(), CtoD, DtoE);
                Task ampE = this.computer.RunAsync(this.getRawProgramInstructions(), DtoE, EtoA);
                Task.WaitAll(ampA, ampB, ampC, ampD, ampE);

                // sequence done, see if it's the highest signal
                long lastValue = await EtoA.GetNextAsync();
                if (lastValue > maxSignal)
                {
                    code = sequence;
                    maxSignal = lastValue;
                }
            }

            Console.WriteLine($"MaxSignal: {maxSignal}");
        }
    }
}