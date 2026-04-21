using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ThapHaNoi.Manager;
using ThapHaNoi.Model;
using static ThapHaNoi.FormGame;

namespace ThapHaNoi
{
    public partial class FormMenu : Form
    {

        private int toastCounter = 0;
        private Panel panelLeaderboard;
        private DataGridView dgvLeaderboard;
        public FormMenu()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SoundManager.InitSounds();
            SoundManager.PlaySound();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundManager.StopSound();
            FormGame formgame = new FormGame(FormGame.GameMode.Manual);
            this.Hide();
            formgame.Show();

            formgame.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void btnAISolver_Click(object sender, EventArgs e)
        {

            SoundManager.StopSound();
            FormGame formgame = new FormGame(FormGame.GameMode.AISolve);
            this.Hide();
            formgame.Show();

            formgame.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            panelHuongDan.Visible = true;
            btnCloseHuongDan.Visible = true;

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var data = DatabaseManager.GetTopScores();

            CustomMsgBox.ShowLeaderboard(data, "Leaderboard");
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.TowerCount = (int)numTowersMenu.Value;
            Config.DiskCount = (int)numDisksMenu.Value;

            
            panelConfig.Visible = false;
           // ShowToastNotification("Đã lưu cấu hình!");
            CustomMsgBox.Show($"Đã lưu cấu hình!", "Độ khó", "AI");
        }


        private void btnDokho_Click(object sender, EventArgs e)
        {
            panelConfig.Visible = true;
            panelConfig.BringToFront();
            numTowersMenu.Value = Config.TowerCount;
            numDisksMenu.Value = Config.DiskCount;
        }

        private async void ShowToastNotification(string message)
        {
            int currentToast = ++toastCounter;

            lblToast.Text = message;
            lblToast.Visible = true;
            lblToast.BringToFront();

            await Task.Delay(5000);

            if (toastCounter == currentToast)
            {
                lblToast.Visible = false;
            }
        }

        private void btnCloseHuongDan_Click(object sender, EventArgs e)
        {
            btnCloseHuongDan.Visible = false;
            panelHuongDan.Visible = false ;
        }
        
    }
}
