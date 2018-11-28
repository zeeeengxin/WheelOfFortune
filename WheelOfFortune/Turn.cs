using System;
namespace WheelOfFortune
{
    public class Turn
    {
        Player player;
        Challenge challenge;
        Wheel wheel;
        const string Spin = "1";
        const string Solve = "2";
        bool bankrupt = false;
        bool loseTurn = false;
        bool solved = false;

        public Turn(Player player, Challenge challenge, Wheel wheel)
        {
            this.player = player;
            this.challenge = challenge;
            this.wheel = wheel;
        }
        // return solved the answer or not
        public bool PlayATurn()
        {          
            while (!solved && !bankrupt && !loseTurn)
            {
                challenge.PrintCurrentPuzzle();
                string userAction = GetUserAction();
                if (userAction == Spin)
                {
                    SpinWheelAndGuessLetter();
                } else if (userAction == Solve)
                {
                    SolvePuzzle();
                }
            }
            return solved;
        }
        private void SpinWheelAndGuessLetter()
        {
            int wheelResult = wheel.Spin();
            if (wheelResult == 0) 
            {
                Console.WriteLine("Uh, you lose a turn");
                loseTurn = true;
            } else if (wheelResult < 0)
            {
                Console.WriteLine("Sorry, bankrupt...");
                player.CurrentMoney = 0;
                bankrupt = true;
            } else
            {
                Console.WriteLine("You will get ${0} for each correct letter! Guess a letter please", wheelResult);
                char guessedLetter = Console.ReadKey().KeyChar;
                int count = challenge.CheckLetter(guessedLetter);
                if (count == 0) 
                {
                    Console.WriteLine("The answer doesn't include this letter");
                    loseTurn = true;
                } else 
                {
                    player.CurrentMoney += wheelResult * count;
                    Console.WriteLine();
                    Console.WriteLine("Great job! You won ${0} for {1} correct letters!", wheelResult * count, count);
                }
            }
        }
        private void SolvePuzzle()
        {
            Console.WriteLine("Enter the answer below:");
            string guessedAnswer = Console.ReadLine();
            if (challenge.CheckAnswer(guessedAnswer)) 
            {
                player.TotalMoney += player.CurrentMoney;
                solved = true;
            }
            else 
            {
                Console.WriteLine("This is not the answer");
                loseTurn = true;
            }
        }
        private string GetUserAction()
        {           
            Console.WriteLine("Hello {0}! Press {1} to spin the wheel or {2} to solve the challenge!", player.Name, Spin, Solve);
            return Console.ReadLine();
        }
    }
}
