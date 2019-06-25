using System;

namespace NetFabric
{
    public static partial class Angle
    {

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static AngleDegrees Max(AngleDegrees left, AngleDegrees right) =>
            left.Degrees > right.Degrees ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref readonly AngleDegreesMinutes Max(in AngleDegreesMinutes left, in AngleDegreesMinutes right) =>
            ref AngleDegreesMinutes.GetDegreesAngle(left) < AngleDegreesMinutes.GetDegreesAngle(right) ?
                ref left :
                ref right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref readonly AngleDegreesMinutesSeconds Max(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            ref AngleDegreesMinutesSeconds.GetDegreesAngle(left) < AngleDegreesMinutesSeconds.GetDegreesAngle(right) ?
                ref left :
                ref right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static AngleGradians Max(AngleGradians left, AngleGradians right) =>
            left.Gradians > right.Gradians ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static AngleRadians Max(in AngleRadians left, in AngleRadians right) =>
            left.Radians > right.Radians ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static AngleRevolutions Max(AngleRevolutions left, AngleRevolutions right) =>
            left.Revolutions > right.Revolutions ? left : right;
    }
}
