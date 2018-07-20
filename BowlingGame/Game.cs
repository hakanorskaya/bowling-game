namespace BowlingGame
{
    public class Game
    {
        private readonly int[] _rolls = new int[21]; // Maximum possible roll count is 21
        private int _currentRollIndex;

        public int Score
        {
            get
            {
                var totalScore = 0;
                var rollIndex = 0;

                for (var frame = 0; frame <= 9; frame++) // 10 frames
                {
                    if (IsStrike(rollIndex))
                    {
                        totalScore += GetStrikePoints(rollIndex);
                        rollIndex++;
                    }
                    else if (IsSpare(rollIndex))
                    {
                        totalScore += GetSparePoints(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        totalScore += GetPoints(rollIndex);
                        rollIndex += 2;
                    }
                }

                return totalScore;
            }
        }

        public void Roll(int pins)
        {
            _rolls[_currentRollIndex++] = pins;
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;
        }

        private int GetStrikePoints(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
        }

        private int GetSparePoints(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
        }

        private int GetPoints(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1];
        }
    }
}