using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectCsWindowsFormsApp
{
    public partial class Form1 : Form
    {

        private List <Circle> SnakeCircle = new List <Circle> ();
        private Circle CircleFood = new Circle ();
        private Square SquareFood = new Square();
        int maxTravelWidth;
        int maxTravelHeight;

        int score;
        int highScore;

        Random rand = new Random ();
        bool goLeft, goRight, goUp, goDown;


        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && Settings.Directions != "right")
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right && Settings.Directions != "left")
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Up && Settings.Directions != "down")
            {
                goUp = true;
            }
            if(e.KeyCode == Keys.Down && Settings.Directions != "up")
            {
                goDown = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void SaveGame(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            //setting the directions

            if (goLeft)
            {
                Settings.Directions = "left";
            }
            if (goRight)
            {
                Settings.Directions = "right";
            }
            if (goUp)
            {
                Settings.Directions = "up";
            }
            if (goDown)
            {
                Settings.Directions = "down";
            }
            //end of directions

            for(int i = SnakeCircle.Count -1;i >= 0; i--)
            {
                if(i == 0)
                {
                    switch (Settings.Directions)
                    {
                        case "left":
                            SnakeCircle[i].setXValue(SnakeCircle[i].getXValue() -1);
                            break;
                        case "right":
                            SnakeCircle[i].setXValue(SnakeCircle[i].getXValue() + 1);
                            break;
                        case "down":
                            SnakeCircle[i].setYValue(SnakeCircle[i].getYValue() + 1);
                            break;
                        case "up":
                            SnakeCircle[i].setYValue(SnakeCircle[i].getYValue() - 1);
                            break;
                    }

                    if (SnakeCircle[i].getXValue() < 0)
                    {
                        SnakeCircle[i].setXValue(maxTravelWidth);
                    }
                    if (SnakeCircle[i].getXValue() > maxTravelWidth)
                    {
                        SnakeCircle[i].setXValue(0);
                    }
                    if (SnakeCircle[i].getYValue() < 0)
                    {
                        SnakeCircle[i].setYValue(maxTravelHeight);
                    }
                    if(SnakeCircle[i].getYValue() > maxTravelHeight)
                    {
                        SnakeCircle[i].setYValue(0);
                    }
                }
                else
                {
                    SnakeCircle[i].setXValue(SnakeCircle[i - 1].getXValue());
                    SnakeCircle[i].setYValue(SnakeCircle[i - 1].getYValue());
                }


            }

            picCanvas.Invalidate();

        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;
            for(int i = 0; i < SnakeCircle.Count; i++)
            {
                if(i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour= Brushes.DarkGreen;
                }

                
                    canvas.FillEllipse(snakeColour, new Rectangle
                        (
                        SnakeCircle[i].getXValue() * Settings.Width,
                        SnakeCircle[i].getYValue() * Settings.Height,
                        Settings.Width, Settings.Height
                        ));
 
            }


            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            CircleFood.getXValue() * Settings.Width,
            CircleFood.getYValue() * Settings.Height,
            Settings.Width, Settings.Height
            ));

            canvas.FillRectangle(Brushes.DarkSalmon, new Rectangle
            (
            SquareFood.getXValue() * Settings.Width,
            SquareFood.getYValue() * Settings.Height,
            Settings.Width, Settings.Height
            ));

        }

        private void RestartGame()
        {
            maxTravelWidth = picCanvas.Width / Settings.Width - 1;
            maxTravelHeight = picCanvas.Height / Settings.Height - 1;

            SnakeCircle.Clear();

            startButton.Enabled = false;
            saveButton.Enabled = false;
            score = 0;
            txtCurrScore.Text = "Score: " + score;

            Circle head = new Circle(10,5);
            SnakeCircle.Add(head); // when restarting the game - adding the head part of the snake to the list

            for(int i = 1; i < 8; i++)
            {
                Circle body = new Circle();
                SnakeCircle.Add(body);
                
            }
            int randomNumber = rand.Next(1,10);
            if(randomNumber < 6)
            {
            CircleFood =new Circle(rand.Next(2,maxTravelWidth),rand.Next(2,maxTravelHeight));
            SquareFood = new Square(rand.Next(2, maxTravelWidth), rand.Next(2, maxTravelHeight));
            }

            gameTimer.Start();

        }
        private void EatFood()
        {

        }
        private void GameOver()
        {

        }
    }
}
