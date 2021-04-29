using System;
using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;
using Math = System.Math;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A pixel rectangle vs point condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class PixelRectangleVsPointCondition : CollisionCondition
    {
        /// <summary>
        ///     The valid shapes.
        /// </summary>
        private static readonly Shape[] ValidShapes = new Shape[] { Shape.PixelRectangle, Shape.Point };

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
            var shapes = ShapeHelpers.GetShapeDefinitions<PixelRectangleDefinition, PointDefinition>(left, right, ValidShapes);

            var pX = (int)Math.Round(shapes.Item2.X);
            var pY = (int)Math.Round(shapes.Item2.Y);

            if (pX < shapes.Item1.Left || pX > shapes.Item1.Right || pY < shapes.Item1.Top || pY > shapes.Item1.Bottom)
            {
                return false;
            }

            Color? color;
            try
            {
                color = shapes.Item1.ColorArray[(pX - shapes.Item1.Left) + (pY - shapes.Item1.Top) * shapes.Item1.Width];
            }
            catch
            {
                color = null;
            }

            return ColorHelpers.ColorMeetsMinThreshold(color, shapes.Item1.MaxRedChannel, shapes.Item1.MaxGreenChannel, shapes.Item1.MaxBlueChannel, shapes.Item1.MaxAlphaChannel);
        }

    }
}
