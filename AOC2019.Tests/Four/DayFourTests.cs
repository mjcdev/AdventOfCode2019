using AOC2019.Four;
using AOC2019.Four.Model;
using FluentAssertions;
using System;
using System.IO;
using Xunit;

namespace AOC2019.Tests.Four
{
    public class DayFourTests
    {
        private const string Input = "Four/Four.txt";

        [Fact]
        public void PartOne()
        {
            var input = File.ReadAllLines(Input);

            var result = NewDay().CalculatePartOne(input);
        }   

        [Fact]
        public void PartTwo()
        {

            var input = File.ReadAllLines(Input);

            var result = NewDay().CalculatePartTwo(input);
        }
        
        [Fact]
        public void ParseRecord_BeginShift()
        {
            var content = @"[1518-11-01 00:00] Guard #10 begins shift";

            var result = NewDay().ParseRecord(content);

            result.DateTime.Should().Be(new DateTime(1518, 11, 1, 0, 0, 0));
            result.EventType.Should().Be(EventType.BeginShift);
            result.GuardId.Should().Be(10);
        }

        [Fact]
        public void ParseRecord_FallAsleep()
        {
            var content = @"[1518-11-01 00:05] falls asleep";

            var result = NewDay().ParseRecord(content);

            result.DateTime.Should().Be(new DateTime(1518, 11, 1, 0, 5, 0));
            result.EventType.Should().Be(EventType.FallsAsleep);
            result.GuardId.Should().BeNull();
        }

        [Fact]
        public void ParseRecord_WakesUp()
        {
            var content = @"[1518-11-01 00:25] wakes up";

            var result = NewDay().ParseRecord(content);

            result.DateTime.Should().Be(new DateTime(1518, 11, 1, 0, 25, 0));            
            result.EventType.Should().Be(EventType.WakesUp);
            result.GuardId.Should().BeNull();
        }

        private DayFour NewDay()
        {
            return new DayFour();
        }
    }
}
