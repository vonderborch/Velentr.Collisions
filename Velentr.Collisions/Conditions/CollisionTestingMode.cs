namespace Velentr.Collisions.Conditions
{
    /// <summary>
    /// The collision testing mode to use when testing many different shapes against one shape
    /// </summary>
    public enum CollisionTestingMode
    {
        /// <summary>
        /// Test each shape on the right against the shape on the left against all conditions
        /// NOTE: Only compatible with AnyCondition and AllCondition conditions!
        /// </summary>
        EachShapeTestAgainstAllConditions,

        /// <summary>
        /// Test each shape on the right against the shape on the left against one condition (order-dependent)
        /// NOTE: Only compatible with AnyCondition and AllCondition conditions!
        /// </summary>
        EachShapeTestAgainstOneCondition,

        /// <summary>
        /// All shapes must collide
        /// NOTE: Not compatible for AnyCondition and AllCondition conditions!
        /// </summary>
        AllShapesMustCollide,

        /// <summary>
        /// Any shape can collide
        /// NOTE: Not compatible for AnyCondition and AllCondition conditions!
        /// </summary>
        AnyShapeCanCollide,
    }
}
