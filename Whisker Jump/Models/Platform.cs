using System.Numerics;

namespace Whisker_Jump.Models
{
    public class Platform
    {
        public Vector2 Position { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }

        private float speed = 2f;

        public Platform(Vector2 position, string type)
        {
            Position = position;
            Type = type;
            IsActive = true;
        }

        public void Move()
        {
            if (Type == "moving")
            {
                Position = new Vector2(Position.X + speed, Position.Y);

                if (Position.X > 100 || Position.X < -100)
                    speed *= -1;
            }
        }

        public void Break()
        {
            if (Type == "breaking")
            {
                IsActive = false;
            }
        }

        public void Update()
        {
            if (Type == "moving")
            {
                Move();
            }

            if (Position.Y > 800)
            {
                IsActive = false;
            }
        }
    }
}