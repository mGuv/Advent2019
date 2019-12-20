namespace Advent2019.Intcode
{
    public class MemoryFactory
    {
        public Memory Create(string raw)
        {
            string[] parts = raw.Split(",");
            int[] parsed = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                parsed[i] = int.Parse(parts[i]);
            }
            
            return new Memory(parsed);
        }
    }
}