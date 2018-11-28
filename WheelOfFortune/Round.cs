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
        private readonly Wheel wheel;

        public Round(int roundNum, Player[] players, int prevWinnerIndex)
        {
            this.roundNum = roundNum;
            this.players = players;
            this.challenge = new Challenge(roundNum);
            this.currentPlayerIndex = prevWinnerIndex;
            this.numOfPlayers = players.Length;
            this.wheel = new Wheel(roundNum);
            ClearCurrentMoney();
        }
        private void ClearCurrentMoney() 
        {
            foreach (Player p in players) 
            {
                p.CurrentMoney = 0;
            }
        }
        // return index of winner
        public int PlayARound()
        {
            while (!solved)
            {
                GetNextPlayerIndex();
                Turn newTurn = new Turn(players[currentPlayerIndex], challenge, wheel);
                solved = newTurn.PlayATurn();
            }
            GetWinner();
            return currentPlayerIndex;
        }
        private void GetNextPlayerIndex()
        {
            if (currentPlayerIndex == players.Length - 1)
            {
                currentPlayerIndex = 0;
            } else
            {
                currentPlayerIndex++;
            }
        }
        private void GetWinner()
        {
            Player winner = players[currentPlayerIndex];
            // winner.TotalMoney += winner.CurrentMoney;
            Console.WriteLine("The winner for Round " + roundNum + " is " + winner.Name + "! You won $" + winner.CurrentMoney + "! Congrats!");            
        }
    }
}
