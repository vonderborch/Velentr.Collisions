namespace Velentr.Collisions.ShapeDefinitions
{
    /// <summary>
    ///     A rectangle definition.
    /// </summary>
    ///
    /// <seealso cref="ShapeDefinition"/>
    public class RectangleDefinition : ShapeDefinition
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public RectangleDefinition()
        {
            Shape = Shape.Rectangle;
        }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        ///
        /// <value>
        ///     The width.
        /// </value>
        public double Width { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        ///
        /// <value>
        ///     The height.
        /// </value>
        public double Height { get; set; }

        /// <summary>
        ///     Gets the left.
        /// </summary>
        ///
        /// <value>
        ///     The left.
        /// </value>
        public double Left => X;

        /// <summary>
        ///     Gets the right.
        /// </summary>
        ///
        /// <value>
        ///     The right.
        /// </value>
        public double Right => X + Width;

        /// <summary>
        ///     Gets the top.
        /// </summary>
        ///
        /// <value>
        ///     The top.
        /// </value>
        public double Top => Y;

        /// <summary>
        ///     Gets the bottom.
        /// </summary>
        ///
        /// <value>
        ///     The bottom.
        /// </value>
        public double Bottom => Y + Height;

    }
}
