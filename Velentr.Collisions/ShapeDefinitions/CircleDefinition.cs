namespace Velentr.Collisions.ShapeDefinitions
{
    public class CircleDefinition : ShapeDefinition
    {
        public CircleDefinition()
        {
            Shape = Shape.Circle;
        }

        public double Radius { get; set; }
    }
}
