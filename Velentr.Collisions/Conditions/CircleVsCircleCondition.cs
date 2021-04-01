using System;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
    public class CircleVsCircleCondition : CollisionCondition
    {
        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        /// <exception cref="System.ArgumentException">Both shapes must be Circles!</exception>
        public override bool Collision(IShape left, IShape right)
        {
            var l = (Circle.CircleDefinition)left.GetShapeDefinition();
            var r = (Circle.CircleDefinition)right.GetShapeDefinition();

            if (l.Shape != Shape.Circle || r.Shape != Shape.Circle)
            {
                throw new ArgumentException("Both shapes must be Circles!");
            }

            if (Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y))
            {
                return true;
            }

            return Helpers.Math.GetDistance(l.X, l.Y, r.X, r.Y) <= (l.Radius + r.Radius);
        }

    }
}
