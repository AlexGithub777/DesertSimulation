using ItemFactory;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using Rectangle = ItemFactory.Rectangle;

internal class Crusher : Shape
{
    public Rectangle crushZone;
    public bool isOpen = true; // Track whether the crusher is open or closed
    private Timer crusherTimer;

    public Crusher(Vector2 location, int width, int height, SolidBrush color)
        : base(location, width, height, color) 
    {
        // Initialize the crush zone
        crushZone = new Rectangle(new Vector2(200, 258), 60, 100, color);

        // Initialize the crusher timer
        crusherTimer = new Timer();
        crusherTimer.Interval = 1500; // 1500 = 1.5 seconds
        crusherTimer.Tick += CrusherTimer_Tick;
        crusherTimer.Enabled = true;
    }

    private void CrusherTimer_Tick(object sender, EventArgs e)
    {
        // Toggle the crusher state
        ToggleCrusher();
    }

    // Method to toggle the crusher state(open/close) and show closed crusher for 300ms
    public void ToggleCrusher()
    {
        // If the crusher is currently open, close it
        if (isOpen)
        {
            isOpen = false;

            // Start a timer to open the crusher after 200ms
            Timer openTimer = new Timer();
            openTimer.Interval = 200; // 200ms
            openTimer.Tick += (s, args) =>
            {
                // Open the crusher
                isOpen = true;
                openTimer.Stop();
                openTimer.Dispose();
            };
            openTimer.Start();
        }
        else // If the crusher is currently closed, open it immediately
        {
            isOpen = true;
        }
    }

    public override void draw(Graphics graphics)
    {
        // Draw the crusher based on its state
        if (isOpen)
        {
            // Draw the vertical part of the crusher
            int verticalWidth = width / 4;
            int verticalHeight = height / 2;
            int verticalX = (int)(location.X + (width / 3));
            int verticalY = (int)(location.Y + height / 2 - verticalHeight);
            graphics.FillRectangle(new SolidBrush(Color.Goldenrod), verticalX, verticalY, verticalWidth, verticalHeight);

            // Calculate the horizontal part width based on the desired length
            int horizontalWidth = width; // Adjusted width to make it thinner

            // Calculate the horizontal part position to center it with respect to the vertical part
            int horizontalX = verticalX - (horizontalWidth - verticalWidth) / 2;
            int horizontalY = (int)(location.Y + height / 2);

            // Draw the horizontal part of the crusher
            graphics.FillRectangle(color, horizontalX, horizontalY, horizontalWidth, height / 8);
        }
        else
        {
            // Draw closed crusher
            int verticalWidth = width / 4; //15
            int verticalHeight = height + 58  ; // Extend the vertical part to cover most of the height height = 100 = 158
            int verticalX = (int)(location.X + (width / 3)); //220
            int verticalY = (int)(location.Y); //100
            graphics.FillRectangle(new SolidBrush(Color.Green), verticalX, verticalY, verticalWidth, verticalHeight);

            // Draw the horizontal part of the crusher
            int horizontalWidth = width; // Adjusted width to make it thinner 60
            int horizontalHeight = height / 8; //12.5
            int horizontalX = verticalX + (verticalWidth - horizontalWidth) / 2; // Calculate the horizontal position // = 300
            int horizontalY = (int)(location.Y + height + 58); //258
            graphics.FillRectangle(color, horizontalX, horizontalY, horizontalWidth, horizontalHeight);
        }
    }
}
