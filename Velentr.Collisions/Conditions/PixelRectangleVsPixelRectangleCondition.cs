using System;
using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;
using Math = System.Math;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A pixel rectangle vs pixel rectangle condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class PixelRectangleVsPixelRectangleCondition : CollisionCondition
    {
        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        /// <exception cref="System.ArgumentException">Both shapes must be Rectangles!</exception>
        public override bool Collision(IShape left, IShape right)
        {
            var l = (PixelRectangleDefinition)left.GetShapeDefinition();
            var r = (PixelRectangleDefinition)right.GetShapeDefinition();

            if (l.Shape != Shape.PixelRectangle || r.Shape != Shape.PixelRectangle)
            {
                throw new ArgumentException("Both shapes must be PixelRectangles!");
            }

            var x1 = (int)Math.Ceiling(Math.Max((double)l.Left, (double)r.Left));
            var x2 = (int)Math.Floor(Math.Min((double)l.Right, (double)r.Right));
            var y1 = (int)Math.Ceiling(Math.Max((double)l.Top, (double)r.Top));
            var y2 = (int)Math.Floor(Math.Min((double)l.Bottom, (double)r.Bottom));

            for (var y = y1; y < y2; y++)
            {
                for (var x = x1; x < x2; x++)
                {
                    Color? lColor;
                    Color? rColor;

                    try
                    {
                        lColor = l.ColorArray[(x - l.Left) + (y - l.Top) * l.Width];
                    }
                    catch
                    {
                        lColor = null;
                    }
                    try
                    {
                        rColor = r.ColorArray[(x - r.Left) + (y - r.Top) * r.Width];
                    }
                    catch
                    {
                        rColor = null;
                    }

                    if (ColorHelpers.ColorMeetsMinThreshold(lColor, l.MaxRedChannel, l.MaxGreenChannel, l.MaxBlueChannel, l.MaxAlphaChannel) && ColorHelpers.ColorMeetsMinThreshold(rColor, r.MaxRedChannel, r.MaxGreenChannel, r.MaxBlueChannel, r.MaxAlphaChannel))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
