using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AngleGradiansRangeAttribute : Attribute
    {
        public AngleGradiansRangeAttribute(double min, double max)
        {
            if (min > max)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(max), max, "max must be greater than or equal to min.");

            Min = Angle.InGradians(min);
            Max = Angle.InGradians(max);
        }

        public AngleGradians Min { get; }
        public AngleGradians Max { get; }
    }
}