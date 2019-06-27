using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static NetFabric.Angle;

namespace NetFabric
{
    public static class TransformEx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle) EulerAngles(this Transform transform)
            => (InDegrees(transform.eulerAngles.x), InDegrees(transform.eulerAngles.y), InDegrees(transform.eulerAngles.z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle) LocalEulerAngles(this Transform transform)
            => (InDegrees(transform.localEulerAngles.x), InDegrees(transform.localEulerAngles.y), InDegrees(transform.localEulerAngles.z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotate(this Transform transform, AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle, Space relativeTo = Space.Self) =>
            transform.Rotate((float)xAngle.Degrees, (float)yAngle.Degrees, (float)zAngle.Degrees, relativeTo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotate(this Transform transform, Vector3 axis, AngleDegrees angle, Space relativeTo = Space.Self) =>
            transform.Rotate(axis, (float)angle.Degrees, relativeTo);
    }
}
