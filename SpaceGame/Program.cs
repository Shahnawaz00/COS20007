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
            //left right
            if (SplashKit.KeyDown(KeyCode.RightKey) || SplashKit.KeyDown(KeyCode.DKey))
            {
                playerShip.Move(1, 0);  // Move ship to the right
            }
            else if (SplashKit.KeyDown(KeyCode.LeftKey) || SplashKit.KeyDown(KeyCode.AKey))
            {
                playerShip.Move(-1, 0);  // Move ship to the left
            }
            //up down
            if (SplashKit.KeyDown(KeyCode.UpKey) || SplashKit.KeyDown(KeyCode.WKey))
            {
                playerShip.Move(0, -1); // Move ship up
            }
            else if (SplashKit.KeyDown(KeyCode.DownKey) || SplashKit.KeyDown(KeyCode.SKey))
            {
                playerShip.Move(0, 1); // move ship down
            }

            //shoot bullets
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

            //load ship images
            SplashKit.LoadBitmap("playerShip", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\player.bmp");
            SplashKit.LoadBitmap("enemyShip", @"c:\users\shahn\source\repos\oop\SpaceGame\assets\enemyShip.bmp");

            //player ship and bullets
            PlayerShip playerShip = new PlayerShip(400, 600, 0.1f, SplashKit.BitmapNamed("playerShip"), SplashKit.BitmapNamed("playerBullet"), window);
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
                        if (SplashKit.TimerTicks(enemyBulletTimer) > 1000)
                        {
                            enemyBulletTimer.Reset();
                            EnemyBullet bullet = enemyShip.FireBullet();
                            enemyBullets.Add(bullet);
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
                                break;
                            }


                            //remove bullet once its out of the frame
                            if (bullet.Y < 0 || bullet.Y > 700)
                            {
                                playerBullets.Remove(bullet);
                                break; // Break the loop to avoid modifying the collection while iterating
                            }
                        }

                        //remove ship once its out of the frame to improve memory
                        if (enemyShip.Y > 700)
                        {
                            enemyShips.Remove(enemyShip);
                            break; // Break the loop to avoid modifying the collection while iterating
                        }
                    }


                    // spawm new enemies
                    if (SplashKit.TimerTicks("enemySpawn") > 2000)
                    {
                        enemySpawnTimer.Reset();
                        enemyShips.Add(new EnemyShip(random.Next(0, 1200), 0, 0.1f, SplashKit.BitmapNamed("enemyShip"), SplashKit.BitmapNamed("playerBullet"), window));
                    }

                    // check if player has collided with enemy bullets 
                    foreach (EnemyBullet bullet in enemyBullets.ToList())
                    {
                        if (playerShip.IsCollidingWith(bullet))
                        {
                            playerShip.TakeDamage();
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
                        }
                    }

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
