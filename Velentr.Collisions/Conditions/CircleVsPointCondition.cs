using System;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
    public class CircleVsPointCondition : CollisionCondition
    {
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
            var l = left.GetShapeDefinition();
            var r = right.GetShapeDefinition();

            if (l.Shape == Shape.Point && r.Shape == Shape.Point)
            {
                throw new ArgumentException("At least one shape must be a Circle!");
            }

            if (l.Shape == Shape.Circle && r.Shape == Shape.Circle)
            {
                throw new ArgumentException("At least one shape must be a Point!");
            }

            if (Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y))
            {
                return true;
            }

            CircleDefinition c;
            PointDefinition p;
            if (l.Shape == Shape.Point)
            {
                c = (CircleDefinition) r;
                p = (PointDefinition) l;
            }
            else
            {
                c = (CircleDefinition)l;
                p = (PointDefinition)r;
            }

            return Helpers.Math.SquaredDfifference(c.X, c.Y, p.X, p.Y) <= (c.Radius * c.Radius);
        }

    }
}
