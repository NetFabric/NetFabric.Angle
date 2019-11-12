using System;

namespace NetFabric
{
    public class AngleGradiansDebugView
    {
        readonly AngleGradians angle;

        public AngleGradiansDebugView(AngleGradians angle)
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
            => angle.Gradians.ToString();
    }
}