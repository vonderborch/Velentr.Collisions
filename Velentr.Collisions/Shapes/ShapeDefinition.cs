using System;
using System.Collections.Generic;
using System.Text;

namespace Velentr.Collisions.Shapes
{
    public abstract class ShapeDefinition
    {
        public Shape Shape { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
