
using SplashKitSDK;

namespace Shape_Drawer
{
    public class Program
    {
        public static void Main()
        {
            // Create a window named "Shape Drawer" with a size of 800x600
            Window shapeDrawerWindow = new Window("Shape Drawer", 800, 600);
            // Create a new Drawing object to hold the shapes
            Drawing drawingObject = new Drawing();

            // Enter a loop that handles user input
            do
            {
                // Process events related to user input
                SplashKit.ProcessEvents();

                // Clear the screen to prepare for drawing shapes
                SplashKit.ClearScreen();

                // If the user clicks the left mouse button
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Create a new Shape object at the position of the mouse click
                    Shape myShape = new Shape();
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();

                    // Add the new shape to the drawing object
                    drawingObject.AddShape(myShape);
                }

                // If the user clicks the right mouse button
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    // Select the shape(s) at the position of the mouse click
                    Point2D mousePosition = SplashKit.MousePosition();
                    drawingObject.SelectShapesAt(mousePosition);
                }

                // If the user presses the spacebar
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // Change the color of the selected shape(s)
                    drawingObject.RandomColor();
                }

                // If the user presses the backspace key
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    // Delete the selected shape(s)
                    foreach (Shape selectedShape in drawingObject.SelectedShapes)
                    {
                        drawingObject.DeleteShape(selectedShape);
                    }
                }

                // Draw all shapes in the drawing object
                drawingObject.Draw();

                // Refresh the screen to display changes
                SplashKit.RefreshScreen();

                // Continue the loop until the user closes the window
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
