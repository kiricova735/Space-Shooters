/*Kiril Covaliov
 ICS3U
 Final Project Assignment
 Space Shooters*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.IO;

namespace Space_Shooters
{
    public partial class spaceShooters : Form
    {
        string gameState = "waiting";

        Stopwatch myWatch = new Stopwatch();

        List<int> meteorXList = new List<int>();
        List<int> meteorYList = new List<int>();
        List<int> meteorSizeList = new List<int>();
        List<int> projectileXList = new List<int>();
        List<int> projectileYList = new List<int>();
        List<int> projectile2XList = new List<int>();
        List<int> projectile2YList = new List<int>();

        int projectileSpeed = 14;
        int meteorSpeed = 5;
        int projectileWidth = 10;
        int projectileHeight = 3;

        Image shipImage;
        Image meteorImage;
        Image shipImage2;

        int spaceShip1X = 5;
        int spaceShip1Y = 170;
        int spaceShip2X = 737;
        int spaceShip2Y = 170;
        int spaceShipWidth = 60;
        int spaceShipHeight = 30;
        int spaceShipSpeed = 5;

        int playerScore1 = 0;
        int playerScore2 = 0;

        int shotCounter = 0;
        int shotCounter2 = 0;
        int counter = 0;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Lime);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;
        bool shiftDown = false;
        bool numpad0Down = false;

        SoundPlayer laser = new SoundPlayer(Properties.Resources.laser);
        SoundPlayer crash = new SoundPlayer(Properties.Resources.crash);
        SoundPlayer meteorExplosion = new SoundPlayer(Properties.Resources.meteorExplosion);
        SoundPlayer click = new SoundPlayer(Properties.Resources.click);
        SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        SoundPlayer point = new SoundPlayer(Properties.Resources.point);
        SoundPlayer explosion = new SoundPlayer(Properties.Resources.explosion);

        System.Windows.Media.MediaPlayer startingMusic = new System.Windows.Media.MediaPlayer();

        Random randGen = new Random();
        int randValue = 0;

        public spaceShooters()
        {
            InitializeComponent();

            startingMusic.Open(new Uri(Application.StartupPath + "/Resources/backMusic.wav"));
            startingMusic.MediaEnded += new EventHandler(startingMusic_MediaEnded);
        }
        public void GameInitialize()
        {
            titleLabel.Text = "";
            subTitleLabel.Text = "";

            gameEngine.Enabled = true;
            gameState = "controls";

            meteorXList.Clear();
            meteorYList.Clear();
            meteorSpeed = 5;
            projectileXList.Clear();
            projectileYList.Clear();

            shipImage = Properties.Resources.goodship;
            shipImage2 = Properties.Resources.player2;
            meteorImage = Properties.Resources.meteor;
        }
        public void GameInitialize2()
        {
            gameEngine.Enabled = true;
            gameState = "controls PVP";

            projectileXList.Clear();
            projectileYList.Clear();
            projectile2XList.Clear();
            projectile2YList.Clear();
            meteorXList.Clear();
            meteorYList.Clear();

            titleLabel.Text = "";
            subTitleLabel.Text = "";
            timerLabel.Text = "";

            shipImage = Properties.Resources.goodship;
            shipImage2 = Properties.Resources.player2;
        }

        private void SpaceShooters_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.ShiftKey:
                    shiftDown = true;
                    break;
                case Keys.Insert:
                    numpad0Down = true;
                    break;
                case Keys.Space:
                    click.Play();
                    if (gameState == "waiting" || gameState == "over")
                    {
                        counter = 0;
                        GameInitialize();
                        gameState = "controls";
                    }
                    break;
                case Keys.Escape:
                    click.Play();
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Tab:
                    click.Play();
                    if (gameState == "waiting" || gameState == "over")
                    {
                        counter = 0;
                        GameInitialize2();
                        gameState = "controls PVP";
                    }
                    break;
            }
        }

        private void SpaceShooters_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.ShiftKey:
                    shiftDown = false;
                    break;
                case Keys.Insert:
                    numpad0Down = false;
                    break;
            }
        }
        private void SpaceShooters_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "controls PVP")
            {
                titleLabel.Text = "       Controls";
                subTitleLabel.Text = "       PLAYER 1 CONTROLS                 PLAYER 2 CONTROLS\n             W Key: Up                         Up Arrow Key: Up\n           S Key: Down                   Down Arrow Key: Down\n           A Key: Left                        Left Arrow Key: Left\n           D Key: Right                     Right Arrow Key: Right\n       Shift Key: Shoot                      Insert Key: Shoot\n";
            }

            else if (gameState == "waiting")
            {
                titleLabel.Text = "  SPACE SHOOTERS";
                subTitleLabel.Text = "            Press Space Bar to Play Single Player, Tab to                           Play Multiplayer, or Escape to Exit Game";
            }

            else if (gameState == "controls")
            {
                titleLabel.Text = "       Controls";
                subTitleLabel.Text = "                                      W Key: Up\n                                      S Key: Down\n                                      A Key: Left\n                                      D Key: Right\n                                  Shift Key: Shoot\n\n                         Survive as long as you can!";
            }

            else if (gameState == "running PVP")
            {
                //Player 1
                e.Graphics.DrawImage(shipImage, spaceShip1X, spaceShip1Y, spaceShipWidth, spaceShipHeight);

                //Player 2
                e.Graphics.DrawImage(shipImage2, spaceShip2X, spaceShip2Y, spaceShipWidth, spaceShipHeight);

                //Player 1 projectiles
                for (int i = 0; i < projectileXList.Count; i++)
                {
                    e.Graphics.FillRectangle(redBrush, projectileXList[i], projectileYList[i], projectileWidth, projectileHeight);
                }

                //Player 2 projectiles
                for (int i = 0; i < projectile2XList.Count; i++)
                {
                    e.Graphics.FillRectangle(greenBrush, projectile2XList[i], projectile2YList[i], projectileWidth, projectileHeight);
                }
            }
            else if (gameState == "running")
            {
                //Player 1
                e.Graphics.DrawImage(shipImage, spaceShip1X, spaceShip1Y, spaceShipWidth, spaceShipHeight);
                timerLabel.Text = myWatch.Elapsed.ToString(@"m\:ss\:ff");

                //Meteors
                for (int i = 0; i < meteorXList.Count; i++)
                {
                    e.Graphics.DrawImage(meteorImage, meteorXList[i], meteorYList[i], meteorSizeList[i], meteorSizeList[i]);
                }

                //Player 1 projectiles
                for (int i = 0; i < projectileXList.Count; i++)
                {
                    e.Graphics.FillRectangle(redBrush, projectileXList[i], projectileYList[i], projectileWidth, projectileHeight);
                }
            }
        }

        private void startingMusic_MediaEnded(object sender, EventArgs e)
        {
            startingMusic.Stop();
            startingMusic.Play();
        }

        private void GameEngine_Tick(object sender, EventArgs e)
        {
            if (gameState == "controls")
            {
                counter++;
                if (counter > 200)
                {
                    startingMusic.Play();
                    gameState = "running";
                    titleLabel.Text = "";
                    subTitleLabel.Text = "";
                    survivedLabel.Text = "";
                    player1Score.Text = "";
                    player2Score.Text = "";
                    myWatch.Start();
                    counter = 0;
                }
            }

            if (gameState == "controls PVP")
            {
                survivedLabel.Text = "";
                counter++;
                if (counter > 200)
                {                  
                    startingMusic.Play();
                    gameState = "running PVP";
                    titleLabel.Text = "";
                    subTitleLabel.Text = "";
                    survivedLabel.Text = "";
                    player1Score.Text = "0";
                    player2Score.Text = "0";
                    counter = 0;
                }
            }

            //move player 1
            if (wDown == true && spaceShip1Y > 5)
            {
                spaceShip1Y -= spaceShipSpeed;
            }

            if (sDown == true && spaceShip1Y < 370)
            {
                spaceShip1Y += spaceShipSpeed;
            }

            if (aDown == true && spaceShip1X > 5)
            {
                spaceShip1X -= spaceShipSpeed;
            }

            if (dDown == true && spaceShip1X < 370)
            {
                spaceShip1X += spaceShipSpeed;
            }

            //move player 2
            if (upArrowDown == true && spaceShip2Y > 5)
            {
                spaceShip2Y -= spaceShipSpeed;
            }

            if (downArrowDown == true && spaceShip2Y < 370)
            {
                spaceShip2Y += spaceShipSpeed;
            }

            if (leftArrowDown == true && spaceShip2X > 370)
            {
                spaceShip2X -= spaceShipSpeed;
            }

            if (rightArrowDown == true && spaceShip2X < 737)
            {
                spaceShip2X += spaceShipSpeed;
            }

            //Generating projectiles
            //player 1 shooting
            shotCounter++;
            if (shiftDown == true && shotCounter > 16)
            {
                laser.Play();
                projectileXList.Add(spaceShip1X);
                projectileYList.Add(spaceShip1Y);
                shotCounter = 0;
            }

            for (int i = 0; i < projectileXList.Count(); i++)
            {
                projectileXList[i] += projectileSpeed;
            }

            //player 2 shooting
            if (gameState == "running PVP")
            {
                shotCounter2++;
                if (numpad0Down == true && shotCounter2 > 16)
                {
                    laser.Play();
                    projectile2XList.Add(spaceShip2X);
                    projectile2YList.Add(spaceShip2Y);
                    shotCounter2 = 0;
                }

                for (int i = 0; i < projectile2XList.Count(); i++)
                {
                    projectile2XList[i] -= projectileSpeed;
                }
            }
            //Generating meteors
            if (gameState == "running")
            {
                randValue = randGen.Next(0, 10);
                counter++;
                if (randValue < 1)
                {
                    meteorXList.Add(randGen.Next(1400, 1500));
                    meteorYList.Add(randGen.Next(0, 400));

                    meteorSizeList.Add(randGen.Next(15, 40));
                    if (counter <= 100)
                    {
                        meteorSpeed = 5;
                    }

                    if (counter >= 480 && counter < 960)
                    {
                        meteorSpeed = 7;
                    }

                    if (counter >= 960)
                    {
                        meteorSpeed = 10;
                    }

                    if (counter >= 1920)
                    {
                        meteorSpeed = 13;
                    }

                    if (counter >= 3840)
                    {
                        meteorSpeed = 20;
                    }
                }
            }

            for (int i = 0; i < meteorXList.Count(); i++)
            {
                meteorXList[i] -= meteorSpeed;
            }

            //Collision with meteors and spaceship
            Rectangle spaceShipRec = new Rectangle(spaceShip1X, spaceShip1Y, spaceShipWidth, spaceShipHeight);
            Rectangle spaceShipRec2 = new Rectangle(spaceShip2X, spaceShip2Y, spaceShipWidth, spaceShipHeight);

            for (int i = 0; i < meteorXList.Count(); i++)
            {
                Rectangle meteorRec = new Rectangle(meteorXList[i], meteorYList[i], meteorSizeList[i], meteorSizeList[i]);

                if (spaceShipRec.IntersectsWith(meteorRec))
                {
                    startingMusic.Stop();
                    crash.Play();
                    gameEngine.Enabled = false;
                    myWatch.Stop();
                    Thread.Sleep(1500);
                    spaceShip1X = 5;
                    spaceShip1Y = 160;
                    titleLabel.Text = "       You Died";
                    gameState = "over";
                    timerLabel.Text = myWatch.Elapsed.ToString(@"m\:ss\:ff");
                    survivedLabel.Text = "Time survived:";
                    subTitleLabel.Text = "            Press Space Bar to Play Single Player, Tab to                           Play Multiplayer, or Escape to Exit Game";
                    myWatch.Reset();
                }

                //Collision with projectiles and meteors
            }

            for (int i = 0; i < projectileXList.Count(); i++)
            {
                Rectangle projectileRec = new Rectangle(projectileXList[i], projectileYList[i], projectileWidth, projectileHeight);
                for (int j = 0; j < meteorXList.Count(); j++)
                {
                    Rectangle meteorRec = new Rectangle(meteorXList[j], meteorYList[j], meteorSizeList[j], meteorSizeList[j]);
                    if (meteorRec.IntersectsWith(projectileRec))
                    {
                        meteorExplosion.Play();
                        projectileXList.RemoveAt(i);
                        projectileYList.RemoveAt(i);
                        meteorXList.RemoveAt(j);
                        meteorYList.RemoveAt(j);
                        meteorSizeList.RemoveAt(j);
                        break;
                    }
                }
            }

            if (gameState == "running PVP")
            {
                //Collision with projectiles and ships in PVP mode
                //Player 2 shooting player 1
                for (int i = 0; i < projectile2XList.Count(); i++)
                {
                    Rectangle projectileRec2 = new Rectangle(projectile2XList[i], projectile2YList[i], projectileWidth, projectileHeight);

                    if (spaceShipRec.IntersectsWith(projectileRec2))
                    {
                        explosion.Play();
                        playerScore2++;
                        player2Score.Text = $"{playerScore2}";          
                        spaceShip1X = 5;
                        spaceShip1Y = 170;
                        spaceShip2X = 737;
                        spaceShip2Y = 170;
                        projectile2XList.RemoveAt(i);
                        projectile2YList.RemoveAt(i);
                        Thread.Sleep(1500);
                        point.Play();
                    }
                }

                //Player 1 shooting player 2
                for (int i = 0; i < projectileXList.Count(); i++)
                {

                    Rectangle projectileRec = new Rectangle(projectileXList[i], projectileYList[i], projectileWidth, projectileHeight);

                    if (spaceShipRec2.IntersectsWith(projectileRec))
                    {
                        explosion.Play();
                        playerScore1++;
                        player1Score.Text = $"{playerScore1}";
                        spaceShip1X = 5;
                        spaceShip1Y = 170;
                        spaceShip2X = 737;
                        spaceShip2Y = 170;
                        projectileXList.RemoveAt(i);
                        projectileYList.RemoveAt(i);
                        Thread.Sleep(1500);
                        point.Play();
                    }
                }
                if (spaceShipRec2.IntersectsWith(spaceShipRec) || spaceShipRec.IntersectsWith(spaceShipRec2))
                {
                    explosion.Play();
                    spaceShip1X = 5;
                    spaceShip1Y = 170;
                    spaceShip2X = 737;
                    spaceShip2Y = 170;
                    Thread.Sleep(1500);                    
                }

                //If player 1 wins
                if (playerScore1 == 5)
                {
                    startingMusic.Stop();
                    win.Play();
                    gameEngine.Enabled = false;
                    gameState = "over";
                    titleLabel.Text = "   Player 1 Wins!";
                    subTitleLabel.Text = "            Press Space Bar to Play Single Player, Tab to                           Play Multiplayer, or Escape to Exit Game";
                    playerScore1 = 0;
                    playerScore2 = 0;
                    player1Score.Text = "";
                    player2Score.Text = "";
                }

                //If player 2 wins
                if (playerScore2 == 5)
                {
                    startingMusic.Stop();
                    win.Play();
                    gameEngine.Enabled = false;
                    gameState = "over";
                    titleLabel.Text = "   Player 2 Wins!";
                    subTitleLabel.Text = "            Press Space Bar to Play Single Player, Tab to                           Play Multiplayer, or Escape to Exit Game";
                    playerScore1 = 0;
                    playerScore2 = 0;
                    player1Score.Text = "";
                    player2Score.Text = "";
                }
            }
            Refresh();
        }
    }
}
