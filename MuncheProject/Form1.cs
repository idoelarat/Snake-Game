using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

using System.IO;
using System.Runtime.Serialization;//!!!!!!
using System.Runtime.Serialization.Formatters.Binary;


namespace MuncheProject
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private List<Elipse> Snake2 = new List<Elipse>();
        private List<BiggerElipse> Snake3 = new List<BiggerElipse>();
        private Circle food = new Circle();
        private Rectangel Poision = new Rectangel();
        private Figure shapeList = new Circle();
        private Figure shapeList2 = new Elipse();
        private Figure shapeList3 = new BiggerElipse();
        private List<Scoreboard> listScores = new List<Scoreboard>();
        
        
        int boxWidth;
        int boxHeight;
        string name;
        int score;
        int highScore;
        
        Random rand = new Random();

       bool goLeft, goRight, goUp , goDown;

        Settings newSettings = new Settings();
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

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

        private void RestartGame()
        {
            boxWidth = picBox.Width / Settings.Width - 1;
            boxHeight = picBox.Height / Settings.Height - 1;

            Snake.Clear();
            Snake2.Clear();
            Snake3.Clear();
            StartButton.Enabled = false;
            SaveButton.Enabled = false;
            LoadButton.Enabled = false;
            NameTextBox.Enabled = false;
            ScoreBoardGrid.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle(10, 5);
            Snake.Add(head);
            Elipse head2 = new Elipse(10, 5);
            Snake2.Add(head2);
            BiggerElipse head3 = new BiggerElipse(10, 5);
            Snake3.Add(head3);
            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
                Elipse body2 = new Elipse(body.GetX(), body.GetY());
                Snake2.Add(body2);
                BiggerElipse body3 = new BiggerElipse();
                Snake3.Add(body3);

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
            if (score <= 5)
            {
                for (int i = Snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (Settings.directions)
                        {
                            case "left":
                                Snake[i].SetX(Snake[i].GetX() - 1);
                                break;
                            case "right":
                                Snake[i].SetX(Snake[i].GetX() + 1);
                                break;
                            case "up":
                                Snake[i].SetY(Snake[i].GetY() - 1);
                                break;
                            case "down":
                                Snake[i].SetY(Snake[i].GetY() + 1);
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
                if (score == 6)
                {

                    for (int i = 0; i < Snake.Count; i++)
                    {
                        Elipse temp = new Elipse(Snake[i].GetX(), Snake[i].GetY());
                        Snake2[i] = temp;

                    }
                }
            }
            if (score > 5 && score < 11)
            {
                for (int i = Snake2.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (Settings.directions)
                        {
                            case "left":
                                Snake2[i].SetX(Snake2[i].GetX() - 1);
                                break;
                            case "right":
                                Snake2[i].SetX(Snake2[i].GetX() + 1);
                                break;
                            case "up":
                                Snake2[i].SetY(Snake2[i].GetY() - 1);
                                break;
                            case "down":
                                Snake2[i].SetY(Snake2[i].GetY() + 1);
                                break;
                        }
                        if (Snake2[i].GetX() < 0)
                        {
                            Snake2[i].SetX(boxWidth);
                        }
                        if (Snake2[i].GetX() > boxWidth)
                        {
                            Snake2[i].SetX(0);
                        }
                        if (Snake2[i].GetY() < 0)
                        {
                            Snake2[i].SetY(boxHeight);
                        }
                        if (Snake2[i].GetY() > boxHeight)
                        {
                            Snake2[i].SetY(0);
                        }

                        if (Snake2[i].GetX() == food.GetX() && Snake2[i].GetY() == food.GetY())
                        {
                            EatFood();
                        }
                        if (Snake2[i].GetX() == Poision.GetX() && Snake2[i].GetY() == Poision.GetY())
                        {
                            EatPoision();
                        }
                        for (int j = 1; j < Snake2.Count; j++)
                        {
                            if (Snake2[i].GetX() == Snake2[j].GetX() && Snake2[i].GetY() == Snake2[j].GetY())
                            {
                                GameOver();
                            }
                        }
                    }
                    else
                    {
                        Snake2[i].SetX(Snake2[i - 1].GetX());
                        Snake2[i].SetY(Snake2[i - 1].GetY());
                    }
                }
                if (score == 11)
                {
                    for (int i = 0; i < Snake2.Count; i++)
                    {
                        BiggerElipse temp = new BiggerElipse(Snake2[i].GetX(), Snake2[i].GetY());
                        Snake3[i] = temp;
                    }
                }
            }

            if (score >= 11)
            {

                for (int i = Snake3.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (Settings.directions)
                        {
                            case "left":
                                Snake3[i].SetX(Snake3[i].GetX() - 1);
                                break;
                            case "right":
                                Snake3[i].SetX(Snake3[i].GetX() + 1);
                                break;
                            case "up":
                                Snake3[i].SetY(Snake3[i].GetY() - 1);
                                break;
                            case "down":
                                Snake3[i].SetY(Snake3[i].GetY() + 1);
                                break;
                        }
                        if (Snake3[i].GetX() < 0)
                        {
                            Snake3[i].SetX(boxWidth);
                        }
                        if (Snake3[i].GetX() > boxWidth)
                        {
                            Snake3[i].SetX(0);
                        }
                        if (Snake3[i].GetY() < 0)
                        {
                            Snake3[i].SetY(boxHeight);
                        }
                        if (Snake3[i].GetY() > boxHeight)
                        {
                            Snake3[i].SetY(0);
                        }

                        if (Snake3[i].GetX() == food.GetX() && Snake3[i].GetY() == food.GetY())
                        {
                            EatFood();
                        }
                        if (Snake3[i].GetX() == Poision.GetX() && Snake3[i].GetY() == Poision.GetY())
                        {
                            EatPoision();
                        }
                        for (int j = 1; j < Snake3.Count; j++)
                        {
                            if (Snake3[i].GetX() == Snake3[j].GetX() && Snake3[i].GetY() == Snake3[j].GetY())
                            {
                                GameOver();
                            }
                        }
                    }
                    else
                    {
                        Snake3[i].SetX(Snake3[i - 1].GetX());
                        Snake3[i].SetY(Snake3[i - 1].GetY());
                    }
                }
        }

        picBox.Invalidate();
        }

        private void UpdatePicBox(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush SnakeColour;

            if (score <= 5)
            {
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        SnakeColour = Brushes.Black;
                    }
                    else
                    {
                        SnakeColour = Brushes.DarkRed;
                    }
                    shapeList.updateSize(canvas, newSettings, Snake[i], SnakeColour);

                }
            }
            if (score > 5 && score < 11)
            {
                for (int i = 0; i < Snake2.Count; i++)
                {
                    if (i == 0)
                    {
                        SnakeColour = Brushes.Black;
                    }
                    else
                    {
                        SnakeColour = Brushes.DarkRed;
                    }
                    shapeList2.updateSize(canvas, newSettings, Snake2[i], SnakeColour);
                }
            }
            if (score >= 11)
            {
                for (int i = 0; i < Snake3.Count; i++)
                {
                    if (i == 0)
                    {
                        SnakeColour = Brushes.Black;
                    }
                    else
                    {
                        SnakeColour = Brushes.DarkRed;
                    }
                    shapeList3.updateSize(canvas, newSettings, Snake3[i], SnakeColour);
                }
        }
        SnakeColour = Brushes.LightSkyBlue;
            shapeList.updateSize(canvas, newSettings, food, SnakeColour);

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

            if (score == 6)
                picBox.BackgroundImage = MuncheProject.Properties.Resources.light_sand_template;

            txtScore.Text = "Score: " + score;

            if (score < 6)
            {
                Circle body = new Circle(Snake[Snake.Count - 1].GetX(), Snake[Snake.Count - 1].GetY());
                Snake.Add(body);
                Elipse body3 = new Elipse(Snake2[Snake2.Count - 1].GetX(), Snake2[Snake2.Count - 1].GetY());
                Snake2.Add(body3);
                BiggerElipse body4 = new BiggerElipse(Snake3[Snake3.Count - 1].GetX(), Snake3[Snake3.Count - 1].GetY());
                Snake3.Add(body4);

            }
            if (score > 5 && score < 11)
            {
                Elipse body2 = new Elipse(Snake2[Snake2.Count - 1].GetX(), Snake2[Snake2.Count - 1].GetY());
                Snake2.Add(body2);
                BiggerElipse body4 = new BiggerElipse(Snake3[Snake3.Count - 1].GetX(), Snake3[Snake3.Count - 1].GetY());
                Snake3.Add(body4);
            }
            if (score == 11)
            {
                picBox.BackgroundImage = MuncheProject.Properties.Resources._2;
            }
            if(score > 10)
            {
                BiggerElipse body4 = new BiggerElipse(Snake3[Snake3.Count - 1].GetX(), Snake3[Snake3.Count - 1].GetY());
                Snake3.Add(body4);
            }

            food = new Circle ( rand.Next(2, boxWidth),  rand.Next(2, boxHeight) );
            Poision = new Rectangel(rand.Next(2, boxWidth), rand.Next(2, boxHeight));


        }

        private void NameTextBoxChange(object sender, EventArgs e)
        {
            name = NameTextBox.Text;
        }

        private void SaveScoreBoard(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                   formatter.Serialize(stream, listScores);
                }
            }

        }

        private void LoadScoreButton(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                listScores = (List<Scoreboard>)binaryFormatter.Deserialize(stream);
                picBox.Invalidate();
            }
            updatedatagridupload(listScores);
        }
        private void updatedatagridupload(List<Scoreboard> listScores)
        {
            for (int i = 0; i < listScores.Count ; i++)
            {
                ScoreBoardGrid.Rows.Add(listScores[i].getplayerName(), listScores[i].getplayerScore());
            }
            
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
            LoadButton.Enabled = true;
            ScoreBoardGrid.Enabled = true;
            NameTextBox.Enabled = true;
            listScores.Add(new Scoreboard(score, name));
            ScoreBoardGrid.Rows.Add(name,score);
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
        
    }
}
