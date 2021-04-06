# Velentr.Collisions
A simple collision detection library, not intended as a full physics engine replacement.


# Installation
Nuget packages are available:
- Generic: [Velentr.Collisions](https://www.nuget.org/packages/Velentr.Collisions/)
- MonoGame (contains some helper methods to convert Rectangles, etc.): [Velentr.Collisions.MonoGame](https://www.nuget.org/packages/Velentr.Collisions.MonoGame/)
- FNA (contains some helper methods to convert Rectangles, etc.): [Velentr.Collisions.FNA](https://www.nuget.org/packages/Velentr.Collisions.FNA/)

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
- Currently the library uses doubles internally rather than floats as in most XNA-derived frameworks for similar structs

# Future Plans
See list of issues under the Milestones: https://github.com/vonderborch/Velentr.Collisions/milestones
