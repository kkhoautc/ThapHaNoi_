namespace ThapHaNoi
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            btnPlay = new Button();
            btnAISolver = new Button();
            btnHuongDan = new Button();
            btnSetting = new Button();
            panelConfig = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnSave = new Button();
            numDisksMenu = new NumericUpDown();
            numTowersMenu = new NumericUpDown();
            btnDokho = new Button();
            lblToast = new Label();
            panelHuongDan = new Panel();
            btnCloseHuongDan = new Button();
            panelConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDisksMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTowersMenu).BeginInit();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.BackgroundImage = Properties.Resources.btnPlay;
            btnPlay.BackgroundImageLayout = ImageLayout.Stretch;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.ForeColor = SystemColors.ControlLightLight;
            btnPlay.Location = new Point(967, 185);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(272, 76);
            btnPlay.TabIndex = 0;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnAISolver
            // 
            btnAISolver.BackgroundImage = Properties.Resources.AiGiai;
            btnAISolver.BackgroundImageLayout = ImageLayout.Stretch;
            btnAISolver.FlatAppearance.BorderSize = 0;
            btnAISolver.FlatStyle = FlatStyle.Flat;
            btnAISolver.Location = new Point(967, 267);
            btnAISolver.Name = "btnAISolver";
            btnAISolver.Size = new Size(272, 76);
            btnAISolver.TabIndex = 1;
            btnAISolver.UseVisualStyleBackColor = true;
            btnAISolver.Click += btnAISolver_Click;
            // 
            // btnHuongDan
            // 
            btnHuongDan.BackgroundImage = Properties.Resources.HuongDan;
            btnHuongDan.BackgroundImageLayout = ImageLayout.Stretch;
            btnHuongDan.FlatAppearance.BorderSize = 0;
            btnHuongDan.FlatStyle = FlatStyle.Flat;
            btnHuongDan.Location = new Point(967, 431);
            btnHuongDan.Name = "btnHuongDan";
            btnHuongDan.Size = new Size(272, 76);
            btnHuongDan.TabIndex = 2;
            btnHuongDan.UseVisualStyleBackColor = true;
            btnHuongDan.Click += btnHuongDan_Click;
            // 
            // btnSetting
            // 
            btnSetting.BackgroundImage = Properties.Resources.btnThanhtich;
            btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Location = new Point(967, 513);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(272, 76);
            btnSetting.TabIndex = 3;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // panelConfig
            // 
            panelConfig.BackColor = Color.FromArgb(243, 254, 255);
            panelConfig.BackgroundImage = Properties.Resources.bgDokho;
            panelConfig.BackgroundImageLayout = ImageLayout.Stretch;
            panelConfig.Controls.Add(label2);
            panelConfig.Controls.Add(label1);
            panelConfig.Controls.Add(btnSave);
            panelConfig.Controls.Add(numDisksMenu);
            panelConfig.Controls.Add(numTowersMenu);
            panelConfig.Location = new Point(546, 123);
            panelConfig.Name = "panelConfig";
            panelConfig.Size = new Size(387, 491);
            panelConfig.TabIndex = 4;
            panelConfig.Visible = false;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(255, 232, 165);
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(66, 194);
            label2.Name = "label2";
            label2.Size = new Size(99, 50);
            label2.TabIndex = 4;
            label2.Text = "Đĩa :";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 232, 165);
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(66, 113);
            label1.Name = "label1";
            label1.Size = new Size(99, 50);
            label1.TabIndex = 3;
            label1.Text = "Cột :";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.BackgroundImage = Properties.Resources.Save;
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(134, 326);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 65);
            btnSave.TabIndex = 2;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // numDisksMenu
            // 
            numDisksMenu.BackColor = Color.FromArgb(255, 232, 165);
            numDisksMenu.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numDisksMenu.Location = new Point(183, 195);
            numDisksMenu.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numDisksMenu.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numDisksMenu.Name = "numDisksMenu";
            numDisksMenu.ReadOnly = true;
            numDisksMenu.Size = new Size(146, 50);
            numDisksMenu.TabIndex = 1;
            numDisksMenu.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // numTowersMenu
            // 
            numTowersMenu.BackColor = Color.FromArgb(255, 232, 165);
            numTowersMenu.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numTowersMenu.Location = new Point(183, 113);
            numTowersMenu.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numTowersMenu.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numTowersMenu.Name = "numTowersMenu";
            numTowersMenu.ReadOnly = true;
            numTowersMenu.Size = new Size(146, 50);
            numTowersMenu.TabIndex = 0;
            numTowersMenu.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnDokho
            // 
            btnDokho.BackgroundImage = Properties.Resources.btndokho;
            btnDokho.BackgroundImageLayout = ImageLayout.Stretch;
            btnDokho.FlatAppearance.BorderSize = 0;
            btnDokho.FlatStyle = FlatStyle.Flat;
            btnDokho.Location = new Point(967, 349);
            btnDokho.Name = "btnDokho";
            btnDokho.Size = new Size(272, 76);
            btnDokho.TabIndex = 5;
            btnDokho.UseVisualStyleBackColor = true;
            btnDokho.Click += btnDokho_Click;
            // 
            // lblToast
            // 
            lblToast.BackColor = Color.FromArgb(122, 202, 239);
            lblToast.Font = new Font("Segoe UI", 30F);
            lblToast.ForeColor = Color.Red;
            lblToast.Location = new Point(981, 30);
            lblToast.Name = "lblToast";
            lblToast.Size = new Size(374, 106);
            lblToast.TabIndex = 5;
            lblToast.TextAlign = ContentAlignment.MiddleCenter;
            lblToast.Visible = false;
            // 
            // panelHuongDan
            // 
            panelHuongDan.BackgroundImage = Properties.Resources.ScreenHuongDan;
            panelHuongDan.BackgroundImageLayout = ImageLayout.Stretch;
            panelHuongDan.Location = new Point(190, 75);
            panelHuongDan.Name = "panelHuongDan";
            panelHuongDan.Size = new Size(1000, 600);
            panelHuongDan.TabIndex = 6;
            panelHuongDan.Visible = false;
            // 
            // btnCloseHuongDan
            // 
            btnCloseHuongDan.BackColor = Color.FromArgb(255, 232, 165);
            btnCloseHuongDan.BackgroundImage = Properties.Resources.btnBack;
            btnCloseHuongDan.BackgroundImageLayout = ImageLayout.Stretch;
            btnCloseHuongDan.FlatAppearance.BorderSize = 0;
            btnCloseHuongDan.FlatStyle = FlatStyle.Flat;
            btnCloseHuongDan.Location = new Point(628, 689);
            btnCloseHuongDan.Name = "btnCloseHuongDan";
            btnCloseHuongDan.Size = new Size(127, 60);
            btnCloseHuongDan.TabIndex = 7;
            btnCloseHuongDan.UseVisualStyleBackColor = false;
            btnCloseHuongDan.Visible = false;
            btnCloseHuongDan.Click += btnCloseHuongDan_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1384, 761);
            Controls.Add(btnCloseHuongDan);
            Controls.Add(panelHuongDan);
            Controls.Add(lblToast);
            Controls.Add(btnDokho);
            Controls.Add(panelConfig);
            Controls.Add(btnSetting);
            Controls.Add(btnHuongDan);
            Controls.Add(btnAISolver);
            Controls.Add(btnPlay);
            DoubleBuffered = true;
            Name = "FormMenu";
            Text = "FormMenu";
            FormClosed += FormMenu_FormClosed;
            panelConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDisksMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTowersMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlay;
        private Button btnAISolver;
        private Button btnHuongDan;
        private Button btnSetting;
        private Panel panelConfig;
        private NumericUpDown numTowersMenu;
        private Button btnSave;
        private NumericUpDown numDisksMenu;
        private Label label1;
        private Label label2;
        private Button btnDokho;
        private Label lblToast;
        private Panel panelHuongDan;
        private Button btnCloseHuongDan;
    }
}