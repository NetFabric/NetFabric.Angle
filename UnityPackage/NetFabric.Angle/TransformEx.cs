using System;
using UnityEngine;

namespace NetFabric
{
    public static class TransformEx
    {
        public static void Rotate(this Transform transform, AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle, Space relativeTo = Space.Self) 
            => transform.Rotate((float)xAngle.Degrees, (float)yAngle.Degrees, (float)zAngle.Degrees, relativeTo);

        public static void Rotate(this Transform transform, Vector3 axis, AngleDegrees angle, Space relativeTo = Space.Self) 
            => transform.Rotate(axis, (float)angle.Degrees, relativeTo);
    }
}
