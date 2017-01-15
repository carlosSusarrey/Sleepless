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

        [Fact]
        public void Rolling_all_misses_scores_zero()
        {
            SetUp();
            for (var i = 0; i < 20; i++)
            {
                g.Roll(0);
            }
            g.Score().Should().Be(0);
        }

        [Fact]
        public void Rolling_all_ones_scores_20()
        {
            SetUp();
            for (var i = 0; i < 20; i++)
            {
                g.Roll(1);
            }
            g.Score().Should().Be(20);
        }
    }
}
