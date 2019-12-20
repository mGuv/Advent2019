using System.Collections.Generic;

namespace Advent2019.Intcode
{
    public class MemoryFactory
    {
        public Memory Create(string raw)
        {
            string[] parts = raw.Split(",");
            Dictionary<long, long> parsed = new Dictionary<long, long>();

            for (long i = 0; i < parts.Length; i++)
            {
                parsed.Add(i, long.Parse(parts[i]));
            }
            
            return new Memory(parsed);
        }
    }
}