using System;
#if MONOGAME || FNA
using Microsoft.Xna.Framework;
#endif
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    public struct Point : IShape
    {
        private CollisionCondition _point;

        private CollisionCondition _rectangle;

        private CollisionCondition _circle;

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
        }

        public Point(Point point) : this(point.X, point.Y)
        { }

        private readonly PointDefinition _definition;

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

        public Vector2 ToVector2() {
            return new Vector2((float)_definition.X, (float)_definition.Y);
        }

        public Point FromVector2(Vector2 from)
        {
            return new Point(from.X, from.Y);
        }
#endif

#if MONOGAME
        public Microsoft.Xna.Framework.Point ToXnaPoint()
        {
            return new Microsoft.Xna.Framework.Point((int)_definition.X, (int)_definition.Y);
        }

        public Point FromXnaPoint(Microsoft.Xna.Framework.Point from)
        {
            return new Point(from.X, from.Y);
        }
#endif
    }
}
