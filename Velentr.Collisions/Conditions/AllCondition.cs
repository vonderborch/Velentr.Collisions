using System;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Velentr.Collisions.Conditions.CollisionCondition" />
    public class AllCondition : CollisionCondition
    {
        /// <summary>
        /// The conditions
        /// </summary>
        private CollisionCondition[] _conditions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCondition"/> class.
        /// </summary>
        /// <param name="conditions">The conditions.</param>
        public AllCondition(params CollisionCondition[] conditions)
        {
            _conditions = conditions;
        }

        /// <summary>
        /// Evaluates whether two shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        public override bool Collision(IShape left, IShape right)
        {
            for (var i = 0; i < _conditions.Length; i++)
            {
                if (!_conditions[i].Collision(left, right))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Evaluates whether two or more shapes are colliding.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="testingMode">The testing mode to use for the conditions.</param>
        /// <param name="right">Shapes to test the left shape against.</param>
        /// <returns>
        /// True if the shapes collide, false otherwise.
        /// </returns>
        /// <exception cref="System.ArgumentException">There must be at most the same amount of shapes as there are conditions to test against!</exception>
        public override bool Collision(IShape left, CollisionTestingMode testingMode, params IShape[] right)
        {
            if (right.Length > _conditions.Length)
            {
                throw new ArgumentException("There must be at most the same amount of shapes as there are conditions to test against!");
            }

            if (right.Length == 0)
            {
                throw new ArgumentException("There must be at least one shape to test against!");
            }

            switch (testingMode)
            {
                case CollisionTestingMode.AllShapesMustCollide:
                case CollisionTestingMode.AnyShapeCanCollide:
                    throw new ArgumentException("Multi-shape collision only accepts CollisionTestingMode.EachShapeTestAgainstAllConditions and CollisionTestingMode.EachShapeTestAgainstOneCondition for this CollisionCondition type!");
            }

            switch (testingMode)
            {
                case CollisionTestingMode.EachShapeTestAgainstAllConditions:
                    for (var i = 0; i < right.Length; i++)
                    {
                        if (!Collision(left, right[i]))
                        {
                            return false;
                        }
                    }

                    break;
                case CollisionTestingMode.EachShapeTestAgainstOneCondition:
                    var maxShapeIndex = _conditions.Length - 1;
                    for (var i = 0; i < _conditions.Length; i++)
                    {
                        var ri = i < _conditions.Length ? i : maxShapeIndex;
                        if (!_conditions[i].Collision(left, right[ri]))
                        {
                            return false;
                        }
                    }

                    break;
            }

            return true;
        }

    }
}
