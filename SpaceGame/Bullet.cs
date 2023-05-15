using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public abstract class Bullet : IsCollidable
    {
        protected float _x;
        protected float _y;
        protected float _speed;
        protected Color _color;
        protected Window _window;
        protected Bitmap? _bitmap;

        public Bullet(float x, float y, float speed, Color color, Window window)
        {
            _x = x;
            _y = y;
            _speed = speed;
            _color = color;
            _window = window;
        }

        public void Draw()
        {
            SplashKit.DrawBitmapOnWindow(_window, _bitmap, _x, _y);
        }
        public abstract void Update();

        public bool IsCollidingWith(IsCollidable o)
        {
            return false;
        }

        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public Bitmap Bitmap { get { return _bitmap; } }
    }

}
