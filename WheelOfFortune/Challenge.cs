using System;
namespace WheelOfFortune
{
    public class Challenge
    {
        // hard code answerPool
        private readonly string[] answerPool = new string[]{
            "This is the answer to the challenge",
            "This is another answer",
            "Here comes another answer" };
        private readonly string answer;
        private char[] currentPuzzle;

        public Challenge(int roundNum)
        {
            answer = answerPool[roundNum];
            CreatePuzzle();
        }
        public void PrintCurrentPuzzle()
        {
            Console.WriteLine("Here's the challenge: {0}", string.Join("", currentPuzzle));
        }
        public int CheckLetter(char guessedLetter) 
        {
            int count = 0;
            for (int i = 0; i < currentPuzzle.Length; i++)
            {
                if (Char.ToLower(answer[i]) == Char.ToLower(guessedLetter)) {
                    count++;
                    currentPuzzle[i] = guessedLetter;
                }
            }
            return count;
        }
        public bool CheckAnswer(string guessedAnswer) 
        {
            return answer.Equals(guessedAnswer, StringComparison.InvariantCultureIgnoreCase);
        }
        private void CreatePuzzle()
        {
            currentPuzzle = new char[answer.Length];
            for (int i = 0; i < answer.Length; i++)
            {   
                if (Char.IsLetter(answer[i]))
                {
                    currentPuzzle[i] = '_';
                } else
                {
                    currentPuzzle[i] = answer[i];
                }
            }
        }
        //private void CreateAnswer()
        //{
        //    Random random = new Random();
        //    int answerIndex = random.Next(answerPool.Length);
        //    answer = answerPool[answerIndex];
        //}
    }
}
