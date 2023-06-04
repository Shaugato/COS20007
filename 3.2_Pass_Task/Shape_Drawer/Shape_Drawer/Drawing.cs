
using System.Collections.Generic;
using SplashKitSDK;

namespace Shape_Drawer
{
    public class Drawing
    {
        // List of shapes and background color for the Drawing
        private readonly List<Shape> _shapes;
        private Color _background;

        // Constructor that initializes the list of shapes and background color
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        // Default constructor that initializes the list of shapes with a white background
        public Drawing() : this(Color.White)
        {
        }

        // Clears the screen and draws all the shapes in the list
        public void Draw()
        {
            SplashKit.ClearScreen();
            foreach (Shape shape in _shapes)
            {
                // Draws the shape
                shape.Draw();
            }

        }

        // Adds a shape to the list of shapes
        public void AddShape(Shape shape)
        {
            // Adds the shape to the list of shapes
            _shapes.Add(shape);
        }

        // Removes a shape from the list of shapes and from the display
        public void DeleteShape(Shape s)
        {
            // Removes the shape from the list of shapes, causing it to disappear from the display
            _shapes.Remove(s);
        }

        // Selects shapes at the specified point
        public void SelectShapesAt(Point2D select_pt)
        {
            foreach (Shape s in _shapes)
            {
                // Selects the shape if it is at the specified point
                if (s.IsAt(select_pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        // Changes the color of the shape at the current mouse position
        public void RandomColor()
        {
            Point2D mousePosition = SplashKit.MousePosition();

            foreach (Shape shape in _shapes)
            {
                // Changes the color of the shape at the current mouse position to a random color
                if (shape.IsAt(mousePosition))
                {
                    shape.Color = SplashKit.RandomRGBColor(255);
                }
            }
        }

        // Getter and setter for the background color
        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        // Returns the number of shapes in the list
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        // Returns a list of all the selected shapes
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result;
                result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    // Adds the selected shape to the list of selected shapes
                    if (s.Selected == true)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }


    }

}
