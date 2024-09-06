namespace Whisker_Jump.Models
{
    public class HighScore
    {
        public int Value { get; set; }

        public HighScore()
        {
            Value = Load();
        }

        public void Save(int score)
        {
            if (score > Value)
            {
                Value = score;
                Preferences.Set("HighScore", Value);
            }
        }

        public int Load()
        {
            //return the high score from storage
            return 0;
        }
    }
}
