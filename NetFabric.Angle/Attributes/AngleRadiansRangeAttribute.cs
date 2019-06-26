using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AngleRadiansRangeAttribute : Attribute
    {
        public AngleRadiansRangeAttribute(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("max must be greater than or equal to min.", nameof(max));

            Min = Angle.InRadians(min);
            Max = Angle.InRadians(max);
        }

        public AngleRadians Min { get; }

        public AngleRadians Max { get; }
    }
}