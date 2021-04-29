using System;
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    /// <summary>
    ///     A rectangle.
    /// </summary>
    public struct Rectangle : IShape
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
        /// <param name="width">  The width. </param>
        /// <param name="height"> The height. </param>
        public Rectangle(double x, double y, double width, double height)
        {
            if (width < 0)
            {
                throw new ArgumentException("Width can not be less than 0!");
            }
            if (height < 0)
            {
                throw new ArgumentException("Height can not be less than 0!");
            }

            _definition = new RectangleDefinition()
            {
                Width = width,
                Height = height,
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
        /// <param name="rectangle"> The rectangle. </param>
        public Rectangle(Rectangle rectangle) : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
        { }

        /// <summary>
        ///     (Immutable) the definition.
        /// </summary>
        private readonly RectangleDefinition _definition;

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
        ///     Gets or sets the width.
        /// </summary>
        ///
        /// <value>
        ///     The width.
        /// </value>
        public double Width
        {
            get => _definition.Width;
            set => _definition.Width = value;
        }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        ///
        /// <value>
        ///     The height.
        /// </value>
        public double Height
        {
            get => _definition.Height;
            set => _definition.Height = value;
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
                        _point = new RectangleVsPointCondition();
                    }
                    return _point.Collision(this, against);
                case Shape.Rectangle:
                    if (_rectangle == null)
                    {
                        _rectangle = new RectangleVsRectangleCondition();
                    }
                    return _rectangle.Collision(this, against);
                case Shape.Circle:
                    if (_circle == null)
                    {
                        _circle = new CircleVsRectangleCondition();
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
        ///     Converts this object to an xna rectangle.
        /// </summary>
        ///
        /// <returns>
        ///     This object as a Microsoft.Xna.Framework.Rectangle.
        /// </returns>
        public Microsoft.Xna.Framework.Rectangle ToXnaRectangle() {
            return new Microsoft.Xna.Framework.Rectangle((int)_definition.X, (int)_definition.Y, (int)_definition.Width, (int)_definition.Height);
        }

        /// <summary>
        ///     Initializes this object from the given xna rectangle.
        /// </summary>
        ///
        /// <param name="from"> Source for the. </param>
        ///
        /// <returns>
        ///     A Rectangle.
        /// </returns>
        public Rectangle FromXnaRectangle(Microsoft.Xna.Framework.Rectangle from)
        {
            return new Rectangle(from.X, from.Y, from.Width, from.Height);
        }
#endif
    }
}
