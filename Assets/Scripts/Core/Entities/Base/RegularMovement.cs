using UnityEngine;

namespace Core
{
    public class RegularMovement : BaseMovement
    {
        public Vector2 Velocity { get; set; } = default;
        public float AngularVelocity { get; set; } = default;
        public override void Update(float delta_time)
        {
            Position += Velocity * delta_time;
            Rotation += AngularVelocity * delta_time;
        }
    }
}
