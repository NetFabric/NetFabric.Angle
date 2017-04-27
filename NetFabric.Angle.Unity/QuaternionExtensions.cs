using System;
using UnityEngine;

namespace NetFabric
{
    public static class QuaternionExtensions
    {
        public static Angle AngleWith(this Quaternion a, Quaternion b) =>
            Angle.FromDegrees(Quaternion.Angle(a, b));

        public static void ToAngleAxis(this Quaternion @this, out Angle angle, out Vector3 axis)
        {
            @this.ToAngleAxis(out float degrees, out axis);
            angle = Angle.FromDegrees(degrees);
        }
    }
}
