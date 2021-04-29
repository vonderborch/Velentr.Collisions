namespace Velentr.Collisions.ShapeDefinitions
{
    /// <summary>
    ///     A color.
    /// </summary>
    public struct Color
    {
        /// <summary>
        ///     Gets or sets the b.
        /// </summary>
        ///
        /// <value>
        ///     The b.
        /// </value>
        public byte B { get; set; }

        /// <summary>
        ///     Gets or sets the g.
        /// </summary>
        ///
        /// <value>
        ///     The g.
        /// </value>
        public byte G { get; set; }

        /// <summary>
        ///     Gets or sets the r.
        /// </summary>
        ///
        /// <value>
        ///     The r.
        /// </value>
        public byte R { get; set; }

        /// <summary>
        ///     Gets or sets a.
        /// </summary>
        ///
        /// <value>
        ///     a.
        /// </value>
        public byte A { get; set; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="r"> The red component. </param>
        /// <param name="g"> The green component. </param>
        /// <param name="b"> The byte value. </param>
        /// <param name="a"> The alpha component. </param>
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

#if FNA || MONOGAME

        /// <summary>
        ///     Implicit cast that converts the given Color to a Color.
        /// </summary>
        ///
        /// <param name="source"> Source for the. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Color(Color source)
        {
            return new Microsoft.Xna.Framework.Color(source.R, source.G, source.B, source.A);
        }

        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Color to a Color.
        /// </summary>
        ///
        /// <param name="source"> Source for the. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Color(Microsoft.Xna.Framework.Color source)
        {
            return new Color(source.R, source.G, source.B, source.A);
        }

#endif
    }
}
