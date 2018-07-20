namespace BowlingGame
{
    /*
     * TODO: Since intermediate scores for frames is not neccessary, I did not abstract away frame as a class.
     * But once Frame class is added, methods like IsStrike, IsSpare, GetStrikePoints, etc... must be moved there.
     */

    public class Game
    {
        private readonly int[] _rolls = new int[21]; // Maximum possible roll count is 21
        private int _currentRollIndex;

        public int Score
        {
            get
            {
                var totalScore = 0;
                var roll = 0;

                for (var frame = 0; frame <= 9; frame++) // 10 frames
                {
                    if (IsStrike(roll))
                    {
                        totalScore += GetStrikePoints(roll);
                        roll++; // if strike then next frame starts immediately with the next roll.
                    }
                    else if (IsSpare(roll))
                    {
                        totalScore += GetSparePoints(roll);
                        roll += 2; // next frame starts two rolls further from current roll index.
                    }
                    else
                    {
                        totalScore += GetPoints(roll);
                        roll += 2; // next frame starts two rolls further from current roll index.
                    }
                }

                return totalScore;
            }
        }

        public void Roll(int pins)
        {
            _rolls[_currentRollIndex++] = pins;
        }

        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }

        private int GetStrikePoints(int roll)
        {
            // (10 points from strike) + next two rolls.
            return 10 + _rolls[roll + 1] + _rolls[roll + 2];
        }

        private int GetSparePoints(int roll)
        {
            // (10 points from spare) + next frame's first roll.
            return 10 + _rolls[roll + 2];
        }

        private int GetPoints(int roll)
        {
            // if neither strike nor spare then simply take sum of two rolls.
            return _rolls[roll] + _rolls[roll + 1];
        }
    }
}