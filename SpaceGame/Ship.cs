using SplashKitSDK;
using System.Collections.Generic;

namespace SpaceGame
{
    public abstract class Ship : IsCollidable
    {
        protected float _x;
        protected float _y;
        protected float _speed;
        protected float _bulletSpeed;
        protected Bitmap _shipBitmap;
        protected Bitmap _bulletBitmap;
        protected Window _window;

        public Ship(float x, float y, float speed, Bitmap shipBitmap, Bitmap bulletBitmap, Window window)
        {
            _x = x;
            _y = y;
            _speed = speed;
            _bulletSpeed = 0.7f;
            _shipBitmap = shipBitmap;
            _bulletBitmap = bulletBitmap;
            _window = window;
        }

        public virtual void Draw()
        {
            SplashKit.DrawBitmapOnWindow(_window, _shipBitmap, _x, _y);
        }

        public bool IsCollidingWith(IsCollidable o)
        {
            return SplashKit.BitmapCollision(_shipBitmap, _x, _y, o.Bitmap, o.X, o.Y);
        }

        public abstract Bullet FireBullet();

        public float X 
        {
            get { return _x; }
        }
        public float Y
        { 
            get { return _y; } 
        }
        public Bitmap Bitmap { get { return _shipBitmap; } }
    }
}