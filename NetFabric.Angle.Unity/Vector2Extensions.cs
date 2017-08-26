using System;
using UnityEngine;

namespace NetFabric
{
    public static class Vector2Extensions
    {
        public static AngleDegrees AngleWith(this Vector2 from, Vector2 to) => 
            Angle.FromDegrees(Vector2.Angle(from, to));
    }
}
