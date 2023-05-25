using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class PlayerBullet : Bullet
    {

        private static Bitmap _playerBulletBitmap;

        //static method to avoid bitmap reloading everytime a new instance of the class is created
        //should be fine since bullets should look one way depending on the type of bullet
        static PlayerBullet()
        {
            //load bullet image
            _playerBulletBitmap = SplashKit.BitmapNamed("playerBullet");
            if (_playerBulletBitmap == null)
            {
                _playerBulletBitmap = SplashKit.LoadBitmap("playerBullet", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\laserRed.bmp");
            }
        }

        public PlayerBullet (float x, float y, float speed, Color color, Window window) 
            : base (x,y, speed, color, window) 
        {

            _bitmap = _playerBulletBitmap;
        }

        //move bullet up
        public override void Update()
        {
            _y -= _speed;
        }
    }
}
