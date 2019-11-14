using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Reduce(int angle, int fullAngle)
        {
            var reduced = angle % fullAngle;
            if (reduced < 0)
                reduced += fullAngle;
            return reduced;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Reduce(double angle, double fullAngle)
        {
            var reduced = angle % fullAngle;
            if (reduced < 0)
                reduced += fullAngle;
            return reduced;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quadrant GetQuadrant(double angle, double rightAngle, double straightAngle, double fullAngle)
            => GetQuadrant(Reduce(angle, fullAngle), rightAngle, straightAngle);

        public static double GetReference(double angle, double rightAngle, double straightAngle, double fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            var quadrant = GetQuadrant(reduced, rightAngle, straightAngle);
            return quadrant switch
            {
                Quadrant.First => reduced,
                Quadrant.Second => straightAngle - reduced,
                Quadrant.Third => reduced - straightAngle,
                Quadrant.Fourth => fullAngle - reduced,
                _ => Throw.InvalidOperationException<double>(),
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Lerp(double a1, double a2, double t) =>
            (1 - t) * a1 + t * a2;

        static Quadrant GetQuadrant(double angle, double rightAngle, double straightAngle)
        {
            if (angle < rightAngle)
                return Quadrant.First;

            if (angle < straightAngle)
                return Quadrant.Second;

            if (angle < straightAngle + rightAngle)
                return Quadrant.Third;

            return Quadrant.Fourth;
        }

    }
}
