using SplashKitSDK;
using System.Collections.Generic;

namespace SpaceGame
{
    public abstract class Ship : IsCollidable
    {
        //protected to allow subclasses to access 
        protected float _x;
        protected float _y;
        protected float _speed;
        protected float _bulletSpeed;  //for future use 
        protected Bitmap _shipBitmap;
        protected Bitmap _bulletBitmap;
        protected Window _window;

        public Ship(float x, float y, float speed, Bitmap bulletBitmap, Window window)
        {
            _x = x;
            _y = y;
            _speed = speed;
            _bulletSpeed = 0.7f;
            _bulletBitmap = bulletBitmap;
            _window = window;
        }

        //draw ship
        public void Draw()
        {
            SplashKit.DrawBitmapOnWindow(_window, _shipBitmap, _x, _y);
        }

        //return true if it has collided with a bitmap
        public bool IsCollidingWith(IsCollidable o)
        {
            return SplashKit.BitmapCollision(_shipBitmap, _x, _y, o.Bitmap, o.X, o.Y);
        }
        //factory method for bullet creation
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