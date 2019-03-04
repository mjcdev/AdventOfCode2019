using AOC2019.Ten.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AOC2019.Ten
{
    public class DayTen
    {
        private const int viewPortX = 80;
        private const int viewPortY = 30;

        public IEnumerable<Coordinate> BuildPartOneModel(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Select(l => l.Split('<', ',', '>'))
                .Select(l => new Coordinate(int.Parse(l[1]), int.Parse(l[2]), int.Parse(l[4]), int.Parse(l[5])));            
        }

        public void RunDayTen(string filePath)
        {
            var coordinates = BuildPartOneModel(filePath).ToList();

            int i = 0;

            while (true)
            {
                Render(coordinates, i++);
                Move(coordinates);
            }
        }


        public void Move(ICollection<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                coordinate.Move();
            }
        }

        public void Render(IEnumerable<Coordinate> coordinates, int second)
        {
            var minX = coordinates.Min(x => x.X);
            var minY = coordinates.Min(y => y.Y);

            var maxX = minX + viewPortX - 1;
            var maxY = minY + viewPortY - 1;

            var coordinatesCount = coordinates.Count();

            var visibleCoorindates = coordinates.Where(c => c.X >= minX && c.X <= maxX && c.Y >= minY && c.Y <= maxY);
            var visibleCoordinatesCount = visibleCoorindates.Count();

            if (visibleCoorindates.Count() > 1)
            {
                char[][] grid = new char[viewPortY][];

                for (var row = 0; row < viewPortY; row++)
                {
                    grid[row] = new char[viewPortX];
                }

                foreach (var coordinate in visibleCoorindates)
                {
                    var y = coordinate.Y - minY;
                    var x = coordinate.X - minX;
                    grid[y][x] = 'X';
                }

                Console.Clear();

                foreach (var row in grid)
                {
                    Console.WriteLine(string.Concat(row));
                }

                Thread.Sleep(500);

                if (coordinatesCount == visibleCoordinatesCount)
                {

                }
            }
        }        
    }
}
