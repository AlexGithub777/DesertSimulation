using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;


namespace ItemFactory
{
    public partial class Form1 : Form
    {
        // Declare global variables
        Framework framework = new Framework();

        //Locations of object generators
        public Vector2 ballGenerator = new Vector2(120, 0);         
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
            
            //Draw blocks           
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), ballGenerator.X, ballGenerator.Y, 60, 10);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), rectangleGenerator.X, rectangleGenerator.Y, 60, 10);

           
            foreach (Shape item in framework.itemList)
            {
                item.move();

                // Draw an aqua square around the rectangle if it's frozen
                if (item.IsFrozen)
                {
                    item.drawFreeze(e.Graphics, item);
                }

                item.draw(e.Graphics);
            }
                 
            // Draw the freezer
            framework.freezer.draw(e.Graphics);
            // Draw the crusher
            framework.crusher.draw(e.Graphics);
        }

        private void addBallBtn_Click(object sender, EventArgs e)
        {
            // Create a new ball and add it to the canvas
            Random rand = new Random();
            int width = rand.Next(25) + 10; // between 10 - 35
            Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Ball newBall = new Ball(new System.Numerics.Vector2(ballGenerator.X, ballGenerator.Y), width, width, new SolidBrush(color));

            //Make this ball move downward
            newBall.velocity.X = 0;
            newBall.velocity.Y = 5;

            framework.addItem(newBall);
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
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load event - when the GUI is loaded
            // Create a timer
            Timer timer = new Timer();
            timer.Interval = 50; // 50ms
            timer.Tick += timer_Tick;
            timer.Enabled = true;

        }          
        private void timer_Tick(object sender, EventArgs e)
        {
            // Update canvas
            canvas.Invalidate();
        }        
    }
}
