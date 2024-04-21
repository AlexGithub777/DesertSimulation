using GraphicalUIDemo;
using System.Drawing;
using System.Numerics;

internal class Freezer : Shape
{
    // Constructor
    // Constructor with hard-set values for color, size, and location
    public Freezer() : base(new Vector2(373, 100), 40, 40, new SolidBrush(Color.Aqua))
    { 
    }
    
    public override void draw(Graphics graphics)
    {
        graphics.FillRectangle(color, location.X, location.Y, width, height);
    }

    // Method to freeze a shape
    public void Freeze(Shape shape)
    {
        shape.IsFrozen = true;
    }
}
