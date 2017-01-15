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
            foreach (var t in _rolls)
            {
                score = score + t;
            }
            return score;
        }
    }
}