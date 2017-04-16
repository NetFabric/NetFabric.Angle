using System;

namespace NetFabric
{
    public class AngleDebugView
    {
        readonly Angle angle;

        public AngleDebugView(Angle angle)
        {
            this.angle = angle;
        }

        public string Radians => angle.ToString("R"); 

        public string Degrees => angle.ToString("D");

        public string DegreesMinutes => angle.ToString("M");

        public string DegreesMinutesSeconds => angle.ToString("S");

        public string Gradians => angle.ToString("G"); 
    }
}
