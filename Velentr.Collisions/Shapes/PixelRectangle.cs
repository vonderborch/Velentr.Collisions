using System;
using System.Linq;
#if FNA || MONOGAME
using Microsoft.Xna.Framework.Graphics;
#endif
using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    /// <summary>
    ///     A pixel rectangle.
    /// </summary>
    public struct PixelRectangle : IShape
    {
        /// <summary>
        ///     The point.
        /// </summary>
        private CollisionCondition _point;

        /// <summary>
        ///     The rectangle.
        /// </summary>
        private CollisionCondition _rectangle;

        /// <summary>
        ///     The circle.
        /// </summary>
        private CollisionCondition _circle;

        /// <summary>
        ///     The pixel rectangle.
        /// </summary>
        private CollisionCondition _pixelRectangle;

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        ///
        /// <param name="x">           The x coordinate. </param>
        /// <param name="y">           The y coordinate. </param>
        /// <param name="width">       The width. </param>
        /// <param name="height">      The height. </param>
        /// <param name="colors">      The colors. </param>
        /// <param name="maxRChannel"> (Optional) The maximum r channel. </param>
        /// <param name="maxGChannel"> (Optional) The maximum g channel. </param>
        /// <param name="maxBChannel"> (Optional) The maximum b channel. </param>
        /// <param name="maxAChannel"> (Optional) The maximum a channel. </param>
        public PixelRectangle(int x, int y, int width, int height, Color[] colors, byte maxRChannel = 255, byte maxGChannel = 255, byte maxBChannel = 255, byte maxAChannel = 20)
        {
            if (width < 0)
            {
                throw new ArgumentException("Width can not be less than 0!");
            }
            if (height < 0)
            {
                throw new ArgumentException("Height can not be less than 0!");
            }

            _definition = new PixelRectangleDefinition()
            {
                Width = width,
                Height = height,
                IntX = x,
                IntY = y,
                ColorArray = colors,
                MaxRedChannel = maxRChannel,
                MaxBlueChannel = maxBChannel,
                MaxGreenChannel = maxGChannel,
                MaxAlphaChannel = maxAChannel,
            };

            _point = null;
            _rectangle = null;
            _circle = null;
            _pixelRectangle = null;
        }

#if FNA || MONOGAME

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="x">           The x coordinate. </param>
        /// <param name="y">           The y coordinate. </param>
        /// <param name="texture">     The texture. </param>
        /// <param name="maxRChannel"> (Optional) The maximum r channel. </param>
        /// <param name="maxGChannel"> (Optional) The maximum g channel. </param>
        /// <param name="maxBChannel"> (Optional) The maximum b channel. </param>
        /// <param name="maxAChannel"> (Optional) The maximum a channel. </param>
        public PixelRectangle(int x, int y, Texture2D texture, byte maxRChannel = 255, byte maxGChannel = 255, byte maxBChannel = 255, byte maxAChannel = 20)
        {
            var colorsRaw = new Microsoft.Xna.Framework.Color[texture.Width * texture.Height];
            texture.GetData<Microsoft.Xna.Framework.Color>(colorsRaw, 0, colorsRaw.Length);
            var colors = colorsRaw.Select(c => (Color)c).ToArray();

            _definition = new PixelRectangleDefinition()
            {
                Width = texture.Width,
                Height = texture.Height,
                IntX = x,
                IntY = y,
                ColorArray = colors,
                MaxRedChannel = maxRChannel,
                MaxBlueChannel = maxBChannel,
                MaxGreenChannel = maxGChannel,
                MaxAlphaChannel = maxAChannel,
            };

            _point = null;
            _rectangle = null;
            _circle = null;
            _pixelRectangle = null;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="x">           The x coordinate. </param>
        /// <param name="y">           The y coordinate. </param>
        /// <param name="width">       The width. </param>
        /// <param name="height">      The height. </param>
        /// <param name="colors">      The colors. </param>
        /// <param name="maxRChannel"> (Optional) The maximum r channel. </param>
        /// <param name="maxGChannel"> (Optional) The maximum g channel. </param>
        /// <param name="maxBChannel"> (Optional) The maximum b channel. </param>
        /// <param name="maxAChannel"> (Optional) The maximum a channel. </param>
        public PixelRectangle(int x, int y, int width, int height, Microsoft.Xna.Framework.Color[] colors, byte maxRChannel = 255, byte maxGChannel = 255, byte maxBChannel = 255, byte maxAChannel = 20)
        {
            var actualColors = colors.Select(c => (Color)c).ToArray();

            _definition = new PixelRectangleDefinition()
            {
                Width = width,
                Height = height,
                IntX = x,
                IntY = y,
                ColorArray = actualColors,
                MaxRedChannel = maxRChannel,
                MaxBlueChannel = maxBChannel,
                MaxGreenChannel = maxGChannel,
                MaxAlphaChannel = maxAChannel,
            };

            _point = null;
            _rectangle = null;
            _circle = null;
            _pixelRectangle = null;
        }
#endif

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="rectangle"> The rectangle. </param>
        public PixelRectangle(PixelRectangle rectangle) : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, rectangle.Colors, rectangle.MaxRedChannel, rectangle.MaxGreenChannel, rectangle.MaxBlueChannel, rectangle.MaxAlphaChannel)
        { }

        /// <summary>
        ///     (Immutable) the definition.
        /// </summary>
        private readonly PixelRectangleDefinition _definition;

        /// <summary>
        ///     Gets or sets the maximum red channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum red channel.
        /// </value>
        public byte MaxRedChannel
        {
            get => _definition.MaxRedChannel;
            set => _definition.MaxRedChannel = value;
        }

        /// <summary>
        ///     Gets or sets the maximum green channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum green channel.
        /// </value>
        public byte MaxGreenChannel
        {
            get => _definition.MaxGreenChannel;
            set => _definition.MaxGreenChannel = value;
        }

        /// <summary>
        ///     Gets or sets the maximum blue channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum blue channel.
        /// </value>
        public byte MaxBlueChannel
        {
            get => _definition.MaxBlueChannel;
            set => _definition.MaxBlueChannel = value;
        }

        /// <summary>
        ///     Gets or sets the maximum alpha channel.
        /// </summary>
        ///
        /// <value>
        ///     The maximum alpha channel.
        /// </value>
        public byte MaxAlphaChannel
        {
            get => _definition.MaxAlphaChannel;
            set => _definition.MaxAlphaChannel = value;
        }

        /// <summary>
        ///     Gets or sets the x coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The x coordinate.
        /// </value>
        public int X
        {
            get => _definition.IntX;
            set => _definition.IntX = value;
        }

        /// <summary>
        ///     Gets or sets the y coordinate.
        /// </summary>
        ///
        /// <value>
        ///     The y coordinate.
        /// </value>
        public int Y
        {
            get => _definition.IntY;
            set => _definition.IntY = value;
        }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        ///
        /// <value>
        ///     The width.
        /// </value>
        public int Width
        {
            get => _definition.Width;
            set => _definition.Width = value;
        }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        ///
        /// <value>
        ///     The height.
        /// </value>
        public int Height
        {
            get => _definition.Height;
            set => _definition.Height = value;
        }

        /// <summary>
        ///     Gets or sets the colors.
        /// </summary>
        ///
        /// <value>
        ///     The colors.
        /// </value>
        public Color[] Colors
        {
            get => _definition.ColorArray;
            set => _definition.ColorArray = value;
        }

        /// <summary>
        ///     Gets the shape definition.
        /// </summary>
        ///
        /// <returns>
        ///     The shape definition.
        /// </returns>
        ///
        /// <seealso cref="IShape.GetShapeDefinition()"/>
        public ShapeDefinition GetShapeDefinition()
        {
            return _definition;
        }

        /// <summary>
        ///     Collides the current shape against another shape.
        /// </summary>
        ///
        /// <param name="against"> The against. </param>
        ///
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        ///
        /// <seealso cref="IShape.Collision(IShape)"/>
        public bool Collision(IShape against)
        {
            switch (against.GetShapeDefinition().Shape)
            {
                case Shape.Point:
                    if (_point == null)
                    {
                        _point = new RectangleVsPointCondition();
                    }
                    return _point.Collision(this, against);
                case Shape.Rectangle:
                    if (_rectangle == null)
                    {
                        _rectangle = new RectangleVsRectangleCondition();
                    }
                    return _rectangle.Collision(this, against);
                case Shape.Circle:
                    if (_circle == null)
                    {
                        _circle = new CircleVsRectangleCondition();
                    }
                    return _circle.Collision(this, against);
                case Shape.PixelRectangle:
                    if (_pixelRectangle == null)
                    {
                        _pixelRectangle = new PixelRectangleVsPixelRectangleCondition();
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        ///     Collides the current shape against another shape.
        /// </summary>
        ///
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        ///
        /// <param name="testingMode"> The testing mode to use for the conditions. </param>
        /// <param name="against">     Shapes to test the shape against. </param>
        ///
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        ///
        /// <seealso cref="IShape.Collision(CollisionTestingMode,params IShape[])"/>
        public bool Collision(CollisionTestingMode testingMode, params IShape[] against)
        {
            switch (testingMode)
            {
                case CollisionTestingMode.EachShapeTestAgainstAllConditions:
                case CollisionTestingMode.EachShapeTestAgainstOneCondition:
                    throw new ArgumentException("Multi-shape collision only accepts CollisionTestingMode.AllShapesMustCollide and CollisionTestingMode.AnyShapeCanCollide!");
            }

            var hasCollided = false;
            for (var i = 0; i < against.Length; i++)
            {
                var collision = Collision(against[i]);
                if (!collision && testingMode == CollisionTestingMode.AllShapesMustCollide)
                {
                    return false;
                }
                else if (collision)
                {
                    hasCollided = true;
                }
            }

            return hasCollided;
        }
    }
}
