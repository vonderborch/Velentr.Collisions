using System;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
    public class RectangleVsRectangleCondition : CollisionCondition
    {
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
            var l = (RectangleDefinition)left.GetShapeDefinition();
            var r = (RectangleDefinition)right.GetShapeDefinition();

            if (l.Shape != Shape.Rectangle || r.Shape != Shape.Rectangle)
            {
                throw new ArgumentException("Both shapes must be Rectangles!");
            }

            if (Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y))
            {
                return true;
            }

            return l.Right >= r.Left && l.Left <= r.Right && l.Bottom >= r.Top && l.Top <= r.Bottom;
        }

    }
}
