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
        public PlayerBullet (float x, float y, float speed, Color color, Window window) 
            : base (x,y, speed, color, window) 
        {
            SplashKit.LoadBitmap("playerBullet", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\laserRed.bmp");

            _bitmap = SplashKit.BitmapNamed("playerBullet");
        }

        public override void Update()
        {
            _y -= _speed;
        }
    }
}
