using System;
namespace WheelOfFortune
{
    public class Game
    {
        // Player[] players;

        public Game()
        {
        }

        // start the whole game
        public void StartGame() {
            PrintWelcomeMessage();
            StartMainMenu();
        }

        private void PrintWelcomeMessage() {
            Console.WriteLine("Welcome to Wheel of Fortune!! Press any key to continue");
            Console.Read();           
        }

        private void StartMainMenu() {
            Console.WriteLine("Press 's' to start game, press 'e' to end game");
            char userSelectKey = '\0';
            while (userSelectKey != 's' || userSelectKey != 'e') {
                userSelectKey = Console.ReadKey().KeyChar;
            }
        }
    }
}
