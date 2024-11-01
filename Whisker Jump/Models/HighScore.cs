﻿using Microsoft.Maui.Storage;

namespace Whisker_Jump.Models
{
    public class HighScore
    {
        public int Value { get;  set; }
        public int CurrentSessionScore { get;  set; }

        public HighScore()
        {
            Value = Load();
            CurrentSessionScore = 0;
        }

        public void Save(int score)
        {
            if (score > Value)
            {
                Value = score;
                Preferences.Set("HighScore", Value);
                Console.WriteLine($"High Score Saved: {Value}");
            }
        }

        public int Load()
        {
            return Preferences.Get("HighScore", 0);
        }
    }
}

