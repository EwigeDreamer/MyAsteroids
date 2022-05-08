using UnityEngine;

namespace Core
{
    public class UfoMovement : BaseMovement
    {
        public Vector2 Target { get; set; } = default;
        public float Velocity { get; set; } = default;

        public override void Update(float delta_time)
        {
            var dir = (Target - Position).normalized;
            Position += dir * Velocity * delta_time;
        }
    }
}
