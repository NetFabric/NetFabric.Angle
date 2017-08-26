using System;

namespace NetFabric
{
    public struct DegreesMinutesSecondsAngle
    {
        public readonly int Degrees;
        public readonly int Minutes;
        public readonly double Seconds;

        const int RightAngle = 90;
        const int StraightAngle = 180;
        const int FullAngle = 360;

        /// <summary>
        /// Represents the zero DegreesMinutesSecondsAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesSecondsAngle Zero = new DegreesMinutesSecondsAngle(0, 0, 0.0);

        /// <summary>
        /// Represents the golden DegreesMinutesSecondsAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        //public static readonly DegreesMinutesSecondsAngle Golden = new DegreesMinutesSecondsAngle(Math.PI * (3.0 - Math.Sqrt(5.0)));

        /// <summary>
        /// Represents the smallest possible value of a DegreesMinutesSecondsAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesSecondsAngle MinValue = new DegreesMinutesSecondsAngle(int.MinValue, 59, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the largest possible value of a DegreesMinutesSecondsAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesSecondsAngle MaxValue = new DegreesMinutesSecondsAngle(int.MaxValue, 59, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the right DegreesMinutesSecondsAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesSecondsAngle Right = new DegreesMinutesSecondsAngle(RightAngle, 0, 0.0);

        /// <summary>
        /// Represents the straight DegreesMinutesSecondsAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesSecondsAngle Straight = new DegreesMinutesSecondsAngle(StraightAngle, 0, 0.0);

        /// <summary>
        /// Represents the full DegreesMinutesSecondsAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesSecondsAngle Full = new DegreesMinutesSecondsAngle(FullAngle, 0, 0.0);

        internal DegreesMinutesSecondsAngle(int degrees, int minutes, double seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}
