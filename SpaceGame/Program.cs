using SplashKitSDK;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = SplashKitSDK.Timer;
using static System.Formats.Asn1.AsnWriter;

namespace SpaceGame
{
    public class Program
    {
        public static void HandleInput(PlayerShip playerShip, List<PlayerBullet> bullets)
        {
            // Get the window dimensions
            int windowWidth = SplashKit.ScreenWidth();
            int windowHeight = SplashKit.ScreenHeight();

            // Left and right movement
            if (SplashKit.KeyDown(KeyCode.RightKey) || SplashKit.KeyDown(KeyCode.DKey))
            {
                if (playerShip.X + playerShip.Bitmap.Width <= windowWidth  )
                {
                    playerShip.Move(1, 0);  // Move ship to the right
                }
            }
            else if (SplashKit.KeyDown(KeyCode.LeftKey) || SplashKit.KeyDown(KeyCode.AKey))
            {
                if (playerShip.X >= 0)
                {
                    playerShip.Move(-1, 0);  // Move ship to the left
                }
            }

            // Up and down movement
            if (SplashKit.KeyDown(KeyCode.UpKey) || SplashKit.KeyDown(KeyCode.WKey))
            {
                if (playerShip.Y >= 0)
                {
                    playerShip.Move(0, -1); // Move ship up
                }
            }
            else if (SplashKit.KeyDown(KeyCode.DownKey) || SplashKit.KeyDown(KeyCode.SKey))
            {
                if (playerShip.Y + playerShip.Bitmap.Width <= windowHeight )
                {
                    playerShip.Move(0, 1); // Move ship down
                }
            }

            // Shoot bullets
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                PlayerBullet bullet = playerShip.FireBullet();
                bullets.Add(bullet);
            }
        }


        public static void Main()
        {

            Window window = new Window("Space Shooter", 1000, 700);


            // start and game over screens
            bool gameStarted = false;
            bool gameOver = false;

            StartScreen startScreen = new StartScreen(window);
            GameOverScreen gameOverScreen = new GameOverScreen(window, 0);


            //load background
            SplashKit.LoadBitmap("background", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\starBackground.bmp");

            //load background
            SplashKit.LoadMusic("background", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\backgroundMusic.ogg");
            SplashKit.PlayMusic(SplashKit.MusicNamed("background"));

            //player ship and bullets
            PlayerShip playerShip = new PlayerShip(400, 600, 0.1f, SplashKit.BitmapNamed("playerBullet"), window);
            List<PlayerBullet> playerBullets = new List<PlayerBullet>();

            //ememy ship and bullets
            List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
            List<EnemyShip> enemyShips = new List<EnemyShip>();
 
            //enemy ships spawn timer
            Timer enemySpawnTimer = new Timer("enemySpawn");
            SplashKit.StartTimer(enemySpawnTimer);

            //enemy ships bullet timer 
            Timer enemyBulletTimer = new Timer("enemyBullet");
            SplashKit.StartTimer(enemyBulletTimer);

            // variable for random numbers
            Random random = new Random();

            // draw gui 


            //event loop starts here 
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                SplashKit.DrawBitmapOnWindow(window, SplashKit.BitmapNamed("background"), 0, 0);

                //start game if start button is clicked
                if (!gameStarted)
                {
                    //draw start screen
                    startScreen.Draw();

                    if (startScreen.StartClicked)
                    {
                        gameStarted = true;
                    }
                  // check if game is over, if not then load game
                } else if (!gameOver) {

                    //main game logic
                    HandleInput(playerShip, playerBullets);
                    //draw gui
                    playerShip.Draw();
                    SplashKit.DrawText($"Lives : {playerShip.Lives.ToString()}", Color.White, "arial", 50, 10, 10);
                    SplashKit.DrawText($"Score : {playerShip.Score.ToString()}", Color.White, "arial", 50, 10, 30);

                    //draw bullets 
                    foreach (PlayerBullet bullet in playerBullets)
                    {
                        bullet.Update();
                        bullet.Draw();

                    }
                    foreach (EnemyBullet bullet in enemyBullets)
                    {
                        bullet.Update();
                        bullet.Draw();
                    }

                    // draw enemy ships logic for anything the ships can do 
                    foreach (EnemyShip enemyShip in enemyShips.ToList())
                    {

                        enemyShip.Update();
                        enemyShip.Draw();


                        //make bullets
                        if (SplashKit.TimerTicks(enemyBulletTimer) > 500)
                        {
                            enemyBulletTimer.Reset();
                            EnemyBullet bullet = enemyShip.FireBullet();
                            enemyBullets.Add(bullet);
                            continue;
                        }


                        // Check for collision with bullets
                        foreach (PlayerBullet bullet in playerBullets.ToList())
                        {
                            if (enemyShip.IsCollidingWith(bullet))
                            {
                                // Handle collision (e.g., increase player score)
                                enemyShips.Remove(enemyShip);
                                playerBullets.Remove(bullet);
                                playerShip.IncreaseScore();
                                continue;
                            }


                            //remove bullet once its out of the frame
                            if (bullet.Y < 0 || bullet.Y > 700)
                            {
                                playerBullets.Remove(bullet);
                                continue; // continue the loop to avoid modifying the collection while iterating
                            }
                        }

                        //remove ship once its out of the frame to improve memory
                        if (enemyShip.Y > window.Height)
                        {
                            enemyShips.Remove(enemyShip);
                            continue; // continue the loop to avoid modifying the collection while iterating
                        }
                    }


                    // spawm new enemies
                    if (SplashKit.TimerTicks("enemySpawn") > 1000)
                    {
                        enemySpawnTimer.Reset();
                        enemyShips.Add(new EnemyShip(random.Next(0, 1000), 0, 0.1f, SplashKit.BitmapNamed("enemyBullet"), window));
                    }

                    // check if player has collided with enemy bullets 
                    foreach (EnemyBullet bullet in enemyBullets.ToList())
                    {
                        if (playerShip.IsCollidingWith(bullet))
                        {
                            playerShip.TakeDamage();
                            enemyBullets.Remove(bullet);
                            continue;
                        }

                        if (bullet.Y > window.Height)
                        {
                            enemyBullets.Remove(bullet);
                        }
                    }
                    // if collided with enemy ships 
                    foreach (EnemyShip enemyShip in enemyShips.ToList())
                    {
                        if (playerShip.IsCollidingWith(enemyShip))
                        {
                            playerShip.TakeDamage();
                            enemyShips.Remove(enemyShip);
                            continue;
                        }
                    }
                    Console.WriteLine(enemyBullets.Count);
                    //check if game is over 
                    if (playerShip.Lives <= 0)
                    {
                        gameOver = true;
                        gameOverScreen.Score = playerShip.Score;
                    }
                }
                //if game is over, draw screen and restart ships and bullets
                else
                {
                    gameOverScreen.Draw();

                    if (gameOverScreen.RestartClicked)
                    {
                        gameOver = false;
                        gameStarted = false;
                        gameOverScreen.Reset();
                        playerShip.Reset();
                        enemyShips.Clear();
                        enemyBullets.Clear();
                    }
                }
                
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
