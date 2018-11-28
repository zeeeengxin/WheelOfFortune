using System;
namespace WheelOfFortune
{
    public class Game
    {
        Player[] players;
        const int NumOfPlayers = 3;
        const int NumOfRounds = 3;
        const char StartKey = 's';
        const char EndKey = 'e';

        public Game()
        {
            players = new Player[NumOfPlayers];
        }

        // start the whole game
        public void Start() 
        {
            PrintWelcomeMessage();
            ShowMainMenu();
        }

        private void PrintWelcomeMessage() 
        {
            Console.WriteLine("Welcome to Wheel of Fortune!! Press any key to continue");
            Console.Read();           
        }

        private void ShowMainMenu() 
        {
            Console.WriteLine("Press 's' to start game, press 'e' to end game");
            char userSelectKey = '\0';
            while (userSelectKey != StartKey && userSelectKey != EndKey) 
            {
                userSelectKey = Console.ReadKey().KeyChar;               
            }
            if (userSelectKey == StartKey) 
            {
                PlayANewGame();
            } else 
            {
                Console.WriteLine("Thanks for playing! See you next time!");
            }
        }
        private void PlayANewGame() 
        {
            GetPlayers();
            int prevWinnerIndex = -1;
            for (int i = 0; i < NumOfRounds; i++) 
            {
                Round newRound = new Round(i, players, prevWinnerIndex);
                prevWinnerIndex = newRound.PlayARound();
            }
            GetWinner();
            ShowMainMenu();
        }
        private void GetPlayers() 
        {
            Console.WriteLine("This game requires three players");
            for (int i = 0; i < NumOfPlayers; i++) 
            {
                UserCreatePlayer(i);
            }
        }
        private void UserCreatePlayer(int index) 
        {
            Console.WriteLine("Please enter a name for player" + (index + 1));
            string name = Console.ReadLine();
            players[index] = new Player(name);
        }
        // only get one winner, can improve to show tie
        private void GetWinner() 
        {
            Player winner = players[0];
            for (int i = 1; i < NumOfPlayers; i++) {
                if (players[i].TotalMoney > winner.TotalMoney) {
                    winner = players[i];
                }
            }
            Console.WriteLine("The winner is " + winner.Name + "! You won $" + winner.TotalMoney + "! Congrats!");
        }
    }
}
