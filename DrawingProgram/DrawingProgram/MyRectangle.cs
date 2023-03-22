using DrawingProgram.lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    //this class requires common references to have their namespaces explicitly mentioned 
    // such as Color, Rectangle(not entirely sure why). not sure why other classes do not give the same error
    public class MyRectangle : Shape
    {
        //local variables
        private int _width;
        private int _height;

        //properties
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        // constructor (not sure yet why this accepts x y coordinates but other shapes dont, but its not being utilised for now)
        public MyRectangle(lib.Color clr,float x, float y, int width, int height) : base( clr)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }
        //default constructor
        public MyRectangle() : this(lib.Color.Green, 0, 0, 100, 100) { }

        //methods
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(lib.Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            //removed previous logic of checking mouse position
            //create new rectangle shape because it does not accept raw values on the parameter. will look for better alternatives
            lib.Rectangle rectangle = new lib.Rectangle()
            {
                X = X,
                Y = Y,
                Width = _width,
                Height = _height
            };
            return SplashKit.PointInRectangle(pt, rectangle);
        }
    }
}
