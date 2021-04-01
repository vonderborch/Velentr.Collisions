using System;

namespace Velentr.Collisions.Shapes
{
    public struct Rectangle : IShape
    {
        public class RectangleDefinition : ShapeDefinition
        {

            public double Width { get; set; }

            public double Height { get; set; }

            public double Left => X;

            public double Right => X + Width;

            public double Top => Y;

            public double Bottom => Y + Height;

        }

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
                Shape = Shape.Rectangle,
            };
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

    }
}
