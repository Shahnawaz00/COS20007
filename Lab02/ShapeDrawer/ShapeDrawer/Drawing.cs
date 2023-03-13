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
        private readonly List<Shape> _shapes;
        private Color _background;

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
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

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this (Color.White)
        {
            
        }

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
            //Shape deletedShape;
            //foreach (Shape s in _shapes)
            //{
            //    if (s.Selected)
            //    {
            //        deletedShape = s;
            //    }
            //}
            //_shapes.Remove(deletedShape);

            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    _shapes.Remove(s);
                    break;
                }
            }

            //foreach (Shape s in _shapes.ToList())
            //{
            //    if (s.Selected)
            //    {
            //        _shapes.Remove(s);
            //        break;
            //    }
            //}
        }
    }
}
