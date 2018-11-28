using System;
namespace WheelOfFortune
{
    public class Wheel
    {
        readonly int[] choices = { 100, 200, 300, 400, 500, -1, 0 };
        public Wheel(int roundNum)
        {
            if (roundNum > 0) 
            {
                for (int i = 0; i < choices.Length; i++) 
                {
                    choices[i] = (int)((roundNum * 0.5 + 1) * choices[i]);
                }
            } 
        }
        public int Spin() 
        {
            Random random = new Random();
            int index = random.Next(choices.Length);
            return choices[index];
        }
    }
}
