using System.Numerics;

namespace Whisker_Jump.Models
{
    public class Fish
    {
        public Vector2 Position { get; set; }
        public bool IsCollected { get; private set; }

        public Fish(Vector2 position)
        {
            Position = position;
            IsCollected = false;
        }

        public void Collect()
        {
            IsCollected = true;
        }

        public void SpawnOnPlatform(Platform platform)
        {
            Position = new Vector2(platform.Position.X, platform.Position.Y - 20);
        }
    }
}