namespace Velentr.Collisions.Helpers
{
    /// <summary>
    ///     Helpers for Mathematics
    /// </summary>
    public static class Math
    {
        /// <summary>
        ///     (Immutable) the maximum precision.
        /// </summary>
        private const double MaxPrecision = 0.000001;

        /// <summary>
        ///     Gets a distance.
        /// </summary>
        ///
        /// <param name="x1"> The first x value. </param>
        /// <param name="y1"> The first y value. </param>
        /// <param name="x2"> The second x value. </param>
        /// <param name="y2"> The second y value. </param>
        ///
        /// <returns>
        ///     The distance.
        /// </returns>
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return System.Math.Sqrt(SquaredDfifference(x1, y1, x2, y2));
        }

        /// <summary>
        ///     Squared dfifference.
        /// </summary>
        ///
        /// <param name="x1"> The first x value. </param>
        /// <param name="y1"> The first y value. </param>
        /// <param name="x2"> The second x value. </param>
        /// <param name="y2"> The second y value. </param>
        ///
        /// <returns>
        ///     A double.
        /// </returns>
        public static double SquaredDfifference(double x1, double y1, double x2, double y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;

            return dx * dx + dy * dy;
        }

        /// <summary>
        ///     Approximately equal.
        /// </summary>
        ///
        /// <param name="value1"> The first value. </param>
        /// <param name="value2"> The second value. </param>
        ///
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public static bool ApproximatelyEqual(double value1, double value2)
        {
            return System.Math.Abs(value1 - value2) <= MaxPrecision;
        }

        /// <summary>
        ///     Clamp the given value.
        /// </summary>
        ///
        /// <param name="value">    The value. </param>
        /// <param name="minValue"> The minimum value. </param>
        /// <param name="maxValue"> The maximum value. </param>
        ///
        /// <returns>
        ///     A double.
        /// </returns>
        public static double Clamp(double value, double minValue, double maxValue)
        {
            return value < minValue
                ? minValue
                : value > maxValue
                    ? maxValue
                    : value;
        }
    }
}
