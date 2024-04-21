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

namespace ItemFactory
{
    internal class Framework
    {
        //Properties
        public List<Shape> itemList = new List<Shape>();
        public List<Rectangle> listOfRectangle = new List<Rectangle>();
        public List<Ball> listOfBall = new List<Ball>();
        public Freezer freezer;
        public Sprite runningBelt1;
        public Sprite runningBelt2; // New running belt
        public Crusher crusher;
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
            freezer = new Freezer();


            // Init windmill object
            //Image[] windmillFrames = new Image[] { Properties.Resources.windmill1, Properties.Resources.windmill2, Properties.Resources.windmill3, Properties.Resources.windmill4 };

            //windmill = new Sprite(80, 80, windmillFrames, new Vector2(300, 110), new SolidBrush(Color.Beige)); 
            // Create the crusher object
            crusher = new Crusher(new Vector2(200, 100), 60, 100, new SolidBrush(Color.Gray));

  
        }

        // Methods: Static Polymorphysm technique
        public void addItem(Ball newBall)
        {
            listOfBall.Add(newBall);
            //Add item to the list
            itemList.Add(newBall);
        }
            
        public void addItem(Rectangle newRectangle)
        {
            listOfRectangle.Add(newRectangle);

            itemList.Add(newRectangle);
        }
       
        public bool checkCollision(Shape obj1, Sprite obj2)
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

        public bool checkFreezerCollision(Shape shape1, Shape shape2)
        {
            // Calculate the overlapping area
            int overlapX = (int)Math.Max(0, Math.Min(shape1.location.X + shape1.height, shape2.location.X + shape2.width) - Math.Max(shape1.location.X, shape2.location.X));
            int overlapY = (int)Math.Max(0, Math.Min(shape1.location.Y + shape1.height, shape2.location.Y + shape2.height) - Math.Max(shape1.location.Y, shape2.location.Y));

            int overlapArea = overlapX * overlapY;

            // Calculate the first shape's total area
            int totalArea = shape1.width * shape1.height;

            // Check if more than half of the first shape's area is within the second shape
            if (overlapArea > totalArea / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkCrusherCollision(Shape obj1, Shape obj2)
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
                        // add logic
                    }

                }
            }
        }

        // Iterates through each item in the list and checks for collisions with various objects.
        // If a collision is detected, it updates the item's velocity or state accordingly.
        // If a item reaches the bottom line, it is removed from the list.
        public void checkAllCollision()
        {
            for (int i = itemList.Count - 1; i >= 0; i--)
            {
                Shape item = itemList[i];

                // Check collision with running belt1
                if (checkCollision(item, runningBelt1))
                {
                    // Change the velocity of the rectangle to make it move to the right
                    item.velocity.Y = 0;
                    item.velocity.X = 4;
                }

                // Check collision with freezer
                else if (checkFreezerCollision(item, freezer))
                {
                    // Mark the rectangle as frozen
                    freezer.Freeze(item);
                }

                // Check collision with running belt2
                else if (checkCollision(item, runningBelt2))
                {
                    // Change the velocity of the rectangle to make it move to the left
                    item.velocity.Y = 0;
                    item.velocity.X = -4;

                    // If the crusher is closed, check for collision with the crush zone and unfreeze the rectangle
                    if (!crusher.isOpen)
                    {
                        if (checkCrusherCollision(item, crusher.crushZone))
                        {
                            item.IsFrozen = false;
                        }
                    }
                }

                else
                {
                    // Check if the item touches the bottom line or not? If not, move downward. If yes, remove it
                    if (item.location.Y + item.height > Shape.boundaryH)
                    {
                        // Remove item
                        itemList.Remove(item);
                    }
                    else
                    {
                        // Change the velocity of item to make it move downward
                        item.velocity.X = 0;
                        item.velocity.Y = 5;
                    }
                }
            }
        }
    }
}
