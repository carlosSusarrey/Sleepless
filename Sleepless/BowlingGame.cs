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
            var i = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (_rolls[i] + _rolls[i + 1] == 10)
                {
                    score = 10 + _rolls[i + 2];
                    i += 2;
                }
                else
                {
                    score = _rolls[i] + _rolls[i + 1] + score;
                    i += 2;
                }  
            }
        
            return score;
        }
    }
}