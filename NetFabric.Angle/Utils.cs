using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Lerp(double a1, double a2, double t) =>
            (1 - t) * a1 + t * a2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Truncate(double value)
            => value - value % 1;

        public static int Reduce(int angle, int fullAngle)
        {
            var reduced = angle % fullAngle;
            if (reduced < 0)
                return reduced + fullAngle;

            return reduced;
        }

        public static double Reduce(double angle, double fullAngle)
        {
            var reduced = angle % fullAngle;
            if (reduced < 0)
                return reduced + fullAngle;

            return reduced; 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quadrant GetQuadrant(int angle, int rightAngle, int fullAngle)
            => GetQuadrant(Reduce(angle, fullAngle), rightAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quadrant GetQuadrant(double angle, double rightAngle, double fullAngle)
            => GetQuadrant(Reduce(angle, fullAngle), rightAngle);

        public static int GetReference(int angle, int rightAngle, int straightAngle, int fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            switch (GetQuadrant(reduced, rightAngle))
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
                    return ThrowHelper.ThrowInvalidOperationException<int>();
            }
        }

        public static double GetReference(double angle, double rightAngle, double straightAngle, double fullAngle)
        {
            var reduced = Reduce(angle, fullAngle);
            switch (GetQuadrant(reduced, rightAngle))
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
                    return ThrowHelper.ThrowInvalidOperationException<double>();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Quadrant GetQuadrant(double angle, double rightAngle)
            => (Quadrant)(int)Truncate(angle / rightAngle);

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
