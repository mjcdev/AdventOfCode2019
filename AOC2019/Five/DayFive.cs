using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Five
{
    public class DayFive
    {
        private const int NoMatch = -1;

        public int PartOne(string input)
        {
            var outputPolymer = React(input);

            var last = outputPolymer.Last();

            return outputPolymer.Length;
        }

        public bool IsMatch(char left, char right)        
        {
            return left != right 
                && char.ToUpper(left) ==  char.ToUpper(right);
        }
        
        public int IndexOfMatch(string inputString)
        {
            for (var i = 0; i < inputString.Length - 1; i++)
            {
                if (IsMatch(inputString[i], inputString[i + 1]))
                {
                    return i;
                }
            }

            return -1;
        }

        public string React(string polymer)
        {

            var index = IndexOfMatch(polymer);

            while (index != NoMatch)
            {
                polymer = polymer.Remove(index, 2);
                index = IndexOfMatch(polymer);
            }

            return polymer;
        }
    }
}
