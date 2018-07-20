using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class GameTests
    {
        private Game _game;

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game();
        }

        [TestMethod]
        public void Get_Zero_Points_If_All_Zeroes_Rolled()
        {
            Roll("-- -- -- -- -- -- -- -- -- --");
            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void Get_Twenty_Points_If_All_Ones_Rolled()
        {
            Roll("11 11 11 11 11 11 11 11 11 11");
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void Get_Twenty_Points_If_Spared_Once_Then_Five_And_Then_All_Zeroes_Rolled()
        {
            Roll("5/ 5- -- -- -- -- -- -- -- --");
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void Get_Sixteen_Points_If_Striked_Once_Then_One_And_Two_And_Then_All_Zeroes_Rolled()
        {
            Roll("X 12 -- -- -- -- -- -- -- --");
            Assert.AreEqual(16, _game.Score);
        }

        [TestMethod]
        public void Get_Three_Hundred_Points_If_All_Striked()
        {
            Roll("X X X X X X X X X X X X");
            Assert.AreEqual(300, _game.Score);
        }

        [TestMethod]
        public void Get_Ninety_Points_If_All_Frames_Are_Nines_And_Misses()
        {
            Roll("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-");
            Assert.AreEqual(90, _game.Score);
        }

        [TestMethod]
        public void Get_Hundred_And_Fifty_Points_If_All_Fives_Rolled()
        {
            Roll("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5");
            Assert.AreEqual(150, _game.Score);
        }

        // TODO: All inputs must be sanitized before using. Because there is no error checking.
        private void Roll(string rolls)
        {
            rolls = string.Join("", rolls.Split()); // remove whitespaces

            for (var i = 0; i <= rolls.Length - 1; i++)
            {
                var roll = rolls[i];

                switch (roll)
                {
                    case '-':
                        _game.Roll(0);
                        break;

                    case 'X':
                        _game.Roll(10);
                        break;

                    case '/':
                        _game.Roll(10 - int.Parse(rolls[i - 1].ToString()));
                        break;

                    default:
                        _game.Roll(int.Parse(roll.ToString()));
                        break;
                }
            }
        }
    }
}