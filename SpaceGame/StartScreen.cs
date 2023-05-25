using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class StartScreen
    {
        
        private Window _window;
        private bool _startClicked; // check if start button was clicked

        public StartScreen(Window window)
        {
            _window = window;
            _startClicked = false;
        }

        public bool StartClicked
        {
            get
            {
                return _startClicked;
            }
        }

        //draw start screen
        public void Draw()
        {
            // Draw the start screen graphics, including the start button and game instructions
            SplashKit.DrawText("Welcome to Space Shooter!", Color.White, "arial", 36, 200, 200);
            SplashKit.DrawText("Instructions:", Color.White, "arial", 24, 250, 300);
            SplashKit.DrawText("- Use arrow keys or WASD to move the ship", Color.White, "arial", 20, 250, 350);
            SplashKit.DrawText("- Press the Spacebar to shoot bullets", Color.White, "arial", 20, 250, 380);
            SplashKit.DrawText("Click the Start button to begin", Color.White, "arial", 24, 250, 450);
            SplashKit.DrawText("asset credits: www.kenney.nl", Color.White, "arial", 24, 250, 480);


            //make button
            Rectangle startButton = new Rectangle();
            startButton.X = 400;
            startButton.Y = 500;
            startButton.Width = 200;
            startButton.Height = 50;

            SplashKit.FillRectangle(Color.Green, startButton);
            SplashKit.DrawText("Start", Color.White, "arial", 24, 480, 520);

            // Check for mouse click event on the start button
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.PointInRectangle(SplashKit.MousePosition(), startButton))
            {
                _startClicked = true;
            }
        }
    }
}
