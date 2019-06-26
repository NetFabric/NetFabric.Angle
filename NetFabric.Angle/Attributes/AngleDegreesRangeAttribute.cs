﻿using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AngleDegreesRangeAttribute : Attribute
    {
        public AngleDegreesRangeAttribute(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("max must be greater than or equal to min.", nameof(max));

            Min = Angle.InDegrees(min);
            Max = Angle.InDegrees(max);
        }

        public AngleDegrees Min { get; }
        public AngleDegrees Max { get; }
    }
}