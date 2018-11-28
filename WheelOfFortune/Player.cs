using System;
namespace WheelOfFortune
{
    public class Player
    {
        public string Name 
        {
            get;
            private set;
        }

        public int CurrentMoney 
        {
            get;
            internal set;
        }

        public int TotalMoney 
        {
            get;
            internal set;
        }

        public Player(string name)
        {
            Name = name;
        }
    }
}
