using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A pixel rectangle vs circle condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class PixelRectangleVsCircleCondition : CollisionCondition
    {
        /// <summary>
        ///     The valid shapes.
        /// </summary>
        private static readonly Shape[] ValidShapes = new Shape[] { Shape.PixelRectangle, Shape.Circle };

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
            var shapes = ShapeHelpers.GetShapeDefinitions<PixelRectangleDefinition, CircleDefinition>(left, right, ValidShapes);
            
            for (var y = shapes.Item1.Top; y < shapes.Item1.Bottom; y++)
            {
                for (var x = shapes.Item1.Left; x < shapes.Item1.Right; x++)
                {
                    if (Helpers.Math.SquaredDfifference(shapes.Item2.X, shapes.Item2.Y, shapes.Item1.X, shapes.Item1.Y) <= (shapes.Item2.Radius * shapes.Item2.Radius))
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
            }

            return false;
        }

    }
}
