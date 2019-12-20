using System;

namespace Advent2019.Intcode
{
    public class Command
    {
        private readonly char[] characters = new Char[5];

        public Command(int raw)
        {
            string converted = raw.ToString();
            while (converted.Length < 5)
            {
                converted = "0" + converted;
            }

            this.characters = converted.ToCharArray();
        }

        public int GetIntCode()
        {
            return int.Parse(this.characters[3].ToString() + this.characters[4].ToString());
        }

        public ParameterMode GetParameterMode(int parameterIndex)
        {
            return Enum.Parse<ParameterMode>(this.characters[Math.Abs(parameterIndex - 3)].ToString());
        }
    }
}