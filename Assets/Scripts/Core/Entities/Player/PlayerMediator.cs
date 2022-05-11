using UnityEngine;

namespace Core
{
    public class PlayerMediator : Mediator<Player>
    {
        public PlayerMediator(Player player) : base(player) { }

        public void AddForce(float force)
        {
            m_Entity.PlayerMovement.Force = force;
        }

        public void SetAngularVelocity(float angular_velocity)
        {
            m_Entity.PlayerMovement.TargetAngularVelocity = angular_velocity;
        }
        
        
    }
}
