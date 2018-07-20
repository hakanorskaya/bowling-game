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
            // -- -- -- -- -- -- -- -- -- --
            RollMany(20, 0);

            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void Get_Twenty_Points_If_All_Ones_Rolled()
        {
            // 11 11 11 11 11 11 11 11 11 11
            RollMany(20, 1);

            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void Get_Twenty_Points_If_Spared_Once_Then_Five_And_Then_All_Zeroes_Rolled()
        {
            // 5/ 5- -- -- -- -- -- -- -- --
            RollMany(3, 5);
            RollMany(17, 0);

            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void Get_Sixteen_Points_If_Striked_Once_Then_One_And_Two_And_Then_All_Zeroes_Rolled()
        {
            // X 12 -- -- -- -- -- -- -- --
            _game.Roll(10);
            _game.Roll(1);
            _game.Roll(2);

            RollMany(16, 0);

            Assert.AreEqual(16, _game.Score);
        }

        [TestMethod]
        public void Get_Three_Hundred_Points_If_All_Striked()
        {
            // X X X X X X X X X X X X
            RollMany(12, 10);

            Assert.AreEqual(300, _game.Score);
        }

        [TestMethod]
        public void Get_Ninety_Points_If_All_Frames_Are_Nines_And_Misses()
        {
            // 9- 9- 9- 9- 9- 9- 9- 9- 9- 9-
            for (int i = 0; i <= 9; i++)
            {
                _game.Roll(9);
                _game.Roll(0);
            }

            Assert.AreEqual(90, _game.Score);
        }

        [TestMethod]
        public void Get_Hundred_And_Fifty_Points_If_All_Fives_Rolled()
        {
            // 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5
            RollMany(21, 5);

            Assert.AreEqual(150, _game.Score);
        }

        private void RollMany(int times, int pins)
        {
            for (var i = 0; i <= times - 1; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}