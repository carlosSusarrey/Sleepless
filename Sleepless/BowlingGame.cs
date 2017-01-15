namespace Sleepless
{
    public class BowlingGame
    {
        private int[] _rolls = new int[21];
        private int _currentRoll = 0;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;
            for (var frame = 0; frame < 10; frame ++)
            {
                if (IsSpare(frameIndex))
                {
                    score = score + 10 + _rolls[frameIndex + 2];
                }
                else
                {
                    score = score + _rolls[frameIndex] + _rolls[frameIndex + 1];
                }
                frameIndex += 2;
            }
            return score;
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}