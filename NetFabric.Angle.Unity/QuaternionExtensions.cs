using System;
using UnityEngine;

namespace NetFabric
{
    public static class QuaternionExtensions
    {
        public static Angle AngleWith(this Quaternion a, Quaternion b)
        {
            return NetFabric.Angle.FromDegrees(Quaternion.Angle(a, b));
        }

        public static void ToAngleAxis(this Quaternion @this, out Angle angle, out Vector3 axis)
        {
            float degrees;
            @this.ToAngleAxis(out degrees, out axis);
            angle = Angle.FromDegrees(degrees);
        }
    }
}
