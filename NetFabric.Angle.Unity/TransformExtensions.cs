using System;
using UnityEngine;

namespace NetFabric
{
    public static class TransformExtensions
    {
        public static void Rotate(this Transform @this, AngleDegrees xAngle, AngleDegrees yAngle, AngleDegrees zAngle, Space relativeTo = Space.Self) =>
            @this.Rotate((float)xAngle.Degrees, (float)yAngle.Degrees, (float)zAngle.Degrees, relativeTo);

        public static void Rotate(this Transform @this, Vector3 axis, AngleDegrees angle, Space relativeTo = Space.Self) =>
            @this.Rotate(axis, (float)angle.Degrees, relativeTo);
    }
}
