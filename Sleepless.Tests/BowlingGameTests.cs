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

        private void RollSpare()
        {
            _myGame.Roll(5);
            _myGame.Roll(5);
        }

        private void RollStrike()
        {
            _myGame.Roll(10);
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

        [Fact]
        public void Rolling_a_Spare_followed_by_3_scores_16()
        {
            _myGame = GetNewGame();
            RollSpare();
            _myGame.Roll(3);
            RollMany(0,17);
            _myGame.Score().Should().Be(16);
        }

        [Fact]
        public void Rolling_a_Strike_followed_by_3_followed_by_5_scores_26()
        {
            _myGame = GetNewGame();
            RollStrike();
            _myGame.Roll(3);
            _myGame.Roll(5);
            RollMany(0,16);
            _myGame.Score().Should().Be(26);
        }
    }
}
