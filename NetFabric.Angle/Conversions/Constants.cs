using System;

namespace NetFabric
{
    public static partial class Angle
    {
        const double GradiansPerDegree = AngleGradians.FullAngle / AngleDegrees.FullAngle;
        const double RadiansPerDegree = AngleRadians.FullAngle / AngleDegrees.FullAngle;
        const double RevolutionsPerDegree = AngleRevolutions.FullAngle / AngleDegrees.FullAngle;

        const double DegreesPerGradian = AngleDegrees.FullAngle / AngleGradians.FullAngle;
        const double RadiansPerGradian = AngleRadians.FullAngle / AngleGradians.FullAngle;
        const double RevolutionsPerGradian = AngleRevolutions.FullAngle / AngleGradians.FullAngle;

        const double DegreesPerRadian = AngleDegrees.FullAngle / AngleRadians.FullAngle;
        const double GradiansPerRadian = AngleGradians.FullAngle / AngleRadians.FullAngle;
        const double RevolutionsPerRadian = AngleRevolutions.FullAngle / AngleRadians.FullAngle;

        const double DegreesPerRevolution = AngleDegrees.FullAngle / AngleRevolutions.FullAngle;
        const double GradiansPerRevolution = AngleGradians.FullAngle / AngleRevolutions.FullAngle;
        const double RadiansPerRevolution = AngleRadians.FullAngle / AngleRevolutions.FullAngle;
    }
}
