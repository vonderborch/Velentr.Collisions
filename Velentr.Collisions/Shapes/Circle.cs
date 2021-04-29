using System;
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    /// <summary>
    ///     A circle.
    /// </summary>
    public struct Circle : IShape
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
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        ///
        /// <param name="x">      The x coordinate. </param>
        /// <param name="y">      The y coordinate. </param>
        /// <param name="radius"> The radius. </param>
        public Circle(double x, double y, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius can not be less than 0!");
            }

            _definition = new CircleDefinition()
            {
                Radius = radius,
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
        /// <param name="circle"> The circle. </param>
        public Circle(Circle circle) : this(circle.X, circle.Y, circle.Radius)
        { }

        /// <summary>
        ///     (Immutable) the definition.
        /// </summary>
        private readonly CircleDefinition _definition;

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
        ///     Gets or sets the radius.
        /// </summary>
        ///
        /// <value>
        ///     The radius.
        /// </value>
        public double Radius
        {
            get => _definition.Radius;
            set => _definition.Radius = value;
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
                        _point = new CircleVsPointCondition();
                    }
                    return _point.Collision(this, against);
                case Shape.Rectangle:
                    if (_rectangle == null)
                    {
                        _rectangle = new CircleVsRectangleCondition();
                    }
                    return _rectangle.Collision(this, against);
                case Shape.Circle:
                    if (_circle == null)
                    {
                        _circle = new CircleVsCircleCondition();
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

    }
}
