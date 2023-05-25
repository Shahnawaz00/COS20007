using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class EnemyBullet : Bullet
    {
        private static Bitmap _enemyBulletBitmap;
        //static method to avoid bitmap reloading everytime a new instance of the class is created
        //should be fine since bullets should look one way depending on the type of bullet
        static EnemyBullet()
        {
            _enemyBulletBitmap = SplashKit.BitmapNamed("enemyBullet");
            if (_enemyBulletBitmap == null)
            {
                _enemyBulletBitmap = SplashKit.LoadBitmap("enemyBullet", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\laserGreen.bmp");
            }
        }
        public EnemyBullet(float x, float y, float speed, Color color, Window window)
            : base(x, y, speed, color, window)
        {

            _bitmap = _enemyBulletBitmap;
        }

        //move bullet down
        public override void Update()
        {
            _y += _speed;
        }
    }
}
