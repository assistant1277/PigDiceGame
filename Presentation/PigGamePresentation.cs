using PigDiceGame.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Presentation
{
    internal class PigGamePresentation
    {
        public static void StartGame()
        {
            PigGameController gameController = new PigGameController();

            Console.WriteLine("***** welcome to pig dice game *****");

            while (true)
            {
                Console.WriteLine($"\ncurrent total score -> {gameController.GetPlayerTotalScore()}");
                Console.WriteLine($"current turn score -> {gameController.GetCurrentTurnScore()}");

                string userInput;
                do
                {
                    Console.Write("\ndo you want to roll again (r) or hold(h) ? => ");
                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "r")
                    {
                        gameController.Roll();
                        if (gameController.GetCurrentTurnScore() > 0)
                        {
                            Console.WriteLine($"you rolled a dice and value is -> {gameController.GetLastRoll()}");
                            Console.WriteLine($"current turn score -> {gameController.GetCurrentTurnScore()}");

                            if (gameController.GetPlayerTotalScore() + gameController.GetCurrentTurnScore() >= 20)
                            {
                                gameController.Hold();
                                Console.WriteLine($"\ncongratulations you win with score of {gameController.GetPlayerTotalScore()}");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("you rolled 1(means you rolled dice and value comes 1) and no points for this turn");
                        }
                    }
                    else if (userInput == "h")
                    {
                        gameController.Hold();
                        Console.WriteLine($"you held and total score -> {gameController.GetPlayerTotalScore()}");

                        if (gameController.CheckWin())
                        {
                            Console.WriteLine($"\ncongratulations you win with score of {gameController.GetPlayerTotalScore()}");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid input please enter 'r' or 'h'");
                    }

                } while (!gameController.HasTurnEnded() && userInput != "h");

                if (gameController.CheckWin())
                {
                    Console.WriteLine($"\ncongratulations you win with score of {gameController.GetPlayerTotalScore()}");
                    return;
                }
            }
        }
    }
}
