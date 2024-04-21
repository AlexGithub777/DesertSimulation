using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Image = System.Drawing.Image;

namespace GraphicalUIDemo
{
    internal class Framework
    {
        //Properties
        public List<Ball> listOfBall = new List<Ball>();
        public List<Rectangle> listOfRectangle = new List<Rectangle>();
        public List<Triangle> listOfTriangle = new List<Triangle>();//
        public List<Sprite> listOfSprite = new List<Sprite>();//
        public List<Star> listOfStar = new List<Star>();

        

        public Rectangle freezer;
        public Sprite runningBelt1;
        public Sprite runningBelt2; // New running belt
        public Crusher crusher;
        public Rectangle crushZone;
        // Get the horizontal part of the crusher
        
        //public Sprite windmill;


        // Constructor
        public Framework()
        {


            // Init running belt object
            Image[] beltFrames = new Image[] { Properties.Resources.belt1, Properties.Resources.belt2, Properties.Resources.belt3, Properties.Resources.belt4 };
            runningBelt1 = new Sprite(250, 20, beltFrames, new Vector2(120, 80), new SolidBrush(Color.Beige));


            // Flip the belt frames for the second running belt
            Image[] secondBeltFrames = new Image[]
            {
            Properties.Resources.belt1.Clone() as Image,
            Properties.Resources.belt2.Clone() as Image,
            Properties.Resources.belt3.Clone() as Image,
            Properties.Resources.belt4.Clone() as Image
            };

            foreach (var frame in secondBeltFrames)
            {
                frame.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            runningBelt2 = new Sprite(250, 20, secondBeltFrames, new Vector2(185, 270), new SolidBrush(Color.Beige)); // Adjust position as needed

            //init freezer

            freezer = new Rectangle(new Vector2(373, 100), 40, 40, new SolidBrush(Color.Aqua));
            // Init windmill object
            //Image[] windmillFrames = new Image[] { Properties.Resources.windmill1, Properties.Resources.windmill2, Properties.Resources.windmill3, Properties.Resources.windmill4 };

            //windmill = new Sprite(80, 80, windmillFrames, new Vector2(300, 110), new SolidBrush(Color.Beige)); 
            // Create the crusher object
            crusher = new Crusher(new Vector2(200, 100), 60, 100, new SolidBrush(Color.Gray));

            // Get the horizontal part of the crusher
            crushZone = crusher.crushZone;

            
        }

        // Methods: Static Polymorphysm technique
        public void addItem(Ball newBall)
        {
            //Add item to the list
            listOfBall.Add(newBall);
        }
            
        public void addItem(Sprite newSprite)
        {
            listOfSprite.Add(newSprite);
        }

        public void addItem(Rectangle newRectangle)
        {
            listOfRectangle.Add(newRectangle);
        }

        public void addItem(Triangle newTriangle)
        { 
            listOfTriangle.Add(newTriangle);
        }

        public void addItem(Star newStar) 
        { 
            listOfStar.Add(newStar); 
        }

        // Calculate the distance between the obj1's center and obj2's center
        public bool checkCollision(Ball obj1, Sprite obj2)
        {
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.location.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.location.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.location.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.location.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= obj1.width/2 + obj2.width/2 && centralDistanceY <= (obj1.height/2 + obj2.height/2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkCollision(Rectangle obj1, Sprite obj2)
        {
            
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.location.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.location.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.location.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.location.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= obj1.width / 2 + obj2.width / 2 && centralDistanceY <= (obj1.height / 2 + obj2.height / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkCollision(Ball obj1, Ball obj2)
        {

            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.location.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.location.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.location.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.location.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= obj1.width / 2 + obj2.width / 2 && centralDistanceY <= (obj1.height / 2 + obj2.height / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkFreezerCollision(Rectangle obj1, Rectangle obj2)
        {
            // Calculate the overlapping area
            int overlapX = (int)Math.Max(0, Math.Min(obj1.location.X + obj1.width, obj2.location.X + obj2.width) - Math.Max(obj1.location.X, obj2.location.X));
            int overlapY = (int)Math.Max(0, Math.Min(obj1.location.Y + obj1.height, obj2.location.Y + obj2.height) - Math.Max(obj1.location.Y, obj2.location.Y));

            int overlapArea = overlapX * overlapY;

            // Calculate rectangle's total area
            int totalArea = obj1.width * obj1.height;

            // Check if more than half of the rectangle's area is within the freezer
            if (overlapArea > totalArea / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkCrusherCollision(Rectangle obj1, Rectangle obj2)
        {
            
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.location.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.location.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.location.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.location.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= obj1.width / 2 + obj2.width / 2 && centralDistanceY <= (obj1.height / 2 + obj2.height / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void checkCollisionBallAndBall()
        {
            for (int i = 0; i < listOfBall.Count; i++)
            {
                for (int j = i + 1; j < listOfBall.Count; j++)
                {
                    if (checkCollision(listOfBall[i], listOfBall[j]))
                    {
                        // Change the velocity of 2 balls to 0
                        listOfBall[i].velocity = new System.Numerics.Vector2(0, 0);
                        listOfBall[j].velocity = new System.Numerics.Vector2(0, 0);
                        // Change color of 2 balls to black
                        listOfBall[i].color = new SolidBrush(Color.Black);
                        listOfBall[j].color = new SolidBrush(Color.Black);
                    }

                }
            }
        }

        // Iterates through each rectangle in the list and checks for collisions with various objects.
        // If a collision is detected, it updates the rectangle's velocity or state accordingly.
        // If a rectangle reaches the bottom line, it is removed from the list.
        public void checkAllCollision()
        {
            for (int i = listOfRectangle.Count - 1; i >= 0; i--)
            {
                Rectangle rectangle = listOfRectangle[i];

                // Check collision with running belt1
                if (checkCollision(rectangle, runningBelt1))
                {
                    // Change the velocity of the rectangle to make it move to the right
                    rectangle.velocity.Y = 0;
                    rectangle.velocity.X = 4;
                }
                // Check collision with running belt2
                else if (checkCollision(rectangle, runningBelt2))
                {
                    // Change the velocity of the rectangle to make it move to the left
                    rectangle.velocity.Y = 0;
                    rectangle.velocity.X = -4;

                    // If the crusher is closed, check for collision with the crush zone and unfreeze the rectangle
                    if (!crusher.isOpen)
                    {
                        if (checkCrusherCollision(rectangle, crushZone))
                        {
                            rectangle.IsFrozen = false;
                        }
                    }
                }

                // Check collision with freezer
                else if (checkFreezerCollision(rectangle, freezer))
                {
                    // Mark the rectangle as frozen
                    rectangle.IsFrozen = true;
                }
                else
                {
                    // Check if the rectangle touches the bottom line or not? If not, move downward. If yes, remove it
                    if (rectangle.location.Y + rectangle.height > Shape.boundaryH)
                    {
                        // Remove rectangle
                        listOfRectangle.Remove(rectangle);
                    }
                    else
                    {
                        // Change the velocity of rectangle to make it move downward
                        rectangle.velocity.X = 0;
                        rectangle.velocity.Y = 5;
                    }
                }
            }
        }
    }
}
