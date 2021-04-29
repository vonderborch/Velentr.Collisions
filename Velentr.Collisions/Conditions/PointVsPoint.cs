using System;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    ///     A point vs point.
    /// </summary>
    ///
    /// <seealso cref="CollisionCondition"/>
    public class PointVsPoint : CollisionCondition
    {
        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        /// <exception cref="System.ArgumentException">Both shapes must be Points!</exception>
        public override bool Collision(IShape left, IShape right)
        {
            var l = (PointDefinition)left.GetShapeDefinition();
            var r = (PointDefinition)right.GetShapeDefinition();

            if (l.Shape != Shape.Point || r.Shape != Shape.Point)
            {
                throw new ArgumentException("Both shapes must be Points!");
            }

            return Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y);
        }

    }
}
