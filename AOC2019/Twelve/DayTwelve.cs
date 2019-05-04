using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2019.Twelve
{
    public class DayTwelve
    {
        private const long Generations = 20;

        public int Run(string filePath)
        {

            var lines = File.ReadAllLines(filePath).ToList();
            
            var masks = lines.GetRange(2, lines.Count - 2).Select(l => new Mask(l.Substring(0, 5), l[9]));
                                   
            var offset = 0;
                        
            var pots = lines[0].Substring(15).Select(PotToBool).ToList();

            bool[] emptyPots = { false, false, false, false, false };
            bool[] tooManyPots = { false, false, false, false, false, false };

            var potsMalleable = new List<bool>();

            for (long i = 0; i < Generations; i++)
            {
                if (!(!pots[4] && !pots[3] && !pots[2] && !pots[1] && !pots[0]))
                {
                    pots.InsertRange(0, emptyPots);
                    offset = offset + emptyPots.Length;
                }

                if (!(!pots[pots.Count - 5] && !pots[pots.Count - 4] && !pots[pots.Count - 3] && !pots[pots.Count - 2] && !pots[pots.Count - 1]))
                {
                    pots.AddRange(emptyPots);
                }

                if (!(pots[5] || pots[4] || pots[3] || pots[2] || pots[1] || pots[0]))
                {
                    pots.RemoveAt(0);
                    offset--;
                }

                if (!(pots[pots.Count - 6] || pots[pots.Count - 5] || pots[pots.Count - 4] || pots[pots.Count - 3] || pots[pots.Count - 2] || pots[pots.Count - 1]))
                {
                    pots.RemoveAt(pots.Count - 1);
                }
                               
                pots = ApplyMasks(pots, masks);

                //Console.WriteLine(pots);
            }

            var sum = 0;

            for (var potWithOffset = 0; potWithOffset < pots.Count; potWithOffset++)
            {
                if (pots[potWithOffset])
                {
                    var potWithoutOffset = potWithOffset - offset;
                    sum += potWithoutOffset;
                }
            }


            return sum;
        }

        public List<bool> ApplyMasks(List<bool> pots, IEnumerable<Mask> masks)
        {
            var potsMapped = pots.ToList();

            for (var index = 0; index < pots.Count - 5; index++)
            {
                foreach (var mask in masks)
                {
                    if (pots[index] == mask.Pattern[0]
                        && pots[index + 1] == mask.Pattern[1]
                        && pots[index + 2] == mask.Pattern[2]
                        && pots[index + 3] == mask.Pattern[3]
                        && pots[index + 4] == mask.Pattern[4])
                    {
                        potsMapped[index + 2] = mask.Value;
                        break;
                    }
                }
            }

            return potsMapped;
        }

        public static bool PotToBool(char pot)
        {
            return pot == '#';
        }

        public class Mask
        {
            public Mask(string pattern, char value)
            {
                Pattern = pattern.Select(PotToBool).ToArray();
                Value = PotToBool(value);
            }

            public  bool[] Pattern;

            public bool Value;

            
        }
    }
}
