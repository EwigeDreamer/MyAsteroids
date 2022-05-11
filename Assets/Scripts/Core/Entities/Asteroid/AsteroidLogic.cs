using UnityEngine;

namespace Core
{
    public class AsteroidLogic : EntityLogic<Asteroid>
    {   
        public void CreateAsteroid(
            Vector2 position,
            Vector2 velocity,
            float angular_velocity,
            int tier)
        {
            var rotation = Random.Range(-180f, 180f);
            var asteroid = GameHelper.CreateAsteroid(position, rotation, velocity, angular_velocity, tier);
            Register(asteroid);
        }
    }
}