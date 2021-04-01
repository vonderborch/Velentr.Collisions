using System;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// A way to test if collisions occur.
    /// </summary>
    public abstract class CollisionCondition
    {
        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>True if the shapes collide, false otherwise.</returns>
        public abstract bool Collision(IShape left, IShape right);

        /// <summary>
        /// Collisions the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="testingMode">The testing mode to use for the conditions.</param>
        /// <param name="right">Shapes to test the left shape against.</param>
        /// <returns></returns>
        public virtual bool Collision(IShape left, CollisionTestingMode testingMode, params IShape[] right)
        {
            switch (testingMode)
            {
                case CollisionTestingMode.EachShapeTestAgainstAllConditions:
                case CollisionTestingMode.EachShapeTestAgainstOneCondition:
                    throw new ArgumentException("Multi-shape collision only accepts CollisionTestingMode.AllShapesMustCollide and CollisionTestingMode.AnyShapeCanCollide for this CollisionCondition type!");
            }

            var hasCollided = false;
            for (var i = 0; i < right.Length; i++)
            {
                var collision = Collision(left, right[i]);
                if (!collision && testingMode == CollisionTestingMode.AllShapesMustCollide)
                {
                    return false;
                }
                else if (collision)
                {
                    hasCollided = true;
                }
            }

            return hasCollided;
        }

    }
}
