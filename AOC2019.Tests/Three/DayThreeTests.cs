using AOC2019.Three;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Three
{
    public class DayThreeTests
    {
        private const string InputFile = @"Three/Three.txt";

        [Fact]
        public void PartOne()
        {
            var dayThree = new DayThree();

            var output = dayThree.PartOne(InputFile);
        }

        [Fact]
        public void PartTwo()
        {
            var dayThree = new DayThree();

            var output = dayThree.PartTwo(InputFile);
        }
    }
}
