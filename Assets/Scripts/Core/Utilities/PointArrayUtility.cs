using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Core
{
    public static class PointArrayUtility
    {
        public static List<Vector2> GetArrayOnRectViaBestCandidate(Rect rect, int pointCount, List<Vector2> already_exists = null)
        {
            if (pointCount < 1) throw new InvalidOperationException($"{nameof(pointCount)} must be greater than zero!");

            var result = new List<Vector2>();
            already_exists = already_exists != null ? new List<Vector2>(already_exists) : new List<Vector2>();//copy
            int candidateCount = 20;
            if (already_exists.Count == 0)
            {
                var first = rect.RandomPoint();
                result.Add(first);
                already_exists.Add(first);
            }
            for (int i = 1; i < pointCount; ++i)
            {
                Vector2 point = default;
                float sqrDist = 0f;
                for (int j = 1; j < candidateCount; ++j)
                {
                    var candidate = rect.RandomPoint();
                    var closest = already_exists[already_exists.Closest(candidate)];
                    var sqrDistTmp = (closest - candidate).sqrMagnitude;
                    if (sqrDistTmp < sqrDist) continue;
                    sqrDist = sqrDistTmp;
                    point = candidate;
                }

                result.Add(point);
                already_exists.Add(point);
            }
            already_exists.Clear();
            return result;
        }


        public static int Closest<TColl>(this TColl collection, Vector2 point)
            where TColl : IList<Vector2>
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            int closest = 0;
            float sqrDist = float.PositiveInfinity;
            var i = collection.Count;
            while (i-- > 0)
            {
                var sqrDistTmp = (point - collection[i]).sqrMagnitude;
                if (sqrDistTmp > sqrDist) continue;
                sqrDist = sqrDistTmp;
                closest = i;
            }

            return closest;
        }

        public static int Closest<TColl>(this TColl collection, int index)
            where TColl : IList<Vector2>
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            int closest = 0;
            float sqrDist = float.PositiveInfinity;
            var point = collection[index];
            var i = collection.Count;
            while (i-- > 0)
            {
                if (i == index) continue;
                var sqrDistTmp = (point - collection[i]).sqrMagnitude;
                if (sqrDistTmp > sqrDist) continue;
                sqrDist = sqrDistTmp;
                closest = i;
            }

            return closest;
        }

        public static Vector2 RandomPoint(this Rect rect)
        {
            return new Vector2(
                Random.Range(rect.min.x, rect.max.x),
                Random.Range(rect.min.y, rect.max.y));
        }
    }
}