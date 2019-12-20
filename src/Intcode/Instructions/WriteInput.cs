using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
 {
     public class WriteInput : IInstruction
     {
         public async Task<long> RunAsync(Memory memory, long startingIndex, Command command, IInput input, IOutput output)
         {
             long value = await input.GetNextAsync();
             long address = memory.GetIndex(startingIndex + 1, command.GetParameterMode(1));
             
             memory.Write(address, value);

             return startingIndex + 2;
         }
     }
 }