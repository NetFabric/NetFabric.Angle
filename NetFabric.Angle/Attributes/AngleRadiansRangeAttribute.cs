using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AngleRadiansRangeAttribute : Attribute
    {
        public AngleRadiansRangeAttribute(double min, double max)
        {
            if (min > max)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(max), max, "max must be greater than or equal to min.");

            Min = Angle.InRadians(min);
            Max = Angle.InRadians(max);
        }

        public AngleRadians Min { get; }

        public AngleRadians Max { get; }
    }
}