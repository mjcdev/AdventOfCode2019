using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2019.Three
{
    public class DayThree
    {
        public int PartOne(string filePath)
        {
            var coordinates = File.ReadAllLines(filePath)
                .Select(l => new PartOneModel(l))
                .SelectMany(m => m.BuildCoordinates());

            return coordinates
                .GroupBy(c => c)
                .Where(g => g.Count() > 1)
                .Count();
        }

        private struct PartOneModel
        {
            // #57 @ 940,102: 24x13
            public PartOneModel(string definition)
            {
                var splitDefinition = definition.Replace(" ", "").Split('#', '@', ',', ':', 'x');
                StartX = int.Parse(splitDefinition[2]);
                StartY = int.Parse(splitDefinition[3]);
                Width = int.Parse(splitDefinition[4]);
                Height = int.Parse(splitDefinition[5]);
            }

            public int StartX;
            public int StartY;
            public int Width;
            public int Height;

            public IEnumerable<PartOneCoordinate> BuildCoordinates()
            {
                var coordinates = new List<PartOneCoordinate>();

                for (int x = StartX; x < StartX + Width; x++)
                {
                    for (int y = StartY; y < StartY + Height; y++)
                    {
                        coordinates.Add(new PartOneCoordinate(x, y));
                    }
                }

                return coordinates;
            }
        }

        private struct PartOneCoordinate
        {
            public PartOneCoordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X;
            public int Y;
        }

        public int PartTwo(string filePath)
        {
            var coordinates = File.ReadAllLines(filePath)
                .Select(l => new PartTwoModel(l))
                .SelectMany(m => m.BuildCoordinates());

            var overlappingIds = 
                new HashSet<int>(coordinates
                .GroupBy(c =>  new { c.X, c.Y })
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Select(a => a.Id))
                .Distinct());

            var distinctIds = coordinates.Select(c => c.Id).Distinct();
            
            return distinctIds.First(id => !overlappingIds.Contains(id));
        }

        private struct PartTwoModel
        {
            // #57 @ 940,102: 24x13
            public PartTwoModel(string definition)
            {
                var splitDefinition = definition.Replace(" ", "").Split('#', '@', ',', ':', 'x');

                Id = int.Parse(splitDefinition[1]);
                StartX = int.Parse(splitDefinition[2]);
                StartY = int.Parse(splitDefinition[3]);
                Width = int.Parse(splitDefinition[4]);
                Height = int.Parse(splitDefinition[5]);
            }

            public int Id;
            public int StartX;
            public int StartY;
            public int Width;
            public int Height;

            public IEnumerable<PartTwoCoordinate> BuildCoordinates()
            {
                var coordinates = new List<PartTwoCoordinate>();

                for (int x = StartX; x < StartX + Width; x++)
                {
                    for (int y = StartY; y < StartY + Height; y++)
                    {
                        coordinates.Add(new PartTwoCoordinate(x, y, Id));
                    }
                }

                return coordinates;
            }
        }

        private struct PartTwoCoordinate
        {
            public PartTwoCoordinate(int x, int y, int id)
            {
                X = x;
                Y = y;
                Id = id;
            }

            public int X;
            public int Y;
            public int Id;
        }
    }
}
