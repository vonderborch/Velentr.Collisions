using System;
using Velentr.Collisions.Shapes;
using Math = Velentr.Collisions.Helpers.Math;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
    public class CircleVsRectangleCondition : CollisionCondition
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
        /// At least one shape must be a Rectangle!
        /// </exception>
        public override bool Collision(IShape left, IShape right)
        {
            var l = left.GetShapeDefinition();
            var r = right.GetShapeDefinition();

            if (l.Shape == Shape.Rectangle && r.Shape == Shape.Rectangle)
            {
                throw new ArgumentException("At least one shape must be a Circle!");
            }

            if (l.Shape == Shape.Circle && r.Shape == Shape.Circle)
            {
                throw new ArgumentException("At least one shape must be a Rectangle!");
            }

            if (Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y))
            {
                return true;
            }

            Circle.CircleDefinition c;
            Rectangle.RectangleDefinition rec;
            if (l.Shape == Shape.Rectangle)
            {
                c = (Circle.CircleDefinition)r;
                rec = (Rectangle.RectangleDefinition)l;
            }
            else
            {
                c = (Circle.CircleDefinition)l;
                rec = (Rectangle.RectangleDefinition)r;
            }

            return Math.SquaredDfifference(c.X, c.Y, Math.Clamp(c.X, rec.Left, rec.Right), Math.Clamp(c.Y, rec.Top, rec.Bottom)) <= c.Radius;
        }

    }
}
