﻿using System;
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
            private set;
        }

        public int TotalMoney 
        {
            get;
            private set;
        }

        public Player(string name)
        {
            Name = name;
        }
    }
}
