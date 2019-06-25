using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static AngleDegrees Min(AngleDegrees left, AngleDegrees right) =>
            left.Degrees < right.Degrees ? left : right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleDegreesMinutes Min(in AngleDegreesMinutes left, in AngleDegreesMinutes right) =>
            ref AngleDegreesMinutes.GetDegreesAngle(left) < AngleDegreesMinutes.GetDegreesAngle(right) ?
                ref left :
                ref right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleDegreesMinutesSeconds Min(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            ref AngleDegreesMinutesSeconds.GetDegreesAngle(left) < AngleDegreesMinutesSeconds.GetDegreesAngle(right) ?
                ref left :
                ref right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static AngleGradians Min(AngleGradians left, AngleGradians right) =>
            left.Gradians < right.Gradians ? left : right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static AngleRadians Min(AngleRadians left, AngleRadians right) =>
            left.Radians < right.Radians ? left : right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static AngleRevolutions Min(AngleRevolutions left, AngleRevolutions right) =>
            left.Revolutions < right.Revolutions ? left : right;
    }
}
