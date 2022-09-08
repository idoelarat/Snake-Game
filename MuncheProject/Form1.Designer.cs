namespace MuncheProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.picBox = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.ScoreBoardGrid = new System.Windows.Forms.DataGridView();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameLable = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteFromScorboardButton = new System.Windows.Forms.Button();
            this.UpdateNameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBoardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picBox.BackgroundImage = global::MuncheProject.Properties.Resources.grass_template2;
            this.picBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBox.InitialImage = global::MuncheProject.Properties.Resources.grass_template2;
            this.picBox.Location = new System.Drawing.Point(12, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(580, 680);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePicBox);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(610, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(255, 63);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Lime;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(610, 81);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(255, 63);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save Score Board";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveScoreBoard);
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LoadButton.FlatAppearance.BorderSize = 0;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(610, 150);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(255, 63);
            this.LoadButton.TabIndex = 3;
            this.LoadButton.Text = "Load Score Board";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadScoreButton);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(605, 270);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(76, 20);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighScore.Location = new System.Drawing.Point(606, 290);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(98, 20);
            this.txtHighScore.TabIndex = 4;
            this.txtHighScore.Text = "High Score";
            // 
            // ScoreBoardGrid
            // 
            this.ScoreBoardGrid.AllowUserToAddRows = false;
            this.ScoreBoardGrid.AllowUserToDeleteRows = false;
            this.ScoreBoardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoreBoardGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.PlayerScore});
            this.ScoreBoardGrid.Location = new System.Drawing.Point(610, 364);
            this.ScoreBoardGrid.Name = "ScoreBoardGrid";
            this.ScoreBoardGrid.ReadOnly = true;
            this.ScoreBoardGrid.Size = new System.Drawing.Size(255, 328);
            this.ScoreBoardGrid.TabIndex = 5;
            this.ScoreBoardGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridCellClick);
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // PlayerScore
            // 
            this.PlayerScore.HeaderText = "Score";
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.ReadOnly = true;
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLable.Location = new System.Drawing.Point(606, 326);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(60, 20);
            this.NameLable.TabIndex = 4;
            this.NameLable.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(673, 325);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(192, 20);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBoxChange);
            // 
            // DeleteFromScorboardButton
            // 
            this.DeleteFromScorboardButton.BackColor = System.Drawing.Color.Red;
            this.DeleteFromScorboardButton.FlatAppearance.BorderSize = 0;
            this.DeleteFromScorboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteFromScorboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFromScorboardButton.Location = new System.Drawing.Point(609, 217);
            this.DeleteFromScorboardButton.Name = "DeleteFromScorboardButton";
            this.DeleteFromScorboardButton.Size = new System.Drawing.Size(255, 24);
            this.DeleteFromScorboardButton.TabIndex = 3;
            this.DeleteFromScorboardButton.Text = "Delete From ScorBoard";
            this.DeleteFromScorboardButton.UseVisualStyleBackColor = false;
            this.DeleteFromScorboardButton.Click += new System.EventHandler(this.DeleteFromScoreboardButton);
            // 
            // UpdateNameButton
            // 
            this.UpdateNameButton.BackColor = System.Drawing.Color.Cyan;
            this.UpdateNameButton.FlatAppearance.BorderSize = 0;
            this.UpdateNameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateNameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateNameButton.Location = new System.Drawing.Point(609, 243);
            this.UpdateNameButton.Name = "UpdateNameButton";
            this.UpdateNameButton.Size = new System.Drawing.Size(255, 24);
            this.UpdateNameButton.TabIndex = 3;
            this.UpdateNameButton.Text = "Update Name ScorBoard";
            this.UpdateNameButton.UseVisualStyleBackColor = false;
            this.UpdateNameButton.Click += new System.EventHandler(this.UpdateNameB);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 697);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ScoreBoardGrid);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.UpdateNameButton);
            this.Controls.Add(this.DeleteFromScorboardButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.picBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Snake Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBoardGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.DataGridView ScoreBoardGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerScore;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button DeleteFromScorboardButton;
        private System.Windows.Forms.Button UpdateNameButton;
    }
}

