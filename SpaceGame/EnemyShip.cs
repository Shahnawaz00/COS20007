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
        private Random _random;
        public EnemyShip(float x, float y, float speed, Bitmap shipBitmap,Bitmap bulletBitmap, Window window)
            : base(x, y, speed, shipBitmap, bulletBitmap, window)
        {
            _random = new Random();
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
