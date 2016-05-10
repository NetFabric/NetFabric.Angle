using System;
using System.Collections.Generic;
using System.Text;

namespace NetFabric
{
    public class AngleDebugView
    {
        readonly Angle angle;

        public AngleDebugView(Angle angle)
        {
            this.angle = angle;
        }

        public string Radians { get { return angle.ToString("R"); } }

        public string Degrees { get { return angle.ToString("D"); } }

        public string DegreesMinutes { get { return angle.ToString("M"); } }

        public string DegreesMinutesSeconds { get { return angle.ToString("S"); } }

        public string Gradians { get { return angle.ToString("G"); } }
    }
}
