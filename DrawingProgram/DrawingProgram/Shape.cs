using System;
using DrawingProgram.lib;

namespace DrawingProgram
{
    public abstract class Shape
    {
        // local variables 
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        // constructor
        public Shape(Color clr)
        {
            _color = clr;
        }
        //default constructor 
        public Shape() : this(Color.Yellow) 
        {
        }

        // properties 
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        // methods 
        public abstract void Draw();
        public abstract bool IsAt(Point2D pt);
        public abstract void DrawOutline();


    }

}