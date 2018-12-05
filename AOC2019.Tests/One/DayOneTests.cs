using AOC2019.One;
using Xunit;

namespace AOC2019.Tests.One
{
    public class DayOneTests
    {
        private const string inputFile = "One/One.txt";

        [Fact]
        public void PartOne()
        {
            var dayOne = new DayOne();

            var output = dayOne.PartOne(inputFile);
        }

        [Fact]
        public void PartTwo()
        {
            var dayOne = new DayOne();

            var output = dayOne.PartTwo(inputFile);
        }
    }
}
