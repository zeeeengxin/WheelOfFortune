using System;
namespace WheelOfFortune
{
    public class Game
    {
        readonly Player[] players;
        const int NumOfPlayers = 3;
        const int NumOfRounds = 3;
        const string StartKey = "S";
        const string EndKey = "E";

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
            Console.WriteLine("Welcome to Wheel of Fortune!! Press Enter to continue");
            Console.Read();           
        }

        private void ShowMainMenu() 
        {
            string userSelectKey = String.Empty;
            while (!StartKey.Equals(userSelectKey, StringComparison.InvariantCultureIgnoreCase) &&
                   !EndKey.Equals(userSelectKey, StringComparison.InvariantCultureIgnoreCase)) 
            {
                Console.WriteLine("Press {0} to start game, press {1} to end game", StartKey, EndKey);
                userSelectKey = Console.ReadLine();               
            }
            if (StartKey.Equals(userSelectKey, StringComparison.InvariantCultureIgnoreCase)) 
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
