using System;

namespace Velentr.Collisions.ShapeDefinitions
{
    /// <summary>
    ///     A pixel rectangle definition.
    /// </summary>
    ///
    /// <seealso cref="ShapeDefinition"/>
    public class PixelRectangleDefinition : ShapeDefinition
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public PixelRectangleDefinition()
        {
            Shape = Shape.PixelRectangle;
        }

        /// <summary>
        ///     Gets or sets an array of colors.
        /// </summary>
        ///
        /// <value>
        ///     An array of colors.
        /// </value>
        public Color[] ColorArray { get; set; }

        /// <summary>
        ///     Gets or sets the x coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The x coordinate.
        /// </value>
        ///
        /// <seealso cref="Velentr.Collisions.ShapeDefinitions.ShapeDefinition.X"/>
        public override double X
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets or sets the y coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The y coordinate.
        /// </value>
        ///
        /// <seealso cref="Velentr.Collisions.ShapeDefinitions.ShapeDefinition.Y"/>
        public override double Y
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets or sets the int x coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The int x coordinate.
        /// </value>
        public int IntX { get; set; }

        /// <summary>
        ///     Gets or sets the int y coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The int y coordinate.
        /// </value>
        public int IntY { get; set; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        ///
        /// <value>
        ///     The width.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        ///
        /// <value>
        ///     The height.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        ///     Gets the left.
        /// </summary>
        ///
        /// <value>
        ///     The left.
        /// </value>
        public int Left => IntX;

        /// <summary>
        ///     Gets the right.
        /// </summary>
        ///
        /// <value>
        ///     The right.
        /// </value>
        public int Right => IntX + Width;

        /// <summary>
        ///     Gets the top.
        /// </summary>
        ///
        /// <value>
        ///     The top.
        /// </value>
        public int Top => IntY;

        /// <summary>
        ///     Gets the bottom.
        /// </summary>
        ///
        /// <value>
        ///     The bottom.
        /// </value>
        public int Bottom => IntY + Height;

        /// <summary>
        ///     Gets or sets the maximum red channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum red channel.
        /// </value>
        public byte MaxRedChannel { get; set; }

        /// <summary>
        ///     Gets or sets the maximum green channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum green channel.
        /// </value>
        public byte MaxGreenChannel { get; set; }

        /// <summary>
        ///     Gets or sets the maximum blue channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum blue channel.
        /// </value>
        public byte MaxBlueChannel { get; set; }

        /// <summary>
        ///     Gets or sets the maximum alpha channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum alpha channel.
        /// </value>
        public byte MaxAlphaChannel { get; set; }

    }
}
