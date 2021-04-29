using System;
using Velentr.Collisions.Helpers;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A circle vs point condition.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class CircleVsPointCondition : CollisionCondition
    {
        /// <summary>
        ///     The valid shapes.
        /// </summary>
        private static readonly Shape[] ValidShapes = new Shape[] { Shape.Circle, Shape.Point };

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
        /// At least one shape must be a Point!
        /// </exception>
        public override bool Collision(IShape left, IShape right)
        {
            var shapes = ShapeHelpers.GetShapeDefinitions<CircleDefinition, PointDefinition>(left, right, ValidShapes);

            return Helpers.Math.SquaredDfifference(shapes.Item1.X, shapes.Item1.Y, shapes.Item2.X, shapes.Item2.Y) <= (shapes.Item1.Radius * shapes.Item1.Radius);
        }

    }
}
