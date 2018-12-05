using AOC2019.Two;
using System.Linq;
using System.Text;
using Xunit;

namespace AOC2019.Tests.Two
{
    public class DayTwoTests
    {
        const string FilePath = "Two/Two.txt";

        [Fact]
        public void PartOne()
        {
            var dayTwo = new DayTwo();

            var output = dayTwo.PartOne(FilePath);
        }

        [Fact]
        public void PartTwo()
        {
            var dayTwo = new DayTwo();

            var output = new string(dayTwo.PartTwo(FilePath).ToArray());
        }
    }
}
