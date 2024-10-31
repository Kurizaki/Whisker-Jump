using Microsoft.Maui.Storage;

namespace Whisker_Jump.Models
{
    public class HighScore
    {
        public int Value { get; set; } // All-time high score
        public int CurrentSessionScore { get; set; } // High score for the current session

        public HighScore()
        {
            Value = Load();
            CurrentSessionScore = 0;
        }

        // Save method for the all-time high score
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

        // Method to reset the session score
        public void ResetSessionScore()
        {
            CurrentSessionScore = 0;
        }

        // Update the current session high score if the new score is higher
        public void UpdateSessionScore(int score)
        {
            if (score > CurrentSessionScore)
            {
                CurrentSessionScore = score;
            }
        }
    }
}
