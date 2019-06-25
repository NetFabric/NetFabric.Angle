using System;

namespace NetFabric
{
    public static partial class Angle
    {
        const double RevolutionsInRadians = AngleRevolutions.FullAngle / AngleRadians.FullAngle;
        const double DegreesInRadians = AngleDegrees.FullAngle / AngleRadians.FullAngle;
        const double GradiansInRadians = AngleGradians.FullAngle / AngleRadians.FullAngle;
        const double GradiansInDegrees = AngleGradians.FullAngle / AngleDegrees.FullAngle;
    }
}
