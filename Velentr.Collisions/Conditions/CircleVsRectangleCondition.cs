using System;
using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;
using Math = Velentr.Collisions.Helpers.Math;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A circle vs rectangle condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class CircleVsRectangleCondition : CollisionCondition
    {
        /// <summary>
        ///     The valid shapes.
        /// </summary>
        private static readonly Shape[] ValidShapes = new Shape[] { Shape.Circle, Shape.Rectangle };

        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// At least one shape must be a Circle!
        /// or
        /// At least one shape must be a Rectangle!
        /// </exception>
        public override bool Collision(IShape left, IShape right)
        {
            var shapes = ShapeHelpers.GetShapeDefinitions<CircleDefinition, RectangleDefinition>(left, right, ValidShapes);

            return Math.SquaredDfifference(shapes.Item1.X, shapes.Item1.Y, Math.Clamp(shapes.Item1.X, shapes.Item2.Left, shapes.Item2.Right), Math.Clamp(shapes.Item1.Y, shapes.Item2.Top, shapes.Item2.Bottom)) <= shapes.Item1.Radius;
        }

    }
}
