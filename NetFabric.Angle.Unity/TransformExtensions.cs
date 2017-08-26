using System;
using UnityEngine;

namespace NetFabric
{
    public static class TransformExtensions
    {
        public static void Rotate(this Transform transform, DegreesAngle xAngle, DegreesAngle yAngle, DegreesAngle zAngle, Space relativeTo = Space.Self) =>
            transform.Rotate((float)xAngle.Degrees, (float)yAngle.Degrees, (float)zAngle.Degrees, relativeTo);

        public static void Rotate(this Transform transform, Vector3 axis, DegreesAngle angle, Space relativeTo = Space.Self) =>
            transform.Rotate(axis, (float)angle.Degrees, relativeTo);
    }
}
