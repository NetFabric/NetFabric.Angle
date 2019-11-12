using System;
using UnityEngine;

namespace NetFabric
{
    public static class Vector3Ex
    {
        public static AngleDegrees Angle(Vector3 from, Vector3 to) 
            => NetFabric.Angle.FromDegrees(Vector3.Angle(from, to));
    }
}
