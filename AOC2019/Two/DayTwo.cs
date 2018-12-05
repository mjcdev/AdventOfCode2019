using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2019.Two
{
    public class DayTwo
    {
        public int PartOne(string filePath)
        {
            var idList = File.ReadAllLines(filePath).Select(id => id.ToCharArray()).ToList();

            int twoCount = 0;
            int threeCount = 0;

            foreach (var id in idList)
            {
                var twoTriggered = false;
                var threeTriggered = false;

                foreach(var character in id)
                {
                    var characterCount = id.Where(c => c == character).Count();
                    
                    if (twoTriggered == false && characterCount == 2)
                    {
                        twoTriggered = true;
                        twoCount++;
                    }

                    if (threeTriggered == false && characterCount == 3)
                    {
                        threeTriggered = true;
                        threeCount++;
                    }

                    if (threeTriggered && twoTriggered)
                    {
                        continue;
                    }
                }
            }

            return twoCount * threeCount;
        }

        public IEnumerable<char> PartTwo(string filePath)
        {
            var idList = File.ReadAllLines(filePath).Select(id => id.ToCharArray()).ToList();

            foreach (var id in idList)
            {
                foreach (var comparisonId in idList)
                {
                    List<char> commonCharList = new List<char>();

                    for (var i = 0; i < id.Length; i++)
                    {
                        if (id[i] == comparisonId[i])
                        {
                            commonCharList.Add(id[i]);
                        }                       
                    }

                    if (commonCharList.Count == id.Length - 1)
                    {
                        return commonCharList;
                    }
                }
            }

            return null;
        }
    }
}
