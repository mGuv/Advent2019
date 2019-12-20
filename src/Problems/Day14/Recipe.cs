using System.Collections.Generic;

namespace Advent2019.Problems.Day14
{
    public class Recipe
    {
        public string Output;
        public int Amount;
        public Dictionary<string, int> Ingredients = new Dictionary<string, int>();

        public Recipe(string output, int amount)
        {
            this.Output = output;
            this.Amount = amount;
        }
    }
}