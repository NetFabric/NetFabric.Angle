using System;
using UnityEngine;

namespace NetFabric
{
    public static class QuaternionExtensions
    {
        public static AngleDegrees AngleWith(this Quaternion a, Quaternion b) =>
            Angle.FromDegrees(Quaternion.Angle(a, b));

        public static void ToAngleAxis(this Quaternion quaternion, out AngleDegrees angle, out Vector3 axis)
        {
            quaternion.ToAngleAxis(out float degrees, out axis);
            angle = Angle.FromDegrees(degrees);
        }
    }
}
