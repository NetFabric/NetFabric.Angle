using System;

namespace NetFabric
{
    public abstract class AngleRangeAttribute
        : Attribute
    {
        public abstract Angle Min { get; }

        public abstract Angle Max { get; }
    }

    public class AngleRadiansRangeAttribute 
        : AngleRangeAttribute
    {
        readonly double min;
        readonly double max;

        public AngleRadiansRangeAttribute(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min must be less or equal to max.");

            this.min = min;
            this.max = max;
        }

        public override Angle Min { get { return Angle.FromRadians(min); } }

        public override Angle Max { get { return Angle.FromRadians(max); } }
    }

    public class AngleDegreesRangeAttribute
        : AngleRangeAttribute
    {
        readonly double min;
        readonly double max;

        public AngleDegreesRangeAttribute(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min must be less or equal to max.");

            this.min = min;
            this.max = max;
        }

        public override Angle Min { get { return Angle.FromDegrees(min); } }

        public override Angle Max { get { return Angle.FromDegrees(max); } }
    }

    public class AngleGradiansRangeAttribute
        : AngleRangeAttribute
    {
        readonly double min;
        readonly double max;

        public AngleGradiansRangeAttribute(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min must be less or equal to max.");

            this.min = min;
            this.max = max;
        }

        public override Angle Min { get { return Angle.FromGradians(min); } }

        public override Angle Max { get { return Angle.FromGradians(max); } }
    }

}