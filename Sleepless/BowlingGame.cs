namespace Sleepless
{
    public class BowlingGame
    {
        private int TrackedScore;
        public void Roll(int pins)
        {
            TrackedScore = TrackedScore + pins;
        }

        public int Score()
        {
            return TrackedScore;
        }
    }
}