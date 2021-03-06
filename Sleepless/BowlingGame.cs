namespace Sleepless
{
    public class BowlingGame
    {
        private readonly int[] _rolls = new int[21];
        private int _rollCount = 0;

        public void Roll(int pins)
        {
            _rolls[_rollCount++] = pins;
        }

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score = score + 10 + StrikeBonus(frameIndex);
                    frameIndex ++;
                }else if (IsSpare(frameIndex))
                {
                    score = score + 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score = _rolls[frameIndex] + _rolls[frameIndex + 1] + score;
                    frameIndex += 2;
                }  
            }
        
            return score;
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}