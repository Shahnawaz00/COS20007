using DrawingProgram.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    public class MyLine : Shape
    {
        //local variables 
        // x2 y2 for end coordinates. start coordinate values are already inherited from Shape class 
        private float _x2;
        private float _y2;

        //properties
        public float X2
        {
            get
            {
                return _x2;
            }
            set 
            {
                _x2 = value; 
            }
        }
        public float Y2
        {
            get
            {
                return _y2;
            }
            set
            { 
                _y2 = value; 
            }
        }
        //constructor
        public MyLine(Color clr, float x2, float y2) : base(clr) 
        { 
            _x2 = x2;
            _y2 = y2;
        }
        // default constructor
        public MyLine() : this(Color.Red, 0, 0) {}

        // methods
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, X2, Y2);
        }
        public override void DrawOutline()
        {
            int radius = 2;
            SplashKit.FillCircle(Color.Black, X, Y, radius);
            SplashKit.FillCircle(Color.Black, X2, Y2, radius);
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, X2, Y2), 5);
        }
    }
}
