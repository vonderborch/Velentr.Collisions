using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A rectangle vs point condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class RectangleVsPointCondition : CollisionCondition
    {
        /// <summary>
        ///     The valid shapes.
        /// </summary>
        private static readonly Shape[] ValidShapes = new Shape[] { Shape.Rectangle, Shape.Point };

        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// At least one shape must be a Rectangle!
        /// or
        /// At least one shape must be a Point!
        /// </exception>
        public override bool Collision(IShape left, IShape right)
        {
            var shapes = ShapeHelpers.GetShapeDefinitions<RectangleDefinition, PointDefinition>(left, right, ValidShapes);

            if (Helpers.Math.ApproximatelyEqual(shapes.Item1.X, shapes.Item2.X) && Helpers.Math.ApproximatelyEqual(shapes.Item1.Y, shapes.Item2.Y))
            {
                return true;
            }

            var rec = new RectangleDefinition()
            {
                X = shapes.Item2.X,
                Y = shapes.Item2.Y,
                Height = 0,
                Width = 0,
                Shape = Shape.Rectangle,
            };

            return shapes.Item1.Right >= rec.Left && shapes.Item1.Left <= rec.Right && shapes.Item1.Bottom >= rec.Top && shapes.Item1.Top <= rec.Bottom;
        }

    }
}
