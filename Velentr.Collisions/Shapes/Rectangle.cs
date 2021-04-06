using System;
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    public struct Rectangle : IShape
    {

        private CollisionCondition _point;

        private CollisionCondition _rectangle;

        private CollisionCondition _circle;

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
        }

        public Rectangle(Rectangle rectangle) : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
        { }

        private readonly RectangleDefinition _definition;

        public double X
        {
            get => _definition.X;
            set => _definition.X = value;
        }

        public double Y
        {
            get => _definition.Y;
            set => _definition.Y = value;
        }

        public double Width
        {
            get => _definition.Width;
            set => _definition.Width = value;
        }

        public double Height
        {
            get => _definition.Height;
            set => _definition.Height = value;
        }

        public ShapeDefinition GetShapeDefinition()
        {
            return _definition;
        }

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
        public Microsoft.Xna.Framework.Rectangle ToXnaRectangle() {
            return new Microsoft.Xna.Framework.Rectangle((int)_definition.X, (int)_definition.Y, (int)_definition.Width, (int)_definition.Height);
        }

        public Rectangle FromXnaRectangle(Microsoft.Xna.Framework.Rectangle from)
        {
            return new Rectangle(from.X, from.Y, from.Width, from.Height);
        }
#endif
    }
}
