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
                if (isSpare(frameIndex))
                {
                    score = 10 + _rolls[frameIndex + 2];
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

        private bool isSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}