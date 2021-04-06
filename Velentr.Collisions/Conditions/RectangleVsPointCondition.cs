using System;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
    public class RectangleVsPointCondition : CollisionCondition
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
        /// At least one shape must be a Rectangle!
        /// or
        /// At least one shape must be a Point!
        /// </exception>
        public override bool Collision(IShape left, IShape right)
        {
            var l = left.GetShapeDefinition();
            var r = right.GetShapeDefinition();

            if (l.Shape == Shape.Point && r.Shape == Shape.Point)
            {
                throw new ArgumentException("At least one shape must be a Rectangle!");
            }

            if (l.Shape == Shape.Rectangle && r.Shape == Shape.Rectangle)
            {
                throw new ArgumentException("At least one shape must be a Point!");
            }

            if (Helpers.Math.ApproximatelyEqual(l.X, r.X) && Helpers.Math.ApproximatelyEqual(l.Y, r.Y))
            {
                return true;
            }

            RectangleDefinition rec1;
            RectangleDefinition rec2;
            if (l.Shape == Shape.Rectangle)
            {
                rec1 = new RectangleDefinition()
                {
                    X = r.X,
                    Y = r.Y,
                    Height = 0,
                    Width = 0,
                    Shape = Shape.Rectangle,
                };
                rec2 = (RectangleDefinition)l;
            }
            else
            {
                rec1 = new RectangleDefinition()
                {
                    X = l.X,
                    Y = l.Y,
                    Height = 0,
                    Width = 0,
                    Shape = Shape.Rectangle,
                };
                rec2 = (RectangleDefinition)r;
            }

            return rec1.Right >= rec2.Left && rec1.Left <= rec2.Right && rec1.Bottom >= rec2.Top && rec1.Top <= rec2.Bottom;
        }

    }
}
