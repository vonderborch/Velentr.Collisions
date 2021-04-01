using System;
using System.Collections.Generic;
using System.Text;

namespace Velentr.Collisions.Shapes
{
    public struct Point : IShape
    {
        public class PointDefinition : ShapeDefinition
        {
        }

        public Point(double x, double y)
        {
            _definition = new PointDefinition()
            {
                X = x,
                Y = y,
                Shape = Shape.Point,
            };
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

    }
}
