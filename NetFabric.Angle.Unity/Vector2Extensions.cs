using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static NetFabric.Angle;

namespace NetFabric
{
    public static class Vector2Ex
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Angle(Vector2 from, Vector2 to) 
            => InDegrees(Vector2.Angle(from, to));
    }
}
