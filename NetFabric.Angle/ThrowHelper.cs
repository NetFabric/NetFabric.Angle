using System;

namespace NetFabric
{
    static class ThrowHelper
    {
        public static T ThrowArgumentException<T>(string paramName, string message)
            => throw new ArgumentException(message, paramName);

        public static void ThrowArgumentOutOfRangeException(string paramName, object actualValue, string message)
            => throw new ArgumentOutOfRangeException(paramName, actualValue, message);

        public static T ThrowArgumentOutOfRangeException<T>(string paramName, object actualValue, string message)
            => throw new ArgumentOutOfRangeException(paramName, actualValue, message);

        public static T ThrowInvalidOperationException<T>()
            => throw new InvalidOperationException();
    }
}
