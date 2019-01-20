using AOC2019.Eight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Eight
{
    public class DayEightTests
    {
        private const string FileName = @"Eight\Eight.txt";

        [Fact]
        public void PartOne()
        {
            var input = File.ReadAllText(FileName);

            var result = NewDay().PartOne(input);
        }

        [Fact]
        public void PartTwo()
        {
            var input = File.ReadAllText(FileName);

            var result = NewDay().PartTwo(input);
        }

        [Fact]
        public void Example()
        {

        }

        private DayEight NewDay()
        {
            return new DayEight();
        }
    }
}
