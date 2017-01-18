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
        private BowlingGame _myGame;
        private BowlingGame GetNewGame()
        {
            return new BowlingGame();
        }

        private void RollMany(int pins, int times)
        {
            for (var i = 0; i < times; i++)
            {
                _myGame.Roll(pins);
            }   
        }

        [Fact]
        public void Rolling_all_misses_Scores_zero()
        {
            _myGame = GetNewGame();
            RollMany(0,20);
            _myGame.Score().Should().Be(0);
        }

        [Fact]
        public void Rolling_all_ones_Scores_20()
        {
            _myGame = GetNewGame();
            RollMany(1,20);
            _myGame.Score().Should().Be(20);
        }
    }
}
