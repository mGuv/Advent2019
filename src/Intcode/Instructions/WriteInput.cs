using System.Threading.Tasks;

namespace Advent2019.Intcode.Instructions
 {
     public class WriteInput : IInstruction
     {
         public async Task<int> RunAsync(Memory memory, int startingIndex, Command command, IInput input, IOutput output)
         {
             int value = await input.GetNextAsync();
             int address = memory.GetAtAddress(startingIndex + 1);
             
             memory.Write(address, value);

             return startingIndex + 2;
         }
     }
 }