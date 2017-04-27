using System;
using UnityEngine;

namespace NetFabric
{
    public static class TransformExtensions
    {
        public static void Rotate(this Transform @this, Angle xAngle, Angle yAngle, Angle zAngle, Space relativeTo = Space.Self) =>
            @this.Rotate((float)xAngle.ToDegrees(), (float)yAngle.ToDegrees(), (float)zAngle.ToDegrees(), relativeTo);

        public static void Rotate(this Transform @this, Vector3 axis, Angle angle, Space relativeTo = Space.Self) =>
            @this.Rotate(axis, (float)angle.ToDegrees(), relativeTo);
    }
}
