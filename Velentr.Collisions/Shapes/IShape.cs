using Velentr.Collisions.Conditions;
using Velentr.Collisions.ShapeDefinitions;

namespace Velentr.Collisions.Shapes
{
    /// <summary>
    /// Defines a Velentr Shape
    /// </summary>
    public interface IShape
    {

        /// <summary>
        /// Gets the shape definition.
        /// </summary>
        /// <returns></returns>
        ShapeDefinition GetShapeDefinition();

        /// <summary>
        /// Collides the current shape against another shape
        /// </summary>
        /// <param name="against">The against.</param>
        /// <returns></returns>
        bool Collision(IShape against);

        /// <summary>
        /// Collides the current shape against another shape
        /// </summary>
        /// <param name="testingMode">The testing mode to use for the conditions.</param>
        /// <param name="against">Shapes to test the shape against.</param>
        /// <returns></returns>
        bool Collision(CollisionTestingMode testingMode, params IShape[] against);
    }
}
