using System;
namespace WheelOfFortune
{
    public class Turn
    {
        Player player;
        Challenge challenge;
        const char Spin = '1';
        const char Solve = '2';
        bool bankrupt = false;
        bool loseTurn = false;
        bool solved = false;

        public Turn(Player player, Challenge challenge)
        {
            this.player = player;
            this.challenge = challenge;
        }
        // return solved the answer or not
        public bool PlayATurn()
        {
           
            while (!solved && !bankrupt && !loseTurn)
            {
                challenge.PrintCurrentPuzzle();
                char userAction = GetUserAction();
                if (userAction == Spin)
                {
                    spinWheelAndGuessLetter();
                } else
                {
                    solvePuzzle();
                }
            }
            return solved;
        }
        private void spinWheelAndGuessLetter()
        {

        }
        private void solvePuzzle()
        {

        }
        private char GetUserAction()
        {           
            Console.WriteLine("Hello {0}! Press {1} to spin the wheel or {2} to solve the challenge!", player.Name, Spin, Solve);
            return Console.ReadKey().KeyChar;
        }
    }
}
