using System;
#if !NET35
using System.Runtime.CompilerServices;
#endif

namespace NetFabric
{
    static class Utils
    {
#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int Reduce(int angle, int fullAngle)
        {
            var reduced = angle % fullAngle;
            return reduced >= 0 ? reduced : reduced + fullAngle;
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static double Reduce(double angle, double fullAngle)
        {
            var reduced = angle % fullAngle;
            return reduced >= 0 ? reduced : reduced + fullAngle;
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static Quadrant GetQuadrant(int angle, int rightAngle, int straightAngle, int fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            return GetQuadrant(reduced, rightAngle, straightAngle);
        }

        public static Quadrant GetQuadrant(double angle, double rightAngle, double straightAngle, double fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            return GetQuadrant(reduced, rightAngle, straightAngle);
        }

        public static int GetReference(int angle, int rightAngle, int straightAngle, int fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            var quadrant = GetQuadrant(reduced, rightAngle, straightAngle);
            switch (quadrant)
            {
                case Quadrant.First:
                    return reduced;
                case Quadrant.Second:
                    return straightAngle - reduced;
                case Quadrant.Third:
                    return reduced - straightAngle;
                case Quadrant.Fourth:
                    return fullAngle - reduced;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static double GetReference(double angle, double rightAngle, double straightAngle, double fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            var quadrant = GetQuadrant(reduced, rightAngle, straightAngle);
            switch (quadrant)
            {
                case Quadrant.First:
                    return reduced;
                case Quadrant.Second:
                    return straightAngle - reduced;
                case Quadrant.Third:
                    return reduced - straightAngle;
                case Quadrant.Fourth:
                    return fullAngle - reduced;
                default:
                    throw new InvalidOperationException();
            }
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
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

        public static int ToBase60(int value, out int carry)
        {
            var result = value % 60;
            carry = (value - result) / 60;
            return result;
        }

        public static double ToBase60(double value, out double carry)
        {
            var result = value % 60.0;
            carry = (value - result) / 60.0;
            return result;
        }

    }
}
