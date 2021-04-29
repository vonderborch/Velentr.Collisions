using System;
using System.Text;
using Velentr.Collisions.ShapeDefinitions;
using Velentr.Collisions.Shapes;

namespace Velentr.Collisions.Helpers
{
    /// <summary>
    ///     Helpers for working with shapes.
    /// </summary>
    public static class ShapeHelpers
    {
        /// <summary>
        ///     Query if 'shape' is valid shape.
        /// </summary>
        ///
        /// <param name="shape">       The shape. </param>
        /// <param name="validShapes"> The valid shapes. </param>
        ///
        /// <returns>
        ///     True if valid shape, false if not.
        /// </returns>
        public static bool IsValidShape(Shape shape, Shape[] validShapes)
        {
            for (var i = 0; i < validShapes.Length; i++)
            {
                if (shape == validShapes[i])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Gets shape definitions.
        /// </summary>
        ///
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        ///
        /// <typeparam name="Shape1"> Type of the shape 1. </typeparam>
        /// <typeparam name="Shape2"> Type of the shape 2. </typeparam>
        /// <param name="left">        The left. </param>
        /// <param name="right">       The right. </param>
        /// <param name="validShapes"> The valid shapes. </param>
        ///
        /// <returns>
        ///     The shape definitions.
        /// </returns>
        public static (Shape1, Shape2) GetShapeDefinitions<Shape1, Shape2>(IShape left, IShape right, Shape[] validShapes)
            where Shape1 : ShapeDefinition
            where Shape2 : ShapeDefinition
        {
            var l = left.GetShapeDefinition();
            var r = right.GetShapeDefinition();

            if (validShapes.Length > 2)
            {
                throw new ArgumentException("There must be only two valid shapes!");
            }

            if (!IsValidShape(l.Shape, validShapes) || IsValidShape(r.Shape, validShapes))
            {
                var str = new StringBuilder();
                var first = true;
                for (var i = 0; i < validShapes.Length; i++)
                {
                    if (first)
                    {
                        str.Append(validShapes[i].ToString());
                        first = false;
                    }
                    else
                    {
                        str.Append($", {validShapes[i]}");
                    }
                }
                throw new ArgumentException($"Shapes must be a valid shape for this type of collision! Valid Shapes: {str}");
            }

            if (l.Shape == validShapes[0] && r.Shape == validShapes[0])
            {
                throw new ArgumentException($"At least one shape must be a {validShapes[0]}!");
            }

            if (l.Shape == validShapes[1] && r.Shape == validShapes[1])
            {
                throw new ArgumentException($"At least one shape must be a {validShapes[1]}!");
            }

            Shape1 s1;
            Shape2 s2;
            if (l.Shape == Shape.Point)
            {
                s1 = (Shape1)r;
                s2 = (Shape2)l;
            }
            else
            {
                s1 = (Shape1)l;
                s2 = (Shape2)r;
            }

            return (s1, s2);
        }
    }
}
