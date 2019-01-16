using AOC2019.Six;
using AOC2019.Six.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Six
{
    public class DaySixTests
    {
        private string FileName = @"Six/Six.txt";

        [Fact]
        public void PartOne()
        {
            var input = File.ReadAllLines(FileName);

            var result = NewDay().PartOne(input);
        }

        [Theory]
        [InlineData(0, 0, 3, 3, 6)]
        [InlineData(0, 0, -3, -3, 6)]
        public void CalculateManhattanDistance(int oneX, int oneY, int twoX, int twoY, int distance)
        {
            var one = new GridCoordinate() { X = oneX, Y = oneY };
            var two = new RootCoordinate() { X = twoX, Y = twoY };

            NewDay().CalculateManhattanDistance(one, two).Should().Be(distance);
        }

        [Fact]
        public void CalculateClosestPoint()
        {
            var gridCoordinate = new GridCoordinate() { X = 5, Y = 5 };

            var rootCoordinates = new List<RootCoordinate>()
            {
                new RootCoordinate() { X = 0, Y = 0, Id = 0 },
                new RootCoordinate() { X = 1, Y = 1, Id = 1 },
            };

            NewDay().CalculateClosestPoint(gridCoordinate, rootCoordinates).Should().Be(1);
        }
        
        [Fact]
        public void CalculateClosestPoint_Draw()
        {
            var gridCoordinate = new GridCoordinate() { X = 5, Y = 5 };

            var rootCoordinates = new List<RootCoordinate>()
            {
                new RootCoordinate() { X = 0, Y = 0, Id = 0 },
                new RootCoordinate() { X = 1, Y = 1, Id = 1 },
                new RootCoordinate() { X = 9, Y = 9, Id = 2 },
            };

            NewDay().CalculateClosestPoint(gridCoordinate, rootCoordinates).Should().Be(-1);
        }

        private DaySix NewDay()
        {
            return new DaySix();
        }
    }
}
