using System.Runtime.CompilerServices;

namespace Advent2019.Intcode
{
    public class Memory
    {
        private int[] data;

        public Memory(int[] data)
        {
            this.data = data;
        }

        public int Length()
        {
            return this.data.Length;
        }

        public void Write(int index, int value)
        {
            this.data[index] = value;
        }

        public int GetAtAddress(int index)
        {
            return this.data[index];
        }

        public int Read(int index, ParameterMode mode)
        {
            if (mode == ParameterMode.Immediate)
            {
                return this.data[index];
            }
            
            return this.data[this.GetAtAddress(index)];
        }
    }
}