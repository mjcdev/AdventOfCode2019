using AOC2019.Six.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Six
{
    public class DaySix
    {
        private const int DrawDistanceId = -1;        

        public int PartOne(IEnumerable<string> records)
        {
            var rootCoordinates = BuildRootCoordinates(records);

            var grid = BuildGridCoordinates(rootCoordinates);

            grid = RemoveRootCoordinates(grid, rootCoordinates);

            foreach (var gridCoordinate in grid)
            {
                gridCoordinate.ClosestCoordinateId = CalculateClosestPoint(gridCoordinate, rootCoordinates);
            }

            grid = RemoveDrawingDistanceCoordinates(grid);
            grid = RemoveInfiniteSpaceCoordinates(grid);

            var largestAreaSize = grid.GroupBy(gc => gc.ClosestCoordinateId).Max(g => g.Count());
            
            return largestAreaSize + 1; // Root Coordinate
        }

        private IEnumerable<RootCoordinate> BuildRootCoordinates(IEnumerable<string> input)
        {
            int index = 0;

            var coordinates = new List<RootCoordinate>();

            foreach (var record in input)
            {
                var split = record.Split(',');

                coordinates.Add(new RootCoordinate() { Id = index, X = int.Parse(split[0]), Y = int.Parse(split[1]) });

                index++;
            }

            return coordinates;                
        }

        private IEnumerable<GridCoordinate> BuildGridCoordinates(IEnumerable<AbstractCoordinate> inputCoordinates)
        {
            int minX = inputCoordinates.Min(c => c.X);
            int maxX = inputCoordinates.Max(c => c.X);
            int minY = inputCoordinates.Min(c => c.Y);
            int maxY = inputCoordinates.Max(c => c.X);

            var gridCoordinates = new List<GridCoordinate>();

            for (var x = minX - 1; x <= maxX; x++)
            {
                for (var y = minY - 1; y <= maxY; y++)
                {
                    gridCoordinates.Add(new GridCoordinate() { X = x, Y = y });
                }
            }

            return gridCoordinates;
        }

        public int CalculateManhattanDistance(AbstractCoordinate one, AbstractCoordinate two)
        {
            var x = Math.Abs(one.X - two.X);

            var y = Math.Abs(one.Y - two.Y);

            return x + y;
        }

        public int CalculateClosestPoint(GridCoordinate gridCoordinate, IEnumerable<RootCoordinate> rootCoordinates)
        {
            var closestGrouping = rootCoordinates.GroupBy(c => CalculateManhattanDistance(gridCoordinate, c)).OrderBy(g => g.Key).First().ToList();

            if (closestGrouping.Count > 1)
            {
                return -1;
            }

            return closestGrouping.First().Id;
        }
        
        public IEnumerable<GridCoordinate> RemoveRootCoordinates(IEnumerable<GridCoordinate> gridCoordinates, IEnumerable<RootCoordinate> rootCoordinates)
        {
            return gridCoordinates.Where(gc => !rootCoordinates.Any(rc => gc.X == rc.X && gc.Y == rc.Y));
        }        

        public IEnumerable<GridCoordinate> RemoveDrawingDistanceCoordinates(IEnumerable<GridCoordinate> gridCoordinates)
        {
            return gridCoordinates.Where(gc => gc.ClosestCoordinateId != DrawDistanceId);
        }

        public IEnumerable<GridCoordinate> RemoveInfiniteSpaceCoordinates(IEnumerable<GridCoordinate> gridCoordinates)
        {
            var maxX = gridCoordinates.Max(gc => gc.X);
            var maxY = gridCoordinates.Max(gc => gc.Y);
            var minX = gridCoordinates.Min(gc => gc.X);
            var minY = gridCoordinates.Min(gc => gc.Y);

            var distinctInfiniteIds = gridCoordinates.Where(gc => gc.X == maxX || gc.X == minX || gc.Y == maxY || gc.Y == minY).ToList();

            return gridCoordinates.Where(gc => !distinctInfiniteIds.Contains(gc));


        }
    }
}
