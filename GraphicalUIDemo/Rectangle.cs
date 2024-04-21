using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalUIDemo
{
    class Rectangle : Shape
    {
        

        //Specfic propeties for Rectangle - NO

        // Properties - No

        // Constrcutor - Inheritance from base class constrcutor
        public Rectangle(Vector2 location, int width, int height, SolidBrush color) : base(location, width, height, color)
        {
        }

        // Methods - Polymorphism
        override public void draw(Graphics canvas)
        {
            canvas.FillRectangle(color, location.X, location.Y, width, height);
        }

        public PointF[] GetVertices()
        {
            PointF[] vertices = new PointF[4];

            // Top-left vertex
            vertices[0] = new PointF(location.X, 0);

            // Top-right vertex
            vertices[1] = new PointF(location.X + width, location.Y);

            // Bottom-right vertex
            vertices[2] = new PointF(location.X + width, location.Y + height);

            // Bottom-left vertex
            vertices[3] = new PointF(location.X, location.Y + height);

            return vertices;
        }
    }
}
