using System;
using UnityEngine;

namespace NetFabric
{
    public static class TransformExtensions
    {
        public static void Rotate(this Transform @this, DegreesAngle xAngle, DegreesAngle yAngle, DegreesAngle zAngle, Space relativeTo = Space.Self) =>
            @this.Rotate((float)xAngle.Degrees, (float)yAngle.Degrees, (float)zAngle.Degrees, relativeTo);

        public static void Rotate(this Transform @this, Vector3 axis, DegreesAngle angle, Space relativeTo = Space.Self) =>
            @this.Rotate(axis, (float)angle.Degrees, relativeTo);
    }
}
