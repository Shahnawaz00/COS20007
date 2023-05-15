using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class PlayerShip : Ship
    {
        private int _lives;
        private int _score;
        public PlayerShip(float x, float y, float speed, Bitmap shipBitmap, Bitmap bulletBitmap, Window window)
            : base(x, y, speed, shipBitmap, bulletBitmap, window)
        {
            _lives = 3;
            _score = 0;
        }

        public void Move(float deltaX, float deltaY)
        {
            _x += deltaX * _speed;
            _y += deltaY * _speed;
        }

        public void TakeDamage()
        {
            _lives--;
        }
        public void IncreaseScore()
        {
            _score += 10;
        }
        public override PlayerBullet FireBullet()
        {
            float bulletX = _x + (_shipBitmap.Width / 2);
            float bulletY = _y;

            return new PlayerBullet(bulletX, bulletY, _bulletSpeed, Color.Red, _window);
        }

        public void Reset()
        {
            _lives = 3;
            _score = 0;
            _x = 400;
            _y = 600;
        }

        public int Lives
        {
            get
            { 
                return _lives; 
            }
        }
        public int Score
        {
            get
            {
                return _score;
            }
        }

    }
}
