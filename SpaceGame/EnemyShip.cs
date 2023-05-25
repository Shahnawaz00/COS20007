using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class EnemyShip : Ship
    {
        private static Bitmap _enemyShipBitmap;

        //static method to avoid bitmap reloading everytime a new instance of the class is created
        //will have to change if planning to change enemy ship based on difficulty 
        static EnemyShip()
        {
            //load bullet image
            _enemyShipBitmap = SplashKit.BitmapNamed("enemyShip");
            if (_enemyShipBitmap == null)
            {
                _enemyShipBitmap = SplashKit.LoadBitmap("enemyShip", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\enemyShip.bmp");
            }
        }

        public EnemyShip(float x, float y, float speed,Bitmap bulletBitmap, Window window)
            : base(x, y, speed, bulletBitmap, window)
        {
            _shipBitmap = _enemyShipBitmap;
        }


        public void Update()
        {
            _y += _speed;

           
        }

        public override EnemyBullet FireBullet()
        {
            float bulletX = _x + (_shipBitmap.Width / 2);
            float bulletY = _y;

            return new EnemyBullet(bulletX, bulletY, _bulletSpeed, Color.Red, _window);
        }

       
    }



}
