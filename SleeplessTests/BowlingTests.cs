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

    }
}
