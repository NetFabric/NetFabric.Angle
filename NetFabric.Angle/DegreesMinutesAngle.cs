using System;

namespace NetFabric
{
    public struct DegreesMinutesAngle
    {
        public readonly int Degrees;
        public readonly double Minutes;

        const int RightAngle = 90;
        const int StraightAngle = 180;
        const int FullAngle = 360;

        /// <summary>
        /// Represents the zero DegreesMinutesAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Zero = new DegreesMinutesAngle(0, 0.0);

        /// <summary>
        /// Represents the golden DegreesMinutesAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        //public static readonly DegreesMinutesAngle Golden = new DegreesMinutesAngle(Math.PI * (3.0 - Math.Sqrt(5.0)));

        /// <summary>
        /// Represents the smallest possible value of a DegreesMinutesAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle MinValue = new DegreesMinutesAngle(int.MinValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the largest possible value of a DegreesMinutesAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle MaxValue = new DegreesMinutesAngle(int.MaxValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the right DegreesMinutesAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Right = new DegreesMinutesAngle(RightAngle, 0.0);

        /// <summary>
        /// Represents the straight DegreesMinutesAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Straight = new DegreesMinutesAngle(StraightAngle, 0.0);

        /// <summary>
        /// Represents the full DegreesMinutesAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Full = new DegreesMinutesAngle(FullAngle, 0.0);

        internal DegreesMinutesAngle(int degrees, double minutes)
        {
            Degrees = degrees;
            Minutes = minutes;
        }
    }
}
