using DrawingProgram.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    public class MyCircle : Shape
    {
        //local variables 
        private int _radius;

        //properties 
        public int Radius
        {
            get
            { 
                return _radius;
            } 
            set
            {
                _radius = value;
            }
        }
        //constructor 
        public MyCircle(Color clr, int radius) : base(clr) 
        {
            _radius = radius;
        }
        //default constructor 
        public MyCircle() : this(Color.Blue, 50) { }

        //methods
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            //checking mouse point with distance formula
            //if (Math.Sqrt(Math.Pow(pt.X - X, 2) +  Math.Pow(pt.Y - Y,2)) <= _radius )
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            // -----------------------------

            //new circle to pass it on PointInCircle method
            // because it has no overload methods that take in raw values
            Circle circle = new Circle() 
            { 
                Center = new Point2D() 
                {
                    X = X,
                    Y = Y 
                },
                Radius = _radius 
            };
            return SplashKit.PointInCircle(pt, circle); 

        }
    }
}
