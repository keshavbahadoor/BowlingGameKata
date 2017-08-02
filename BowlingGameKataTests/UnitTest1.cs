using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameKata;

namespace BowlingGameKataTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class BowlingGameTest
        {
            private Game game; 

            /// <summary>
            /// Runs before every test. 
            /// </summary>
            [TestInitialize]
            public void SetUp()
            {
                game = new Game(); 
            }

            /// <summary>
            /// used to call roll on game 
            /// </summary>
            /// <param name="n"></param>
            /// <param name="pins"></param>
            private void RollMany(int n, int pins)
            {
                for (int i = 0; i < n; i++)
                {
                    game.Roll(pins);
                }
            }

            [TestMethod]
            public void TestGutterGame()
            {
                this.RollMany(20, 0); 
                Assert.AreEqual(0, game.Score()); 
            }

            [TestMethod]
            public void TestAllOnes()
            {
                this.RollMany(20, 1); 
                Assert.AreEqual(20, game.Score());
            }

            [TestMethod]
            public void TestOneSpare()
            {
                RollSpare();
                game.Roll(3);
                RollMany(17, 0);
                Assert.AreEqual(16, game.Score());
            }

            [TestMethod]
            public void TestOneStrike()
            {
                RollStrike();
                game.Roll(3);
                game.Roll(4);
                RollMany(16, 0);
                Assert.AreEqual(24, game.Score()); 
            }

            [TestMethod]
            public void TestPerfectGame()
            {
                RollMany(12, 10);
                Assert.AreEqual(300, game.Score());
            }

            private void RollStrike()
            {
                game.Roll(10); 
            }
             
            private void RollSpare()
            {
                game.Roll(5);
                game.Roll(5); 
            }


        }
    }
}
