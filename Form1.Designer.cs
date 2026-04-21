namespace ThapHaNoi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUndo = new Button();
            btnRedo = new Button();
            btnSettings = new Button();
            panelSettings = new Panel();
            button3 = new Button();
            btnReplayGame = new Button();
            btnHomeGame = new Button();
            lbCheDo = new Label();
            lbCount = new Label();
            lbTime = new Label();
            lbStopContinue = new Label();
            lbScoreUI = new Button();
            lbScore = new Label();
            panelSettings.SuspendLayout();
            SuspendLayout();
            // 
            // btnUndo
            // 
            btnUndo.BackgroundImage = Properties.Resources.Undo;
            btnUndo.BackgroundImageLayout = ImageLayout.Stretch;
            btnUndo.FlatAppearance.BorderSize = 0;
            btnUndo.FlatStyle = FlatStyle.Flat;
            btnUndo.Location = new Point(1034, 227);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(272, 76);
            btnUndo.TabIndex = 0;
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnRedo
            // 
            btnRedo.BackgroundImage = Properties.Resources.Redo;
            btnRedo.BackgroundImageLayout = ImageLayout.Stretch;
            btnRedo.FlatAppearance.BorderSize = 0;
            btnRedo.FlatStyle = FlatStyle.Flat;
            btnRedo.Location = new Point(1034, 309);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(272, 76);
            btnRedo.TabIndex = 1;
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(255, 192, 128);
            btnSettings.BackgroundImage = Properties.Resources.btnSetting2;
            btnSettings.BackgroundImageLayout = ImageLayout.Stretch;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = SystemColors.ControlText;
            btnSettings.Location = new Point(1263, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(70, 70);
            btnSettings.TabIndex = 2;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.FromArgb(178, 235, 253);
            panelSettings.BackgroundImage = Properties.Resources.settingbackground;
            panelSettings.BackgroundImageLayout = ImageLayout.Stretch;
            panelSettings.Controls.Add(button3);
            panelSettings.Controls.Add(btnReplayGame);
            panelSettings.Controls.Add(btnHomeGame);
            panelSettings.Location = new Point(460, 128);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(387, 491);
            panelSettings.TabIndex = 4;
            panelSettings.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 232, 165);
            button3.BackgroundImage = Properties.Resources.btnResume1;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(135, 353);
            button3.Name = "button3";
            button3.Size = new Size(127, 60);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnReplayGame
            // 
            btnReplayGame.BackColor = Color.FromArgb(255, 232, 165);
            btnReplayGame.BackgroundImage = Properties.Resources.btnReplay1;
            btnReplayGame.BackgroundImageLayout = ImageLayout.Stretch;
            btnReplayGame.FlatAppearance.BorderSize = 0;
            btnReplayGame.FlatStyle = FlatStyle.Flat;
            btnReplayGame.Location = new Point(220, 109);
            btnReplayGame.Name = "btnReplayGame";
            btnReplayGame.Size = new Size(75, 75);
            btnReplayGame.TabIndex = 1;
            btnReplayGame.UseVisualStyleBackColor = false;
            btnReplayGame.Click += btnReplayGame_Click;
            // 
            // btnHomeGame
            // 
            btnHomeGame.BackColor = Color.FromArgb(255, 232, 165);
            btnHomeGame.BackgroundImage = Properties.Resources.btnHome1;
            btnHomeGame.BackgroundImageLayout = ImageLayout.Stretch;
            btnHomeGame.FlatAppearance.BorderSize = 0;
            btnHomeGame.FlatStyle = FlatStyle.Flat;
            btnHomeGame.ImageAlign = ContentAlignment.BottomLeft;
            btnHomeGame.Location = new Point(103, 109);
            btnHomeGame.Margin = new Padding(0);
            btnHomeGame.Name = "btnHomeGame";
            btnHomeGame.Size = new Size(75, 75);
            btnHomeGame.TabIndex = 0;
            btnHomeGame.UseVisualStyleBackColor = false;
            btnHomeGame.Click += btnHomeGame_Click;
            // 
            // lbCheDo
            // 
            lbCheDo.BackColor = Color.FromArgb(122, 202, 239);
            lbCheDo.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCheDo.Location = new Point(988, 128);
            lbCheDo.Name = "lbCheDo";
            lbCheDo.Size = new Size(355, 47);
            lbCheDo.TabIndex = 3;
            lbCheDo.TextAlign = ContentAlignment.MiddleCenter;
            lbCheDo.Click += lblStats_Click;
            // 
            // lbCount
            // 
            lbCount.BackColor = Color.FromArgb(236, 210, 187);
            lbCount.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCount.Location = new Point(158, 24);
            lbCount.Name = "lbCount";
            lbCount.Size = new Size(72, 47);
            lbCount.TabIndex = 5;
            lbCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTime
            // 
            lbTime.BackColor = Color.FromArgb(236, 210, 187);
            lbTime.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTime.Location = new Point(342, 24);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(149, 47);
            lbTime.TabIndex = 6;
            lbTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbStopContinue
            // 
            lbStopContinue.BackColor = Color.FromArgb(209, 239, 249);
            lbStopContinue.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbStopContinue.ForeColor = Color.Red;
            lbStopContinue.Location = new Point(988, 422);
            lbStopContinue.Name = "lbStopContinue";
            lbStopContinue.Size = new Size(355, 145);
            lbStopContinue.TabIndex = 7;
            lbStopContinue.Text = "Nhấn phím Space để tạm dừng !";
            lbStopContinue.TextAlign = ContentAlignment.MiddleCenter;
            lbStopContinue.Visible = false;
            // 
            // lbScoreUI
            // 
            lbScoreUI.BackColor = Color.FromArgb(178, 235, 253);
            lbScoreUI.BackgroundImage = Properties.Resources.imgScore;
            lbScoreUI.BackgroundImageLayout = ImageLayout.Stretch;
            lbScoreUI.Enabled = false;
            lbScoreUI.FlatAppearance.BorderSize = 0;
            lbScoreUI.FlatStyle = FlatStyle.Flat;
            lbScoreUI.ImageAlign = ContentAlignment.BottomLeft;
            lbScoreUI.Location = new Point(31, 128);
            lbScoreUI.Margin = new Padding(0);
            lbScoreUI.Name = "lbScoreUI";
            lbScoreUI.Size = new Size(218, 107);
            lbScoreUI.TabIndex = 8;
            lbScoreUI.UseVisualStyleBackColor = false;
            // 
            // lbScore
            // 
            lbScore.BackColor = Color.FromArgb(243, 116, 49);
            lbScore.Font = new Font("Segoe UI", 26F);
            lbScore.ForeColor = Color.White;
            lbScore.Location = new Point(111, 160);
            lbScore.Name = "lbScore";
            lbScore.Size = new Size(109, 55);
            lbScore.TabIndex = 9;
            lbScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.form1background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1384, 761);
            Controls.Add(lbScore);
            Controls.Add(lbScoreUI);
            Controls.Add(lbStopContinue);
            Controls.Add(panelSettings);
            Controls.Add(lbTime);
            Controls.Add(lbCount);
            Controls.Add(lbCheDo);
            Controls.Add(btnSettings);
            Controls.Add(btnRedo);
            Controls.Add(btnUndo);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            MouseClick += Form1_MouseClick;
            panelSettings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnUndo;
        private Button btnRedo;
        private Button btnSettings;
        private Panel panelSettings;
        private Label lbCheDo;
        private Label lbCount;
        private Label lbTime;
        private Button btnHomeGame;
        private Button button3;
        private Button btnReplayGame;
        private Label lbStopContinue;
        private Button lbScoreUI;
        private Label lbScore;
    }
}
