using System;
using System.Collections.Generic;
using System.Text;

namespace Velentr.Collisions.Helpers
{
    public static class Math
    {

        private const double MaxPrecision = 0.000001;

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return System.Math.Sqrt(SquaredDfifference(x1, y1, x2, y2));
        }

        public static double SquaredDfifference(double x1, double y1, double x2, double y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;

            return dx * dx + dy * dy;
        }

        public static bool ApproximatelyEqual(double value1, double value2)
        {
            return System.Math.Abs(value1 - value2) <= MaxPrecision;
        }

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
