using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class GameOverScreen
    {
        private Window _window;
        private bool _restartClicked;
        private int _score;

        public GameOverScreen(Window window, int score)
        {
            _window = window;
            _restartClicked = false;
            _score = score;
        }

        public bool RestartClicked 
        {
            get
            {
                return _restartClicked;
            }
        }
        public int Score
        {
            get
            {
                return _score;
            }
            set { _score = value; }
        }

        public void Draw()
        {
            // Draw the game over screen graphics, including the score and restart option
            SplashKit.DrawText("Game Over!", Color.White, "arial", 36, 350, 250);
            SplashKit.DrawText($"Score: {_score}", Color.White, "arial", 24, 400, 300);
            SplashKit.DrawText("Click Restart to play again", Color.White, "arial", 24, 350, 350);

            //make button
            Rectangle restartButton = new Rectangle();
            restartButton.X = 400;
            restartButton.Y = 450;
            restartButton.Width = 200;
            restartButton.Height = 50;

            Console.WriteLine(_score);

            SplashKit.FillRectangle(Color.Green, restartButton);
            SplashKit.DrawText("Restart", Color.White, "arial", 24, 425, 465);

            //Check for mouse click event on the restart button
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.PointInRectangle(SplashKit.MousePosition(), restartButton))
            {
                _restartClicked = true;
            }
        }

        //reset if player starts again
        public void Reset()
        {
            _restartClicked = false;
            _score = 0;
        }
    }
}
