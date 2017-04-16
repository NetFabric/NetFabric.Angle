using System;

namespace NetFabric
{
    [AttributeUsageAttribute(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public abstract class AngleRangeAttribute
        : Attribute
    {
        protected AngleRangeAttribute(Angle min, Angle max)
        {
            if (min > max)
                throw new ArgumentException("max must be greater than or equal to min.", nameof(max));

            Min = min;
            Max = max;
        }

        public Angle Min { get; }

        public Angle Max { get; }
    }

    public class AngleRadiansRangeAttribute 
        : AngleRangeAttribute
    {
        public AngleRadiansRangeAttribute(double min, double max)
            : base (Angle.FromRadians(min), Angle.FromRadians(max))
        { }
    }

    public class AngleDegreesRangeAttribute
        : AngleRangeAttribute
    {
        public AngleDegreesRangeAttribute(double min, double max)
            : base(Angle.FromDegrees(min), Angle.FromDegrees(max))
        { }

        public AngleDegreesRangeAttribute(
            int minDegrees, double minMinutes,
            int maxDegrees, double maxMinutes)
            : base(
                  Angle.FromDegrees(minDegrees, minMinutes),
                  Angle.FromDegrees(maxDegrees, maxMinutes))
        { }

        public AngleDegreesRangeAttribute(
            int minDegrees, int minMinutes, double minSeconds,
            int maxDegrees, int maxMinutes, double maxSeconds)
            : base(
                  Angle.FromDegrees(minDegrees, minMinutes, minSeconds), 
                  Angle.FromDegrees(maxDegrees, maxMinutes, maxSeconds))
        { }
    }

    public class AngleGradiansRangeAttribute
        : AngleRangeAttribute
    {
        public AngleGradiansRangeAttribute(double min, double max)
            : base(Angle.FromGradians(min), Angle.FromGradians(max))
        { }
    }

}