using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalUIDemo
{
    internal class Star : Shape
    {
        //Properities
        public Image image = Properties.Resources.star;

        //Constructors
        public Star(int width, int height, Vector2 location, SolidBrush color) :
               base(location, width, height, color)
        {
        }

        //draw
        //Override the draw() method in parent class
        override public void draw(Graphics canvas)
        {
            //canvas.DrawImage(image, topLeft.X, topLeft.Y, width, height);
            canvas.DrawImage(image, location.X, location.Y, width, height);
        }
    }
}
