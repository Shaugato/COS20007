using System;

using SplashKitSDK;
namespace ShapeDrawer_2022
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            // Create a new shape with default values
            Shape myShape = new Shape();

            do
            {
                // Handle events
                SplashKit.ProcessEvents();

                // Clear screen
                SplashKit.ClearScreen(Color.White);

                // Draw the shape
                myShape.Draw();

                // Check for mouse and keyboard input
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Set the shape's position to the mouse's position
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }
                if (myShape.IsAt(SplashKit.PointAt(SplashKit.MouseX(), SplashKit.MouseY())) && SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // Change the shape's color to a random color
                    myShape.Color = SplashKit.RandomRGBColor(255);
                }


                // Refresh the screen
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
