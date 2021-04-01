using System;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
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
            var l = (Point.PointDefinition)left.GetShapeDefinition();
            var r = (Point.PointDefinition)right.GetShapeDefinition();

            if (l.Shape != Shape.Point || r.Shape != Shape.Point)
            {
                throw new ArgumentException("Both shapes must be Points!");
            }

            return Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y);
        }

    }
}
