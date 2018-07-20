using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CreatesGame()
        {
            var game = new Game();
        }
    }
}