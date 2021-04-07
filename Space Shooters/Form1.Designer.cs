namespace Space_Shooters
{
    partial class spaceShooters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spaceShooters));
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.survivedLabel = new System.Windows.Forms.Label();
            this.player1Score = new System.Windows.Forms.Label();
            this.player2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.GameEngine_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("mono 07_65", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titleLabel.Location = new System.Drawing.Point(110, 78);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(680, 86);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "SPACE SHOOTERS";
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subTitleLabel.Font = new System.Drawing.Font("mono 07_65", 12F);
            this.subTitleLabel.ForeColor = System.Drawing.Color.White;
            this.subTitleLabel.Location = new System.Drawing.Point(22, 143);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(739, 244);
            this.subTitleLabel.TabIndex = 2;
            this.subTitleLabel.Text = "Press Space to Play or Escape to Exit Game";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerLabel
            // 
            this.timerLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerLabel.Font = new System.Drawing.Font("mono 07_66", 9F);
            this.timerLabel.ForeColor = System.Drawing.Color.White;
            this.timerLabel.Location = new System.Drawing.Point(359, 9);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(145, 37);
            this.timerLabel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // survivedLabel
            // 
            this.survivedLabel.BackColor = System.Drawing.Color.Transparent;
            this.survivedLabel.Font = new System.Drawing.Font("mono 07_66", 9F);
            this.survivedLabel.ForeColor = System.Drawing.Color.White;
            this.survivedLabel.Location = new System.Drawing.Point(166, 1);
            this.survivedLabel.Name = "survivedLabel";
            this.survivedLabel.Size = new System.Drawing.Size(196, 32);
            this.survivedLabel.TabIndex = 4;
            this.survivedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1Score
            // 
            this.player1Score.BackColor = System.Drawing.Color.Transparent;
            this.player1Score.Font = new System.Drawing.Font("mono 08_56", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Score.ForeColor = System.Drawing.Color.White;
            this.player1Score.Location = new System.Drawing.Point(12, 9);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(80, 99);
            this.player1Score.TabIndex = 5;
            // 
            // player2Score
            // 
            this.player2Score.BackColor = System.Drawing.Color.Transparent;
            this.player2Score.Font = new System.Drawing.Font("mono 08_56", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Score.ForeColor = System.Drawing.Color.White;
            this.player2Score.Location = new System.Drawing.Point(710, 9);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(80, 99);
            this.player2Score.TabIndex = 6;
            // 
            // spaceShooters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(802, 396);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.survivedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.subTitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "spaceShooters";
            this.Text = "Space Shooters";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceShooters_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceShooters_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceShooters_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label survivedLabel;
        private System.Windows.Forms.Label player1Score;
        private System.Windows.Forms.Label player2Score;
    }
}

