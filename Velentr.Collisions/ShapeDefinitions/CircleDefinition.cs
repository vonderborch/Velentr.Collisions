namespace Velentr.Collisions.ShapeDefinitions
{
    /// <summary>
    ///     A circle definition.
    /// </summary>
    ///
    /// <seealso cref="ShapeDefinition"/>
    public class CircleDefinition : ShapeDefinition
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public CircleDefinition()
        {
            Shape = Shape.Circle;
        }

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        ///
        /// <value>
        ///     The radius.
        /// </value>
        public double Radius { get; set; }
    }
}
