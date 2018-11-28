using System;
namespace WheelOfFortune
{
    public class Round
    {
        private readonly int roundNum;
        private readonly Player[] players;
        private readonly Challenge challenge;
        private int currentPlayerIndex;
        private readonly int numOfPlayers;
        private bool solved;

        public Round(int n, Player[] players, int prevWinnerIndex)
        {
            roundNum = n;
            this.players = players;
            this.challenge = new Challenge();
            this.currentPlayerIndex = prevWinnerIndex;
            this.numOfPlayers = players.Length;
        }
        // return index of winner
        public int PlayARound()
        {
            while (!solved)
            {
                Turn newTurn = new Turn(players[currentPlayerIndex], challenge);
                solved = newTurn.PlayATurn();
            }
            return GetWinner();
        }
        private void GetNextPlayerIndex()
        {
            if (currentPlayerIndex == players.Length)
            {
                currentPlayerIndex = 0;
            } else
            {
                currentPlayerIndex++;
            }
        }
        private int GetWinner()
        {
            Player winner = players[0];
            int winnerIndex = 0;
            for (int i = 1; i < numOfPlayers; i++)
            {
                if (players[i].CurrentMoney > winner.CurrentMoney)
                {
                    winner = players[i];
                    winnerIndex = i;
                }
            }
            winner.TotalMoney += winner.CurrentMoney;
            Console.WriteLine("The winner for Round " + roundNum + " is " + winner.Name + "! You won $" + winner.CurrentMoney + "! Congrats!");
            return winnerIndex;
        }
    }
}
