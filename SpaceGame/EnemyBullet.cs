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
        public EnemyBullet(float x, float y, float speed, Color color, Window window)
            : base(x, y, speed, color, window)
        {
            SplashKit.LoadBitmap("enemyBullet", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\laserGreen.bmp");

            _bitmap = SplashKit.BitmapNamed("enemyBullet");
        }

        public override void Update()
        {
            _y += _speed;
        }
    }
}
