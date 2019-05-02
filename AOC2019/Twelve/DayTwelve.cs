using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2019.Twelve
{
    public class DayTwelve
    {
        private const int Generations = 20;

        public int Run(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();

            //var pots = BuildPots(lines[0]);

            var masks = lines.GetRange(2, lines.Count - 2).Select(l => new Mask(l.Substring(0, 5), l[9]));

            var stringBuilder = new StringBuilder();
            
            var offset = Generations * 2;

            stringBuilder.Append('.', offset);
            stringBuilder.Append(lines[0].Substring(15));
            stringBuilder.Append('.', offset);

            var pots = stringBuilder.ToString();
            
            for (var i = 0; i < Generations; i++)
            {
                pots = ApplyMasks(pots, masks);
            }

            var sum = 0;

            for (var potWithOffset = 0; potWithOffset < pots.Length; potWithOffset++)
            {
                if (pots[potWithOffset] == '#')
                {
                    var potWithoutOffset = potWithOffset - offset;
                    sum += potWithoutOffset;
                }
            }


            return sum;
        }

        public string ApplyMasks(string pots, IEnumerable<Mask> masks)
        {
            var potsMapped = new StringBuilder(pots);

            foreach (var mask in masks)
            {
                var index = pots.IndexOf(mask.Pattern, 0);
                while (index >= 0)
                {
                    potsMapped[index + 2] = mask.Value;
                    index = pots.IndexOf(mask.Pattern, index + 1);
                }
            }

            return potsMapped.ToString();
        }

        public struct Mask
        {
            public Mask(string pattern, char value)
            {
                Pattern = pattern;
                Value = value;
            }

            public string Pattern;

            public char Value;
        }

        //public IDictionary<int, bool> BuildPots(string input)
        //{
        //    input = input.Remove(0, 15);

        //    var length = input.Length;
        //    var excess = length;

        //    var pots = new Dictionary<int, bool>();
            
        //    for (var l = -excess; l < 0; l++)
        //    {
        //        pots[l] = false;
        //    }

        //    for(var l = 0; l < length; l++)
        //    {
        //        if (input[l] == '#')
        //        {
        //            pots[l] = true;
        //        }
        //        else
        //        {
        //            pots[l] = false;
        //        }
        //    }

        //    for (var l = length; l < excess + length; l++)
        //    {
        //        pots[l] = false;
        //    }


        //    return pots;
        //}
    }
}
