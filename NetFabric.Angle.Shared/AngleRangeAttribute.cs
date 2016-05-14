using System;

namespace NetFabric
{
    [AttributeUsageAttribute(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public abstract class AngleRangeAttribute
        : Attribute
    {
        readonly Angle min;
        readonly Angle max;

        protected AngleRangeAttribute(Angle min, Angle max)
        {
            if (min > max)
                throw new ArgumentException("min must be less or equal to max.");

            this.min = min;
            this.max = max;
        }

        public Angle Min { get { return min; } }

        public Angle Max { get { return max; } }
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