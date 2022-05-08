using UnityEngine;

namespace Core
{
    public static class MovementEx
    {
        public static Vector2 Forward<T>(this T movement) where T : BaseMovement
        {
            return Vector2.right.Rotate(movement.Rotation);
        }
        
        public static Vector2 Rotate(this Vector2 v, float degrees) {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}