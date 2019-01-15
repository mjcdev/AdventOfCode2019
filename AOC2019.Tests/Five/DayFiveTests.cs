using AOC2019.Five;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Five
{
    public class DayFiveTests
    {
        private const string FileName = @"Five/Five.txt";

        [Fact]
        public void PartOne()
        {
            var input = File.ReadAllText(FileName);

            var result = NewDay().PartOne(input);
        }

        [Theory]
        [InlineData("A", "a")]
        [InlineData("a", "A")]
        public void IsMatch_True(string left, string right)
        {
            NewDay().IsMatch(left, right).Should().BeTrue();
        }

        [Theory]
        [InlineData("a", "b")]
        [InlineData("a", "a")]
        public void IsMatch_False(string left, string right)
        {
            NewDay().IsMatch(left, right).Should().BeFalse();
        }

        [Theory]
        [InlineData("dabAcCaCBAcCcaDA", "dabCBAcaDA")]
        [InlineData("aA", "")]
        [InlineData("abBA", "")]
        public void React(string input, string output)
        {
            var result = NewDay().React(input);

            result.Should().Be(output);
        }

        private DayFive NewDay()
        {
            return new DayFive();
        }
    }
}
