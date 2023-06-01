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
        private EnemyStrategy _enemyStrategy;

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

        public EnemyShip(float x, float y, float speed,Bitmap bulletBitmap, Window window, EnemyStrategy enemyStrategy)
            : base(x, y, speed, bulletBitmap, window)
        {
            _shipBitmap = _enemyShipBitmap;
            _enemyStrategy = enemyStrategy;
        }

        public void Update()
        {
            _enemyStrategy.Behaviour(ref _y,ref _speed);
           
        }

        public override EnemyBullet FireBullet()
        {
            float bulletX = _x + (_shipBitmap.Width / 2);
            float bulletY = _y;

            return new EnemyBullet(bulletX, bulletY, _bulletSpeed, Color.Red, _window);
        }

        //property to allow strategy to be changed at runtime 
        public EnemyStrategy Strategy
        {
            get 
            {
                return _enemyStrategy;
            }
            set 
            {
                _enemyStrategy = value;
            }
        }
       
    }




}
