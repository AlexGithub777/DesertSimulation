
using System.Drawing;
using System.Numerics;


namespace ItemFactory
{
    class Ball : Shape
    {
        //Specfic propeties for ball - NO

        // Properties - No

        // Constrcutor - Inheritance from base class constrcutor
        public Ball(Vector2 location, int width, int height, SolidBrush color) : base(location, width, height, color)
        {
        }

        // Methods - Polymorphism
        override public void draw(Graphics canvas)
        {
            canvas.FillEllipse(color, location.X, location.Y, width, height);
        }
    }
}
