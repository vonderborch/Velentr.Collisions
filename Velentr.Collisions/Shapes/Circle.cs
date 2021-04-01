using System;

namespace Velentr.Collisions.Shapes
{
    public struct Circle : IShape
    {

        public class CircleDefinition : ShapeDefinition
        {
            public double Radius { get; set; }
        }

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
                Shape = Shape.Circle,
            };
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

    }
}
