using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Advent2019.Intcode
{
    public class Memory
    {
        public bool Terminated = false;
        private Dictionary<long, long> data;
        private long relativeBase = 0;

        public Memory(Dictionary<long, long> data)
        {
            this.data = data;
        }

        public void AdjustRelativeBase(long change)
        {
            this.relativeBase += change;
        }


        public long Length()
        {
            return this.data.Keys.Max();
        }

        public void Write(long index, long value)
        {
            this.data[index] = value;
        }

        public long GetAtAddress(long index)
        {
            return this.data.ContainsKey(index) ? this.data[index] : 0;
        }

        public long GetIndex(long index, ParameterMode mode)
        {
            if (mode == ParameterMode.Immediate)
            {
                return this.GetAtAddress(index);
            }
            else if (mode == ParameterMode.Relative)
            {
                return this.relativeBase + this.GetAtAddress(index);
            }

            return this.GetAtAddress(index);
        }

        public long Read(long index, ParameterMode mode)
        {
            index = this.GetIndex(index, mode);
            switch (mode)
            {
                case ParameterMode.Immediate:
                    return index;
                case ParameterMode.Position:
                    return this.GetAtAddress(index);
                case ParameterMode.Relative:
                    return this.GetAtAddress(index);
            }

            return 0;
        }
    }
}