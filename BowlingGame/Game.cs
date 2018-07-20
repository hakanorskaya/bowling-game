namespace BowlingGame
{
    public class Game
    {
        private readonly int[] _rolls = new int[21]; // Since when last frame is spare or strike max possible roll count is 21
        private int _currentRollIndex;

        public int Score
        {
            get
            {
                var totalScore = 0;
                var rollIndex = 0;
                for (int frame = 0; frame <= 9; frame++) // 10 frames
                {
                    if (_rolls[rollIndex] + _rolls[rollIndex + 1] == 10) // if spare
                    {
                        totalScore += _rolls[rollIndex] + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
                    }
                    else
                    {
                        totalScore += _rolls[rollIndex] + _rolls[rollIndex + 1];
                    }

                    rollIndex += 2;
                }

                return totalScore;
            }
        }

        public void Roll(int pins)
        {
            _rolls[_currentRollIndex] = pins;
            _currentRollIndex++;
        }
    }
}