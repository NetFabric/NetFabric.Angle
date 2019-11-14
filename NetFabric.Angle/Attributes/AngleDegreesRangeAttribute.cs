using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AngleDegreesRangeAttribute
        : Attribute
    {
        public AngleDegreesRangeAttribute(int min, int max)
        {
            if (min > max)
                Throw.ArgumentException("max must be greater than or equal to min.", nameof(max));

            Min = Angle.FromDegrees(min);
            Max = Angle.FromDegrees(max);
        }

        public AngleDegrees Min { get; }

        public AngleDegrees Max { get; }
    }
}