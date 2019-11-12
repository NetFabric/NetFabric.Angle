using System;

namespace NetFabric
{
    public class AngleDegreesDebugView
    {
        readonly AngleDegrees angle;

        public AngleDegreesDebugView(AngleDegrees angle)
        {
            this.angle = angle;
        }

        public string Radians
            => Angle.ToRadians(angle).Radians.ToString();

        public string Degrees
            => $"{angle.Degrees}°";

        public string DegreesMinutes 
        { 
            get 
            {
                angle.Deconstruct(out var degrees, out var minutes);
                return $"{degrees}° {minutes}'";
            } 
        }

        public string DegreesMinutesSeconds
        {
            get
            {
                angle.Deconstruct(out var degrees, out var minutes, out var seconds);
                return $"{degrees}° {minutes}' {seconds}''";
            }
        }

        public string Gradians
            => Angle.ToGradians(angle).Gradians.ToString();
    }
}