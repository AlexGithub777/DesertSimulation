using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalUIDemo
{
    class Triangle : Shape
    {
        // Properties
        //Properities
        public Point[] trianglePoints = new Point[3];
        public int rotateAngle = 0;
        public int angleStep = 30;

        //Constructors
        //Call base constructor (Shape constructor)
        public Triangle(int width, SolidBrush color, Vector2 location)
            : base(location, width, width, color)
        {

        }
        // Methods
        override public void draw(Graphics canvas)
        {
            canvas.FillPolygon(color, trianglePoints);
            rotate();
        }

        public void rotate()
        {
            //Rotate the triangle an angle of rotateAngle
            Vector2 center = new Vector2(location.X + width / 2, location.Y + width / 2);
            //Rotate clockwise around the circumcircle center(xc,yc) point
            rotateAngle += angleStep;
            trianglePoints[0].X = (int)(center.X + width * Math.Cos(toRadians(rotateAngle)));
            trianglePoints[0].Y = (int)(center.Y - width * Math.Sin(toRadians(rotateAngle)));

            trianglePoints[1].X = (int)(center.X + width * Math.Cos(toRadians(rotateAngle - 90)));
            trianglePoints[1].Y = (int)(center.Y - width * Math.Sin(toRadians(rotateAngle - 90)));

            trianglePoints[2].X = (int)(center.X + width * Math.Cos(toRadians(rotateAngle + 90)));
            trianglePoints[2].Y = (int)(center.Y - width * Math.Sin(toRadians(rotateAngle + 90)));

            if (rotateAngle > 360)
            {
                rotateAngle = rotateAngle % 360;
            }
        }

        public double toRadians(double angle)
        {
            return Math.PI / 180 * angle;
        }


    }
}
