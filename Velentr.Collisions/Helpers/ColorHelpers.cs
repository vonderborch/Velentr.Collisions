using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Helpers
{
    /// <summary>
    ///     Helpers for working with colors.
    /// </summary>
    public static class ColorHelpers
    {
        /// <summary>
        ///     Color meets minimum threshold.
        /// </summary>
        ///
        /// <param name="color"> The color. </param>
        /// <param name="r">     The red component. </param>
        /// <param name="g">     The green component. </param>
        /// <param name="b">     The byte value. </param>
        /// <param name="a">     The alpha component. </param>
        ///
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public static bool ColorMeetsMinThreshold(Color? color, byte r, byte g, byte b, byte a)
        {
            if (color == null)
            {
                return false;
            }

            return color.Value.R <= r && color.Value.G <= g && color.Value.B <= b && color.Value.A <= a;
        }
    }
}
