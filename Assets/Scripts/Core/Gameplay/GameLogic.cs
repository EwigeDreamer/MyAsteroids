using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class GameLogic : IDisposable
    {
        public event Action<BaseMediator> OnCreateEntity;
        
        private Vector2 m_FieldSize;

        private List<BaseEntityLogic> m_Logics;

        public PlayerMediator Mediator { get; private set; } = null;

        public GameLogic(Vector2 field_size)
        {
            m_FieldSize = field_size;
        }

        public void CreateAsteroid(
            Vector2 position,
            Vector2 velocity,
            float angular_velocity,
            int tier)
        {
            var rotation = Random.Range(-180f, 180f);
            var asteroid = GameHelper.CreateAsteroid(position, rotation, velocity, angular_velocity, tier);
            RegisterEntity(asteroid);
        }

        public void CreteUfo(
            Vector2 position,
            float velocity)
        {
            var ufo = GameHelper.CreateUfo(position, velocity);
            RegisterEntity(ufo);
        }

        private void RegisterEntity(BaseEntity entity)
        {
            if (entity == null) return;
            if (m_Entities.Contains(entity)) return;
            m_Entities.Add(entity);
        }
        private void UnregisterEntity(BaseEntity entity)
        {
            if (entity == null) return;
            if (!m_Entities.Contains(entity)) return;
            m_Entities.Remove(entity);
        }

        public void Dispose()
        {
            foreach (var entity in m_Entities) entity.Dispose();
            m_Entities.Clear();
            
            Mediator.Dispose();
            Mediator = null;
        }
    }

    public static class GameHelper
    {
        
        
        public static Player CreatePlayer()
        {
            var player = new Player();
            player.Movement.Position = Vector2.zero;
            player.Movement.Rotation = 0f;
            player.RegularMovement.Velocity = Vector2.zero;
            player.RegularMovement.AngularVelocity = 0f;
            return player;
        }


        public static Asteroid CreateAsteroid(
            Vector2 position,
            float rotation,
            Vector2 velocity,
            float angular_velocity,
            int tier)
        {
            var asteroid = new Asteroid();
            asteroid.Movement.Position = position;
            asteroid.Movement.Rotation = rotation;
            asteroid.RegularMovement.Velocity = velocity;
            asteroid.RegularMovement.AngularVelocity = angular_velocity;
            asteroid.Tier = tier;
            return asteroid;
        }

        public static Ufo CreateUfo(
            Vector2 position,
            float velocity)
        {
            var ufo = new Ufo();
            ufo.Movement.Position = position;
            ufo.Movement.Rotation = 0f;
            ufo.UfoMovement.Target = Vector2.zero;
            ufo.UfoMovement.Velocity = velocity;
            return ufo;
        }
    }
}