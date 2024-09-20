using System.Numerics;
using Whisker_Jump.Models;

namespace Whisker_Jump.Models
{
    public class Character
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Skin CurrentSkin { get; set; }

        private const float Gravity = 0.5f;
        private const float JumpPower = -12f;

        public Character()
        {
            Position = new Vector2(0, 0);
            Velocity = new Vector2(0, 0);
            CurrentSkin = new Skin();
        }

        public void MoveLeft()
        {
            Velocity = new Vector2(-5, Velocity.Y);
        }

        public void MoveRight()
        {
            Velocity = new Vector2(5, Velocity.Y);
        }

        public void Jump()
        {
            Velocity = new Vector2(Velocity.X, JumpPower);
        }

        public void UpdatePosition()
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity);
            Position += Velocity;
        }

        public void ResetPosition()
        {
            Position = new Vector2(0, 0);
            Velocity = new Vector2(0, 0);
        }

        public void ApplySkin(Skin skin)
        {
            CurrentSkin = skin;
        }
    }
}
