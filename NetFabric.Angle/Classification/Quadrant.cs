using System;

namespace NetFabric
{
    /// <summary>
    /// The four regions divided by the x and y axis.
    /// </summary>
    public enum Quadrant
    {
        /// <summary>
        /// The region where x and y are positive.
        /// </summary>
        First = 0,
        /// <summary>
        /// The region where x is negative and y is positive.
        /// </summary>
        Second = 1,
        /// <summary>
        /// The region where x and y are negative.
        /// </summary>
        Third = 2,
        /// <summary>
        /// The region where x is positive and y is negative.
        /// </summary>
        Fourth = 3,
    }
}
