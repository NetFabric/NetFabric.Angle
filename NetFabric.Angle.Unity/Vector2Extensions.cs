using System;
using UnityEngine;

namespace NetFabric
{
    public static class Vector2Extensions
    {
        public static Angle AngleWith(this Vector2 from, Vector2 to)
        {
            return NetFabric.Angle.FromDegrees(Vector2.Angle(from, to));
        }
    }
}
