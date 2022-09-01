using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuncheProject
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        private Rectangel Poision = new Rectangel();

        int boxWidth;
        int boxHeight;

        int score;
        int highScore;
        
        Random rand = new Random();

       bool goLeft, goRight, goUp , goDown;

        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
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

        private void SaveScore(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {
            boxWidth = picBox.Width / Settings.Width - 1;
            boxHeight = picBox.Height / Settings.Height - 1;

            Snake.Clear();
            StartButton.Enabled = false;
            SaveButton.Enabled = false;
            LoadButton.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle (10,5);
            Snake.Add(head);
            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle ( rand.Next(2, boxWidth), rand.Next(2, boxHeight));
            Poision = new Rectangel ( rand.Next(2, boxWidth),  rand.Next(2, boxHeight) );
            

            gameTimer.Start();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].SetX(Snake[i].GetX()-1);
                            break;
                        case "right":
                            Snake[i].SetX(Snake[i].GetX()+1);
                            break;
                        case "up":
                            Snake[i].SetY(Snake[i].GetY() -1);
                            break;
                        case "down":
                            Snake[i].SetY(Snake[i].GetY() +1);
                            break;
                    }
                    if (Snake[i].GetX() < 0)
                    {
                        Snake[i].SetX(boxWidth);
                    }
                    if (Snake[i].GetX() > boxWidth)
                    {
                        Snake[i].SetX(0);
                    }
                    if (Snake[i].GetY() < 0)
                    {
                        Snake[i].SetY(boxHeight);
                    }
                    if (Snake[i].GetY() > boxHeight)
                    {
                        Snake[i].SetY(0);
                    }

                    if (Snake[i].GetX() == food.GetX() && Snake[i].GetY() == food.GetY())
                    {
                        EatFood();
                    }
                    if (Snake[i].GetX() == Poision.GetX() && Snake[i].GetY() == Poision.GetY())
                    {
                        EatPoision();
                    }
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].GetX() == Snake[j].GetX() && Snake[i].GetY() == Snake[j].GetY())
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].SetX(Snake[i - 1].GetX());
                    Snake[i].SetY(Snake[i - 1].GetY());
                }
            }
            picBox.Invalidate();
        }

        private void UpdatePicBox(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush SnakeColour;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i==0)
                {
                    SnakeColour = Brushes.Black;
                }
                else
                {
                    SnakeColour = Brushes.DarkRed;
                }

                canvas.FillEllipse(SnakeColour, new Rectangle
                    (
                    Snake[i].GetX() * Settings.Width,
                    Snake[i].GetY() * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }
            canvas.FillEllipse(Brushes.LightSkyBlue, new Rectangle
                   (
                   food.GetX() * Settings.Width,
                   food.GetY() * Settings.Height,
                   Settings.Width, Settings.Height
                   ));
            canvas.FillRectangle(Brushes.Purple, new Rectangle
                   (
                   Poision.GetX() * Settings.Width,
                   Poision.GetY() * Settings.Height,
                   Settings.Width, Settings.Height
                   ));
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void EatFood()
        {
            score += 1;

            txtScore.Text = "Score: " + score;

            Circle body = new Circle (Snake[Snake.Count - 1].GetX(), Snake[Snake.Count - 1].GetY());
           

            Snake.Add(body);

            food = new Circle ( rand.Next(2, boxWidth),  rand.Next(2, boxHeight) );
            Poision = new Rectangel(rand.Next(2, boxWidth), rand.Next(2, boxHeight));


        }
        private void EatPoision()
        {
            GameOver();
        }
        private void GameOver()
        {
            gameTimer.Stop();
            StartButton.Enabled = true;
            SaveButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " +Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
            string message = "You finished the game with: \n"+" \t     " + score + " points! ";
            string title = "Well Done";
            MessageBox.Show(message, title);
        }
        public PictureBox MyPictureBox
        {
            get
            {
                return picBox;
            }
        }
    }
}
