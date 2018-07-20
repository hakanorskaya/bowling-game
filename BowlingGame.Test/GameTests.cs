using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Create_Game()
        {
            var game = new Game();
        }

        [TestMethod]
        public void Get_Zero_Points_If_All_Zeroes_Rolled()
        {
            var game = new Game();

            for (int i = 0; i <= 19; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(game.Score, 0);
        }
    }
}