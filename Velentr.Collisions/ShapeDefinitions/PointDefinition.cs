namespace Velentr.Collisions.ShapeDefinitions
{
    /// <summary>
    ///     A point definition.
    /// </summary>
    ///
    /// <seealso cref="ShapeDefinition"/>
    public class PointDefinition : ShapeDefinition
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public PointDefinition()
        {
            Shape = Shape.Point;
        }
    }
}
