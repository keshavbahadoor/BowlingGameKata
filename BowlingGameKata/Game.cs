using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    /// <summary>
    /// For scoring, see: 
    /// http://www.bowlinggenius.com/ 
    /// </summary>
    public class Game
    {
        private int score = 0;
        private int[] rolls = new int[21];
        private int currentRoll = 0; 

        /// <summary>
        /// Called each time the player rolls a ball 
        /// </summary>
        /// <param name="pins">number of pins knocked down</param>
        public void Roll(int pins)
        { 
            rolls[currentRoll++] = pins;
        }

        /// <summary>
        /// Called only at the very end of the game 
        /// </summary>
        /// <returns>total score for this game</returns>
        public int Score()
        {
            int score = 0;
            int frameIndex = 0; 
            for (int frame=0; frame<10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;  
                }
                else if (IsSpare(frameIndex))
                { 
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }                                
            }
            return score; 
        }

        /// <summary>
        /// Checks if a strike occured 
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10; 
        }

        /// <summary>
        /// Checks if spare 
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10; 
        }

        /// <summary>
        /// calculates strike bonus 
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2]; 
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2]; 
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1]; 
        }
    }
}
