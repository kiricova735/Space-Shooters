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

        int projectileSpeed = 14;
        int meteorSize = 15;
        int meteorSpeed = 5;
        int projectileWidth = 10;
        int projectileHeight = 3;

        Image shipImage;
        Image meteorImage;

        int spaceShip1X = 150;
        int spaceShip1Y = 150;
        int spaceShip2X = 600;
        int spaceShip2Y = 400;
        int spaceShipWidth = 60;
        int spaceShipHeight = 30;
        int spaceShipSpeed = 5;

        int shotCounter = 0;
        int counter = 0;
        int time = 0;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
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

        SoundPlayer laser = new SoundPlayer(Properties.Resources.laser);
        SoundPlayer crash = new SoundPlayer(Properties.Resources.crash);
        SoundPlayer meteorExplosion = new SoundPlayer(Properties.Resources.meteorExplosion);
        SoundPlayer click = new SoundPlayer(Properties.Resources.click);
        SoundPlayer startingMusic = new SoundPlayer(Properties.Resources.startingMusic);



        Random randGen = new Random();
        int randValue = 0;

        public spaceShooters()
        {
            InitializeComponent();

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


            int spaceShip1X = 150;
            int spaceShip1Y = 150;
            int spaceShip2X = 600;
            int spaceShip2Y = 400;

            shipImage = Properties.Resources.goodship;
            meteorImage = Properties.Resources.meteor;
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
                case Keys.Space:
                    click.Play();
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
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
            }
        }

        private void SpaceShooters_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "SPACE SHOOTERS";
                subTitleLabel.Text = "Press Space Bar to Play or Escape to Exit Game";
            }
            else if (gameState == "controls")
            {
                titleLabel.Text = "      Controls";
                subTitleLabel.Text = "W Key: Up\n S Key: Down\n A Key: Left\n D Key: Right\n Shift Key: Shoot\n\n Survive as long as you can!";
            }
            else if (gameState == "running")
            {
                //Space Ship 1
                e.Graphics.DrawImage(shipImage, spaceShip1X, spaceShip1Y, spaceShipWidth, spaceShipHeight);
                timerLabel.Text = myWatch.Elapsed.ToString(@"m\:ss\:ff");
                //Meteors
                for (int i = 0; i < meteorXList.Count; i++)
                {
                    e.Graphics.DrawImage(meteorImage, meteorXList[i], meteorYList[i], meteorSizeList[i], meteorSizeList[i]);
                }
                //Projectiles
                for (int i = 0; i < projectileXList.Count; i++)
                {
                    e.Graphics.FillRectangle(redBrush, projectileXList[i], projectileYList[i], projectileWidth, projectileHeight);
                }
            }
        }


        private void GameEngine_Tick(object sender, EventArgs e)
        {
            if (gameState == "controls")
            {
                counter++;
                if (counter > 200)
                {
                    gameState = "running";
                    titleLabel.Text = "";
                    subTitleLabel.Text = "";
                    survivedLabel.Text = "";
                    myWatch.Start();
                    counter = 0;
                    counter++;

                    var startingMusic = new System.Windows.Media.MediaPlayer();

                    startingMusic.Open(new Uri(Application.StartupPath + "/Resources/startingMusic"));

                    startingMusic.Play();


                }

            }

            //move hero 1
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

            //Projectiles
            shotCounter++;
            if (shiftDown == true && shotCounter > 10)
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

            //Generating meteors

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

            for (int i = 0; i < meteorXList.Count(); i++)
            {
                meteorXList[i] -= meteorSpeed;
            }

            //Collision with meteors and spaceship
            Rectangle spaceShipRec = new Rectangle(spaceShip1X, spaceShip1Y, spaceShipWidth, spaceShipHeight);
            for (int i = 0; i < meteorXList.Count(); i++)
            {
                Rectangle meteorRec = new Rectangle(meteorXList[i], meteorYList[i], meteorSizeList[i], meteorSizeList[i]);

                if (spaceShipRec.IntersectsWith(meteorRec))
                {
                    crash.Play();
                    gameEngine.Enabled = false;
                    myWatch.Stop();
                    Thread.Sleep(1500);
                    titleLabel.Text = "       You Died";
                    gameState = "over";
                    timerLabel.Text = myWatch.Elapsed.ToString(@"m\:ss\:ff");
                    survivedLabel.Text = "Time survived:";
                    subTitleLabel.Text = " Press Space Bar to Play Again or Escape to Exit Game";
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

            Refresh();
        }

    }
}
