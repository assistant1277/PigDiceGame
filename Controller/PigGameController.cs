using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Controller
{
    internal class PigGameController
    {
        private int playerTotalScore;
        private int currentTurnScore;
        private int lastRoll;

        public PigGameController()
        {
            playerTotalScore = 0;
            currentTurnScore = 0;
            lastRoll = 0;
        }

        public void Roll()
        {
            Random random = new Random();
            lastRoll = random.Next(1, 7);

            if (lastRoll == 1)
            {
                currentTurnScore = 0; 
            }
            else
            {
                currentTurnScore += lastRoll; 
            }
        }

        public void Hold()
        {
            playerTotalScore += currentTurnScore; 
            currentTurnScore = 0; 
        }

        public int GetPlayerTotalScore()
        {
            return playerTotalScore;
        }

        public int GetCurrentTurnScore()
        {
            return currentTurnScore;
        }

        public int GetLastRoll()
        {
            return lastRoll; 
        }

        public bool CheckWin()
        {
            return playerTotalScore >= 20; 
        }

        public bool HasTurnEnded()
        {
            return currentTurnScore == 0; 
        }
    }
}
