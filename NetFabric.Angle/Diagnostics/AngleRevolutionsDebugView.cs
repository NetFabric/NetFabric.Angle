using System;

namespace NetFabric
{
    public class AngleRevolutionsDebugView
    {
        readonly AngleRevolutions angle;

        public AngleRevolutionsDebugView(AngleRevolutions angle)
        {
            this.angle = angle;
        }

        public string Radians
            => Angle.ToRadians(angle).Radians.ToString();

        public string Degrees
            => $"{Angle.ToDegrees(angle).Degrees}°";

        public string DegreesMinutes 
        { 
            get 
            {
                Angle.ToDegrees(angle).Deconstruct(out var degrees, out var minutes);
                return $"{degrees}° {minutes}'";
            } 
        }

        public string DegreesMinutesSeconds
        {
            get
            {
                Angle.ToDegrees(angle).Deconstruct(out var degrees, out var minutes, out var seconds);
                return $"{degrees}° {minutes}' {seconds}''";
            }
        }

        public string Gradians
            => Angle.ToGradians(angle).Gradians.ToString();

        public string Revolutions
            => angle.Revolutions.ToString();
    }
}