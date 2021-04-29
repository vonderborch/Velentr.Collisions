using System;
#if MONOGAME || FNA
using Microsoft.Xna.Framework;
#endif
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    /// <summary>
    ///     A point.
    /// </summary>
    public struct Point : IShape
    {
        /// <summary>
        ///     The point.
        /// </summary>
        private CollisionCondition _point;

        /// <summary>
        ///     The rectangle.
        /// </summary>
        private CollisionCondition _rectangle;

        /// <summary>
        ///     The circle.
        /// </summary>
        private CollisionCondition _circle;

        /// <summary>
        ///     The pixel rectangle.
        /// </summary>
        private CollisionCondition _pixelRectangle;

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        public Point(double x, double y)
        {
            _definition = new PointDefinition()
            {
                X = x,
                Y = y,
            };

            _point = null;
            _rectangle = null;
            _circle = null;
            _pixelRectangle = null;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="point"> The point. </param>
        public Point(Point point) : this(point.X, point.Y)
        { }

        /// <summary>
        ///     (Immutable) the definition.
        /// </summary>
        private readonly PointDefinition _definition;

        /// <summary>
        ///     Gets or sets the x coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The x coordinate.
        /// </value>
        public double X
        {
            get => _definition.X;
            set => _definition.X = value;
        }

        /// <summary>
        ///     Gets or sets the y coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The y coordinate.
        /// </value>
        public double Y
        {
            get => _definition.Y;
            set => _definition.Y = value;
        }

        /// <summary>
        ///     Gets the shape definition.
        /// </summary>
        ///
        /// <returns>
        ///     The shape definition.
        /// </returns>
        ///
        /// <seealso cref="IShape.GetShapeDefinition()"/>
        public ShapeDefinition GetShapeDefinition()
        {
            return _definition;
        }

        /// <summary>
        ///     Collides the current shape against another shape.
        /// </summary>
        ///
        /// <param name="against"> The against. </param>
        ///
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        ///
        /// <seealso cref="IShape.Collision(IShape)"/>
        public bool Collision(IShape against)
        {
            switch (against.GetShapeDefinition().Shape)
            {
                case Shape.Point:
                    if (_point == null)
                    {
                        _point = new PointVsPoint();
                    }
                    return _point.Collision(this, against);
                case Shape.Rectangle:
                    if (_rectangle == null)
                    {
                        _rectangle = new RectangleVsPointCondition();
                    }
                    return _rectangle.Collision(this, against);
                case Shape.Circle:
                    if (_circle == null)
                    {
                        _circle = new CircleVsPointCondition();
                    }
                    return _circle.Collision(this, against);
            }

            return false;
        }

        /// <summary>
        ///     Collides the current shape against another shape.
        /// </summary>
        ///
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        ///
        /// <param name="testingMode"> The testing mode to use for the conditions. </param>
        /// <param name="against">     Shapes to test the shape against. </param>
        ///
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        ///
        /// <seealso cref="IShape.Collision(CollisionTestingMode,params IShape[])"/>
        public bool Collision(CollisionTestingMode testingMode, params IShape[] against)
        {
            switch (testingMode)
            {
                case CollisionTestingMode.EachShapeTestAgainstAllConditions:
                case CollisionTestingMode.EachShapeTestAgainstOneCondition:
                    throw new ArgumentException("Multi-shape collision only accepts CollisionTestingMode.AllShapesMustCollide and CollisionTestingMode.AnyShapeCanCollide!");
            }

            var hasCollided = false;
            for (var i = 0; i < against.Length; i++)
            {
                var collision = Collision(against[i]);
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

#if MONOGAME || FNA

        /// <summary>
        ///     Converts this object to a vector 2.
        /// </summary>
        ///
        /// <returns>
        ///     This object as a Vector2.
        /// </returns>
        public Vector2 ToVector2() {
            return new Vector2((float)_definition.X, (float)_definition.Y);
        }

        /// <summary>
        ///     Initializes this object from the given vector 2.
        /// </summary>
        ///
        /// <param name="from"> Source for the. </param>
        ///
        /// <returns>
        ///     A Point.
        /// </returns>
        public Point FromVector2(Vector2 from)
        {
            return new Point(from.X, from.Y);
        }

        /// <summary>
        ///     Converts this object to an xna point.
        /// </summary>
        ///
        /// <returns>
        ///     This object as a Microsoft.Xna.Framework.Point.
        /// </returns>
        public Microsoft.Xna.Framework.Point ToXnaPoint()
        {
            return new Microsoft.Xna.Framework.Point((int)_definition.X, (int)_definition.Y);
        }

        /// <summary>
        ///     Initializes this object from the given xna point.
        /// </summary>
        ///
        /// <param name="from"> Source for the. </param>
        ///
        /// <returns>
        ///     A Point.
        /// </returns>
        public Point FromXnaPoint(Microsoft.Xna.Framework.Point from)
        {
            return new Point(from.X, from.Y);
        }
#endif
    }
}
