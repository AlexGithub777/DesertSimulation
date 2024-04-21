using System;
using System.Drawing;
using System.Numerics;

namespace ItemFactory
{
    internal class Shape
    {
        // Delcare properties
        static public int boundaryW; //Use "Static" keyword to define shared info among objects
        static public int boundaryH; //Use "Static" keyword to define shared info among objects
        public Vector2 location;
        public int height;
        public int width;
        public SolidBrush color;
        public Vector2 velocity = new Vector2(0,0);

        public bool IsFrozen;

        // Constructors
        public Shape(Vector2 location, int width, int height, SolidBrush color)
        {
            this.location = location;
            this.height = height;
            this.width = width;
            this.color = color;
            Random rand = new Random();
            velocity = new Vector2(rand.Next(4) + 1, rand.Next(5));
            

        }

        // Methods
        public void drawFreeze(Graphics canvas, Shape shape)
        {
            canvas.FillRectangle(new SolidBrush(Color.Aqua),
                        shape.location.X - 5, shape.location.Y - 5,
                        shape.width + 10, shape.height + 10);
        }
        virtual public void draw(Graphics canvas)
        {

        }

        public void move() 
        {
            //Check if the ball reaches to any bound? If yes, the ball bounces off   
            //Detect the horizontal borders
            if (location.Y < 0)
            {
                Random rand = new Random();
                Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                this.color = new SolidBrush(color);
                //Top border
                velocity.Y = -velocity.Y;
                location.Y = 0;
            }
            else if (location.Y + height > boundaryH)
            {
                Random rand = new Random();
                Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                this.color = new SolidBrush(color);
                //Bottom border
                velocity.Y = -velocity.Y;
                location.Y = boundaryH - height;
            }

            //Detect the vertical borders
            if (location.X < 0)
            {
                Random rand = new Random();
                Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                this.color = new SolidBrush(color);
                //Left border
                velocity.X = -velocity.X;
                location.X = 0;
            }
            else if (location.X + width > boundaryW)
            {
                Random rand = new Random();
                Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                this.color = new SolidBrush(color);
                //Right border
                velocity.X = -velocity.X;
                location.X = boundaryW - width;
            }

            //Move the shape 
            location += velocity;

        }
    }
}
