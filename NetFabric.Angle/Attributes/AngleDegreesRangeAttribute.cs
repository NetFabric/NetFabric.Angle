using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AngleDegreesRangeAttribute : Attribute
    {
        public AngleDegreesRangeAttribute(double min, double max)
        {
            if (min > max)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(max), max, "max must be greater than or equal to min.");

            Min = Angle.InDegrees(min);
            Max = Angle.InDegrees(max);
        }

        public AngleDegrees Min { get; }
        public AngleDegrees Max { get; }
    }
}