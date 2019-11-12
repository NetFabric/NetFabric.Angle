using System;
using UnityEngine;

namespace NetFabric
{
    public static class Vector2Ex
    {
        public static AngleDegrees Angle(Vector2 from, Vector2 to) 
            => NetFabric.Angle.FromDegrees(Vector2.Angle(from, to));
    }
}
