using System;
using UnityEngine;

namespace NetFabric
{
    public static class Vector3Extensions
    {
        public static AngleDegrees AngleWith(this Vector3 from, Vector3 to) => 
            Angle.FromDegrees(Vector3.Angle(from, to));
    }
}
