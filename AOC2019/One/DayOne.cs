using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2019.One
{
    public class DayOne
    {
        public int PartOne(string filePath)
        {
            return File.ReadAllLines(filePath).Select(l => int.Parse(l)).Sum();
        }

        public int PartTwo(string filePath)
        {
            var resultList = new HashSet<int>() { 0 };
            var inputList = File.ReadAllLines(filePath).Select(l => int.Parse(l)).ToList();

            var previous = 0;

            while (true)
            {
                foreach (var input in inputList)
                {
                    var current = previous + input;

                    if (resultList.Contains(current))
                    {
                        return current;
                    }
                    else
                    {
                        resultList.Add(current);
                        previous = current;
                    }
                }
            }            
        }
    }
}
