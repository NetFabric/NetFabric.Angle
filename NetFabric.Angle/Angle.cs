using System;
using System.Diagnostics.Contracts;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
    public static partial class Angle
    {
        const double DegreesInRadians = AngleDegrees.FullAngle / AngleRadians.FullAngle;
        const double GradiansInRadians = AngleGradians.FullAngle / AngleRadians.FullAngle;
        const double GradiansInDegrees = AngleGradians.FullAngle / AngleDegrees.FullAngle;

        /// <summary>
        /// Returns an <see cref="AngleRadians"/> that represents the equivalent to the <see cref="AngleDegrees"/>.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRadians ToRadians(AngleDegrees angle) =>
            new AngleRadians(angle.Degrees / DegreesInRadians);

        /// <summary>
        /// Returns an <see cref="AngleRadians"/> that represents the equivalent to the <see cref="AngleGradians"/>.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRadians ToRadians(AngleGradians angle) =>
            new AngleRadians(angle.Gradians / GradiansInRadians);

        /// <summary>
        /// Returns an <see cref="AngleRadians"/> that represents the equivalent to the <see cref="AngleRevolutions"/>.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRadians ToRadians(AngleRevolutions angle) =>
            new AngleRadians(angle.Revolutions * AngleRadians.FullAngle);

        /// <summary>
        /// Returns an <see cref="AngleDegrees"/> that represents the equivalent to the <see cref="AngleRadians"/>.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleDegrees ToDegrees(AngleRadians angle) =>
            new AngleDegrees(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an <see cref="AngleDegrees"/> that represents the equivalent to the <see cref="AngleGradians"/>.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleDegrees ToDegrees(AngleGradians angle) =>
            new AngleDegrees(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an <see cref="AngleDegrees"/> that represents the equivalent to the <see cref="AngleRevolutions"/>.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleDegrees ToDegrees(AngleRevolutions angle) =>
            new AngleDegrees(angle.Revolutions * AngleDegrees.FullAngle);

        /// <summary>
        /// Returns an <see cref="AngleGradians"/> that represents the equivalent to the <see cref="AngleRadians"/>.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleGradians ToGradians(AngleRadians angle) =>
            new AngleGradians(angle.Radians * GradiansInRadians);

        /// <summary>
        /// Returns an <see cref="AngleGradians"/> that represents the equivalent to the <see cref="AngleDegrees"/>.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleGradians ToGradians(AngleDegrees angle) =>
            new AngleGradians(angle.Degrees * GradiansInDegrees);

        /// <summary>
        /// Returns an <see cref="AngleGradians"/> that represents the equivalent to the <see cref="AngleRevolutions"/>.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleGradians ToGradians(AngleRevolutions angle) =>
            new AngleGradians(angle.Revolutions * AngleGradians.FullAngle);

        /// <summary>
        /// Returns an <see cref="AngleRevolutions"/> that represents the equivalent to the <see cref="AngleDegrees"/>.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRevolutions ToRevolutions(AngleDegrees angle) =>
            new AngleRevolutions(angle.Degrees / AngleDegrees.FullAngle);

        /// <summary>
        /// Returns an <see cref="AngleRevolutions"/> that represents the equivalent to the <see cref="AngleGradians"/>.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRevolutions ToRevolutions(AngleGradians angle) =>
            new AngleRevolutions(angle.Gradians / AngleGradians.FullAngle);

        /// <summary>
        /// Returns an <see cref="AngleRevolutions"/> that represents the equivalent to the <see cref="AngleRadians"/>.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRevolutions ToRevolutions(AngleRadians angle) =>
            new AngleRevolutions(angle.Radians / AngleRadians.FullAngle);
    }
}
