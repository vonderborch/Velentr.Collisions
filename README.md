# Velentr.Collisions
A simple collision detection library, not intended as a full physics engine replacement.


# Installation
A nuget package is available: [Velentr.Collisions](https://www.nuget.org/packages/Velentr.Collisions/)

# Basic Usage
```
// first we define a new collision condition and some shapes
var condition = new RectangleVsRectangleCondition();
var leftShape = new Rectangle(0, 0, 10, 10);
var rightShape = new Rectangle(5, 5, 10, 10);

// then we test if we have a collision
if (condition.Collision(leftShape, rightShape))
{
    // Take action on a collision!
}
else
{
    // Take action if there is not a collision!
}
```

# Chaining Conditions
We can also chain collision conditions and/or shapes!
```
// first we define a new collision condition and some shapes
var condition = new AllCondition(
    new RectangleVsRectangleCondition(),
    new RectangleVsRectangleCondition(),
    new RectangleVsPointCondition()
);
var leftShape = new Rectangle(0, 0, 10, 10);
var rightShape1 = new Rectangle(0, 0, 100, 100);
var rightShape2 = new Rectangle(3, 3, 10, 10);
var rightShape3 = new Point(3, 3);

// then we test if we have a collision
if (condition.Collision(leftShape, CollisionTestingMode.AllShapesMustCollide, rightShape1, rightShape2, rightShape3))
{
    // Take action on a collision!
}
else
{
    // Take action if there is not a collision!
}
```



# Notes
- This library uses it's own internal Rectangle, Circle, and Point structs to define shapes (more may come in the future). There is no built-in support for converting to/from XNA-derived framework's Rectangle, Vector2, or Point structs, but it should be fairly simple to convert (the properties are basically the same)
- Currently the library uses doubles internally rather than floats as in most XNA-derived frameworks for similar structs

# Future Plans
See list of issues under the Milestones: https://github.com/vonderborch/Velentr.Collisions/milestones
