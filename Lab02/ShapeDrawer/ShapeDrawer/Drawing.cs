using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class Drawing
    {
        //variables
        private readonly List<Shape> _shapes;
        private Color _background;

        //properties

        //number of shapes in list, readonly
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        // background color
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

        //list of shapes that are currently selected 
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();

                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                    {
                        result.Add(s);
                    }
                }

                return result;
            }
        }

        //constructer that accepts color as a parameter for the background
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        //default constructor 
        public Drawing() : this (Color.White)
        {
            
        }

        //methods 
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen();
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            // checks if mouse position is over a shape, if true then its selected property is set to true
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                } else
                {
                    s.Selected = false;
                }
            }
        }

        public void DeleteShape()
        {
            // new variable initiated since list cannot be modified while being enumerated 
            Shape deletedShape = new Shape(0, 0);
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    deletedShape = s;
                }
            }
            _shapes.Remove(deletedShape);
        }
    }
}
