using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Sleepless.Tests
{
    public class BowlingGameTests
    {
        [Fact]
        public void Rolling_all_misses_Scores_zero()
        {
            BowlingGame newGame = new BowlingGame();
            for (var i = 0; i < 20; i++)
            {
                newGame.Roll(0);
            }
            newGame.Score().Should().Be(0);
        }
    }
}
