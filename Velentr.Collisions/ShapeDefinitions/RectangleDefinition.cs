namespace Velentr.Collisions.ShapeDefinitions
{
    public class RectangleDefinition : ShapeDefinition
    {

        public RectangleDefinition()
        {
            Shape = Shape.Rectangle;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Left => X;

        public double Right => X + Width;

        public double Top => Y;

        public double Bottom => Y + Height;

    }
}
