using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static NetFabric.Angle;

namespace NetFabric
{
    public static class Vector3Ex
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Angle(Vector3 from, Vector3 to) 
            => InDegrees(Vector3.Angle(from, to));
    }
}
