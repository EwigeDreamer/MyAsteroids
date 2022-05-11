using UnityEngine;

namespace Core
{
    public class UfoLogic : EntityLogic<Ufo>
    {
        
        public void CreateUfo(
            Vector2 position,
            float velocity)
        {
            var ufo = GameHelper.CreateUfo(position, velocity);
            Register(ufo);
        }

        public void SetTarget(Vector2 target)
        {
            for (int i = 0; i < m_Entities.Count; ++i)
            {
                m_Entities[i].UfoMovement.Target = target;
            }
        }
    }
}