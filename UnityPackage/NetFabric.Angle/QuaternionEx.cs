using System;
using UnityEngine;

namespace NetFabric
{
    public static class QuaternionEx
    {
        public static AngleDegrees Angle(Quaternion a, Quaternion b) 
            => NetFabric.Angle.FromDegrees(Quaternion.Angle(a, b));

        public static Quaternion AngleAxis(AngleDegrees angle, Vector3 axis) 
            => Quaternion.AngleAxis((float)angle.Degrees, axis);

        public static Quaternion Euler(AngleDegrees x, AngleDegrees y, AngleDegrees z)
            => Quaternion.Euler((float)x.Degrees, (float)y.Degrees, (float)z.Degrees);

        public static Quaternion RotateTowards(Quaternion from, Quaternion to, AngleDegrees maxDegreesDelta)
            => Quaternion.RotateTowards(from, to, (float)maxDegreesDelta.Degrees);

        public static void EulerAngles(this Quaternion quaternion, out AngleDegrees x, out AngleDegrees y, out AngleDegrees z)
        {
            var angles = quaternion.eulerAngles;
            x = NetFabric.Angle.FromDegrees(angles.x);
            y = NetFabric.Angle.FromDegrees(angles.y);
            z = NetFabric.Angle.FromDegrees(angles.z);
        }
    }
}
