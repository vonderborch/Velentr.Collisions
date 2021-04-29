namespace Velentr.Collisions.ShapeDefinitions
{
    /// <summary>
    ///     A shape definition.
    /// </summary>
    public abstract class ShapeDefinition
    {
        /// <summary>
        ///     Gets or sets the shape.
        /// </summary>
        ///
        /// <value>
        ///     The shape.
        /// </value>
        public Shape Shape { get; set; }

        /// <summary>
        ///     Gets or sets the x coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The x coordinate.
        /// </value>
        public virtual double X { get; set; }

        /// <summary>
        ///     Gets or sets the y coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The y coordinate.
        /// </value>
        public virtual double Y { get; set; }
    }
}
