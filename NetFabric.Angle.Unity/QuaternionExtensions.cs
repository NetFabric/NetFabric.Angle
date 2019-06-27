using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static NetFabric.Angle;

namespace NetFabric
{
    public static class QuaternionEx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Angle(Quaternion a, Quaternion b) 
            => InDegrees(Quaternion.Angle(a, b));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion AngleAxis(AngleDegrees angle, Vector3 axis)
            => Quaternion.AngleAxis((float)angle.Degrees, axis);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Euler(AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle)
            => Quaternion.Euler((float)xAngle.Degrees, (float)yAngle.Degrees, (float)zAngle.Degrees);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion RotateTowards(Quaternion from, Quaternion to, AngleDegrees maxAngleDelta)
            => Quaternion.RotateTowards(from, to, (float)maxAngleDelta.Degrees);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (AngleDegrees angle, Vector3 axis) ToAngleAxis(this Quaternion quaternion)
        {
            quaternion.ToAngleAxis(out var angle, out var axis);
            return (InDegrees(angle), axis);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle) ToEuler(this Quaternion quaternion)
            => (InDegrees(quaternion.eulerAngles.x), InDegrees(quaternion.eulerAngles.y), InDegrees(quaternion.eulerAngles.z));
    }
}
