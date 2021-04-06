using System;
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    public struct Circle : IShape
    {

        private CollisionCondition _point;

        private CollisionCondition _rectangle;

        private CollisionCondition _circle;

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
        }

        public Circle(Circle circle) : this(circle.X, circle.Y, circle.Radius)
        { }

        private readonly CircleDefinition _definition;

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

        public double Radius
        {
            get => _definition.Radius;
            set => _definition.Radius = value;
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
