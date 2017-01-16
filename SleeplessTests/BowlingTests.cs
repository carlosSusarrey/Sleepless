using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sleepless;
using Xunit;

namespace SleeplessTests
{
    public class BowlingTests
    {
        private BowlingGame g;
        protected void SetUp()
        {
            g = new BowlingGame();
        }

        private void RollMany(int pins, int times)
        {
            for (var i = 0; i < times; i++)
            {
                g.Roll(pins);
            }
        }

        [Fact]
        public void Rolling_all_misses_scores_zero()
        {
            SetUp();
            RollMany(0,20);
            g.Score().Should().Be(0);
        }

        [Fact]
        public void Rolling_all_ones_scores_20()
        {
            SetUp();
            RollMany(1,20);
            g.Score().Should().Be(20);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 20)]
        public void Score_depends_on_pins_rolled(int pins, int expectedScore)
        {
            SetUp();
            RollMany(pins,20);
            g.Score().Should().Be(expectedScore);
        }

        [Theory]
        [InlineData(3,16)]
        [InlineData(2,14)]
        [InlineData(8,26)]
        public void Test_one_spare_followed_by_score_and_misses(int pins, int expectedScore)
        {
            SetUp();
            RollSpare();
            g.Roll(pins);
            RollMany(0,17);
            g.Score().Should().Be(expectedScore);
        }

        [Theory]
        [InlineData(3,4, 24)]
        [InlineData(2,2, 18)]
        [InlineData(8,1, 28)]
        public void Test_one_strike_followed_by_score_and_misses(int firstRoll,int secondRoll, int expectedScore)
        {
            SetUp();
            RollStrike();
            g.Roll(firstRoll);
            g.Roll(secondRoll);
            RollMany(0, 16);
            g.Score().Should().Be(expectedScore);
        }

        [Fact]
        public void A_perfect_game_scores_300_points()
        {
            SetUp();
            RollMany(10,12);
            g.Score().Should().Be(300);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
