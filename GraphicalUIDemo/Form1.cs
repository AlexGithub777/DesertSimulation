using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace GraphicalUIDemo
{
    public partial class Form1 : Form
    {
        // Declare global variables
        Framework framework = new Framework();

        //Locations of object generators
        public Vector2 ballGenerator = new Vector2(0, 50);
        public Vector2 spriteGenerator = new Vector2(0, 150);
        public Vector2 starGenerator = new Vector2(100, 0);
        public Vector2 rectangleGenerator = new Vector2(200, 0);

        public Form1()
        {
            InitializeComponent();
            // Set the boundaryW and boundaryH
            Shape.boundaryW = canvas.Width;
            Shape.boundaryH = canvas.Height;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Check all collisions possible between 2 balls
            framework.checkCollisionBallAndBall();

            //Check collision
            framework.checkAllCollision();

            //Draw the runningBelt1 object on canvas
            framework.runningBelt1.draw(e.Graphics);

            //Draw the runningBelt2 object on canvas
            framework.runningBelt2.draw(e.Graphics);

            // Draw the windmill object
            //framework.windmill.draw(e.Graphics);
            

            //Draw blocks
            

            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), ballGenerator.X, ballGenerator.Y, 10, 60);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), spriteGenerator.X, spriteGenerator.Y, 10, 60);
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), starGenerator.X, starGenerator.Y, 60, 10);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), rectangleGenerator.X, rectangleGenerator.Y, 60, 10);


            // Draw new ball here if not 
            foreach (Ball ball in framework.listOfBall)
            {
                ball.move();
                ball.draw(e.Graphics);
            }

            foreach (Sprite sprite in framework.listOfSprite)
            {
                sprite.move();
                sprite.draw(e.Graphics);
            }

            foreach (Rectangle rectangle in framework.listOfRectangle)
            {
                rectangle.move();

                // Draw an aqua square around the rectangle if it's frozen
                if (rectangle.IsFrozen)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Aqua),
                        rectangle.location.X - 5, rectangle.location.Y - 5,
                        rectangle.width + 10, rectangle.height + 10);
                }

                rectangle.draw(e.Graphics);
            }

            foreach (Triangle triangle in framework.listOfTriangle)
            {
                triangle.move();
                triangle.draw(e.Graphics);
            }

            foreach (Star star in framework.listOfStar)
            {
                star.move();
                star.draw(e.Graphics);
            }

            framework.freezer.draw(e.Graphics);
            // Draw the crusher
            framework.crusher.draw(e.Graphics);

            //framework.horizontalCrusher.draw(e.Graphics);


        }

        private void addBallBtn_Click(object sender, EventArgs e)
        {
            // Create a new ball and add it to the canvas
            Random rand = new Random();
            int width = rand.Next(50) + 10; // between 10 - 60
            Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Ball newBall = new Ball(new System.Numerics.Vector2(ballGenerator.X, ballGenerator.Y), width, width, new SolidBrush(color));

            framework.addItem(newBall);
        }

        private void addSpriteBtn_Click(object sender, EventArgs e)
        {
            Image[] frames = new Image[] {Properties.Resources.flyingdragon_frame1,
                                          Properties.Resources.flyingdragon_frame2,
                                          Properties.Resources.flyingdragon_frame3,
                Properties.Resources.flyingdragon_frame4};
            Sprite newSprite = new Sprite(80, 60, frames,
                                      new Vector2(spriteGenerator.X, spriteGenerator.Y), new SolidBrush(Color.AliceBlue));

            //add this new object to the list
            framework.listOfSprite.Add(newSprite);
        }

        private void addRectangleBtn_Click(object sender, EventArgs e)
        {
            // Create a new rectangle and add it to the canvas
            Random rand = new Random();
            int width = rand.Next(25) + 10; // between 10 - 35
            int height = rand.Next(25) + 10; // between 10 - 35
            Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Rectangle newRectangle = new Rectangle(new System.Numerics.Vector2(rectangleGenerator.X, rectangleGenerator.Y), width, height, new SolidBrush(color));

            //Make this rectangle move downward
            newRectangle.velocity.X = 0;
            newRectangle.velocity.Y = 5;

            framework.addItem(newRectangle);
        }

        private void addTriangleBtn_Click(object sender, EventArgs e)
        {
            //Create a randomly-sized anbd colored triangle 
            Random rand = new Random();
            int width = rand.Next(50) + 10; // between 10 - 60
            Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            Triangle newTriangle = new Triangle(width, new SolidBrush(color), new Vector2(starGenerator.X, starGenerator.Y));

            //add this new triangle to the listOfTriangles
            framework.listOfTriangle.Add(newTriangle);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load event - when the GUI is loaded
            // Create a timer
            Timer timer = new Timer();
            timer.Interval = 50; // 50ms
            timer.Tick += timer_Tick;
            timer.Enabled = true;

        }
            /*Timer crusherTimer = new Timer();
            crusherTimer.Interval = 2000; // 2000ms
            crusherTimer.Tick += crusherTimer_Tick;
            crusherTimer.Enabled = true;
        }

        private void crusherTimer_Tick(object sender, EventArgs e)
        {
            // Toggle the crusher state
            framework.crusher.ToggleCrusher();
        }
        */

        private void timer_Tick(object sender, EventArgs e)
        {
            // Update canvas
            canvas.Invalidate();
        }

        private void addStar_Click(object sender, EventArgs e)
        {
            // Create a new star and add it to the canvas
        Random rand = new Random();
        int width = rand.Next(50) + 10; // between 10 - 60
        Star newStar = new Star(width, width, starGenerator, new SolidBrush(Color.AliceBlue));
        framework.addItem(newStar);
        }
    }

}
