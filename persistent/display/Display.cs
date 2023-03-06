using bases;
using enumeration.Orientation;
using enumeration.Shape;
using System;

namespace display
{
    public class Display : BaseEntity
    {
        public Shape Shape { get; set; } = Shape.Rectangle;
        public Orientation Orientation { get; set; } = Orientation.Right;
        public int Size { get; set; } = 70;
        public int Width { get; set; } = 70;
        public Boolean Scale { get; set; } = false;
    }

}