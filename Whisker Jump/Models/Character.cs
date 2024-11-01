using System.Numerics;
using Whisker_Jump.Models;

namespace Whisker_Jump.Models
{
    public class Character
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        private const float Gravity = 0.5f;
        private const float JumpPower = -12f;
    }
}
