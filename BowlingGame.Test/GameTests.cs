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
            for (int i = 0; i <= 19; i++)
            {
                _game.Roll(0);
            }

            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void Get_Twenty_Points_If_All_Ones_Rolled()
        {
            // 11 11 11 11 11 11 11 11 11 11
            for (int i = 0; i <= 19; i++)
            {
                _game.Roll(1);
            }

            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void Get_Twenty_Points_If_Spared_Once_And_Then_All_Zeroes_Rolled()
        {
            // 5/ 5- -- -- -- -- -- -- -- --
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);

            // Roll zero, 17 times.
            for (int i = 0; i <= 16; i++)
            {
                _game.Roll(0);
            }

            Assert.AreEqual(20, _game.Score);
        }
    }
}