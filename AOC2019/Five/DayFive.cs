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

            return outputPolymer.Length;
        }

        public bool IsMatch(string left, string right)        
        {
            return left.ToUpper() == right || right.ToUpper() == left;
        }
        
        public int IndexOfMatch(List<string> inputStrings)
        {
            for (var i = 0; i < inputStrings.Count - 1; i++)
            {
                if (IsMatch(inputStrings[i], inputStrings[i + 1]))
                {
                    return i;
                }
            }

            return -1;
        }

        public string React(string inputPolymer)
        {
            var polymerList = inputPolymer.ToCharArray().Select(c => c.ToString()).ToList();

            var index = IndexOfMatch(polymerList);

            while (index != NoMatch)
            {
                polymerList.RemoveRange(index, 2);
                index = IndexOfMatch(polymerList);
            }

            return string.Concat(polymerList);
        }
    }
}
