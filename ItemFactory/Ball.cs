using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
