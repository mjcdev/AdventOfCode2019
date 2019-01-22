using AOC2019.Nine;
using AOC2019.Nine.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AOC2019.Tests.Nine
{
    public class DayNineTests
    {
        [Fact]
        public void PartOne()
        {
            var result = NewDay().PartOne(476, 71657);
        }

        [Fact]
        public void PartTwo()
        {
            var result = NewDay().PartOne(476, 71657 * 100);
        }

        [Theory]
        [InlineData(10, 1618, 8317)]
        [InlineData(13, 7999, 146373)]
        [InlineData(17, 1104, 2764)]
        [InlineData(21, 6111, 54718)]
        [InlineData(30, 5807, 37305)]
        public void Examples(int playerCount, int lastMarbleWorth, int maxScore)
        {
            NewDay().PartOne(playerCount, lastMarbleWorth).Should().Be(maxScore);
        }

        [Theory]
        [InlineData(23)]
        [InlineData(46)]
        public void IsScoringMarble_True(int marble)
        {
            NewDay().IsScoringMarble(marble).Should().BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(24)]
        public void IsScoringMarble_False(int marble)
        {
            NewDay().IsScoringMarble(marble).Should().BeFalse();
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(3, 2, 0)]
        public void IncrementPlayer(int playerCount, int currentPlayer, int incrementedCurrentPlayer)
        {
            NewDay().IncrementPlayer(currentPlayer, playerCount).Should().Be(incrementedCurrentPlayer);
        }

        [Fact]
        public void NoScore()
        {
            var game = new Game(3, 0);

            game.Marbles = new List<int>() { 0, 2, 1, 3, };
            game.CurrentMarbleIndex = 3;
            game.CurrentMarble = 4;

            NewDay().NoScore(game);

            game.Marbles.Should().HaveCount(5);
            game.Marbles.Should().ContainInOrder(0, 4, 2, 1, 3);
        }

        private DayNine NewDay()
        {
            return new DayNine();
        }
    }
}
