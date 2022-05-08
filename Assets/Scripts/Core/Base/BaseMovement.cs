using System;
using UnityEngine;

namespace Core
{
    public class BaseMovement
    {
        public Vector2 Position { get; set; } = default;
        public float Rotation { get; set; } = default;

        public virtual void Update(float delta_time) { }
    }
}