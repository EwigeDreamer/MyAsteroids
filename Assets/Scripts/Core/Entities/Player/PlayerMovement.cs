using UnityEngine;

namespace Core
{
    public class PlayerMovement : BaseMovement
    {
        public Vector2 Velocity { get; set; } = default;

        public float Force { get; set; } = default;

        private float m_CurrentAngularVelocity = default;
        public float TargetAngularVelocity { get; set; } = default;
        public override void Update(float delta_time)
        {
            Velocity = ApplyForce(Velocity, delta_time);
            Position += Velocity * delta_time;
            Rotation += m_CurrentAngularVelocity * delta_time;
            m_CurrentAngularVelocity = Mathf.Lerp(
                m_CurrentAngularVelocity, 
                TargetAngularVelocity, 
                delta_time * 10f);
            TargetAngularVelocity = 0f;//сброс, если перестали нажимать поворот
        }

        private Vector2 ApplyForce(Vector2 velocity, float delta_time)
        {
            var mass = 1f;
            var acceleration = Force / mass;
            velocity += this.Forward() * acceleration * delta_time;
            velocity = ClampVelocity(velocity);
            Force = 0f;
            return velocity;
        }

        private Vector2 ClampVelocity(Vector2 velocity)
        {
            var max_velocity = 10f;
            if (velocity.magnitude <= max_velocity) return velocity;
            return velocity.normalized * max_velocity;
        }
    }
}