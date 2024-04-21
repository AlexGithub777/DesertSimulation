
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace ItemFactory
{
    class Sprite : Shape
    {
        //Properities
        public Image[] frames = new Image[4];
        public int frameIndex = 0;

        //Constructors
        public Sprite(int width, int height, Image[] frames, Vector2 location, SolidBrush color) :
               base(location,width, height, color)
        {
            this.frames = frames;
        }

        //draw
        //Override the draw() method in parent class
        override public void draw(Graphics canvas)
        {
            //canvas.DrawImage(image, topLeft.X, topLeft.Y, width, height);
            canvas.DrawImage(frames[frameIndex], location.X, location.Y, width, height);
            if (frameIndex ==  frames.Count() - 1)
            {
                frameIndex = 0;
            }
            else
            {
                frameIndex++;
            }
        }
    }
}
