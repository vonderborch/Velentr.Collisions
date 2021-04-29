using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;
using Math = System.Math;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A pixel rectangle vs rectangle condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class PixelRectangleVsRectangleCondition : CollisionCondition
    {
        /// <summary>
        ///     The valid shapes.
        /// </summary>
        private static readonly Shape[] ValidShapes = new Shape[] { Shape.PixelRectangle, Shape.Rectangle };

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
            var shapes = ShapeHelpers.GetShapeDefinitions<PixelRectangleDefinition, RectangleDefinition>(left, right, ValidShapes);
            
            var x1 = (int)System.Math.Ceiling(System.Math.Max((double)shapes.Item1.Left, (double)shapes.Item2.Left));
            var x2 = (int)System.Math.Floor(System.Math.Min((double)shapes.Item1.Right, (double)shapes.Item2.Right));
            var y1 = (int)System.Math.Ceiling(System.Math.Max((double)shapes.Item1.Top, (double)shapes.Item2.Top));
            var y2 = (int)System.Math.Floor(Math.Min((double)shapes.Item1.Bottom, (double)shapes.Item2.Bottom));

            for (var y = y1; y < y2; y++)
            {
                for (var x = x1; x < x2; x++)
                {
                    Color? color;

                    try
                    {
                        color = shapes.Item1.ColorArray[(x - shapes.Item1.Left) + (y - shapes.Item1.Top) * shapes.Item1.Width];
                    }
                    catch
                    {
                        color = null;
                    }

                    if (ColorHelpers.ColorMeetsMinThreshold(color, shapes.Item1.MaxRedChannel, shapes.Item1.MaxGreenChannel, shapes.Item1.MaxBlueChannel, shapes.Item1.MaxAlphaChannel))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
