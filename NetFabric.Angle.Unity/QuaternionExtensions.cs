using System;
using UnityEngine;

namespace NetFabric
{
    public static class QuaternionExtensions
    {
        public static AngleDegrees AngleWith(this Quaternion a, Quaternion b) =>
            Angle.InDegrees(Quaternion.Angle(a, b));

        public static void ToAngleAxis(this Quaternion @this, out AngleDegrees angle, out Vector3 axis)
        {
            @this.ToAngleAxis(out float degrees, out axis);
            angle = Angle.InDegrees(degrees);
        }
    }
}
