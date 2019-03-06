using AOC2019.Eleven;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Eleven
{
    public class DayElevenTests
    {
        [Fact]
        public void PartOne()
        {
            var dayEleven = new DayEleven();
             
             //dayEleven.PartOne(18).Should().Be("90,269,16");
             //dayEleven.PartOne(42).Should().Be("232,251,12");

            var result = dayEleven.PartOne(8141);
        }
    }
}
