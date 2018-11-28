using System;
namespace WheelOfFortune
{
    public class Challenge
    {
        private readonly string[] answerPool = new string[]{
            "This is the answer of the challenge",
            "This is another answer",
            "Here comes another answer" };
        private string answer;
        private char[] currentPuzzle;

        public Challenge()
        {
            CreateAnswer();
            CreatePuzzle();
        }
        public void PrintCurrentPuzzle()
        {
            Console.WriteLine("Here's the challenge: {0}", string.Join("", currentPuzzle));
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
        private void CreateAnswer()
        {
            Random random = new Random();
            int answerIndex = random.Next(answerPool.Length);
            answer = answerPool[answerIndex];
        }
    }
}
