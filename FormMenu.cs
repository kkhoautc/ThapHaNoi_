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
using ThapHaNoi.Model;

namespace ThapHaNoi
{
    public partial class FormMenu : Form
    {
        
        private int toastCounter = 0;

        public FormMenu()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(Form1.GameMode.Manual);
            this.Hide();
            form1.Show();

            form1.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void btnAISolver_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(Form1.GameMode.AISolve);
            this.Hide();
            form1.Show();

            form1.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

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

            // Ẩn panel đi
            panelConfig.Visible = false;
        //    MessageBox.Show("Đã lưu cấu hình!");
            ShowToastNotification("Đã lưu cấu hình!");
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
            // 1. Tăng bộ đếm mỗi lần gọi hàm mới
            int currentToast = ++toastCounter;

            // 2. Cập nhật chữ và hiện Label lên
            lblToast.Text = message;
            lblToast.Visible = true;
            lblToast.BringToFront();

            // 3. Chờ đúng 5 giây (5000 mili-giây) mà KHÔNG làm đơ game
            await Task.Delay(5000);

            // 4. Sau 5 giây, chỉ tắt Label nếu không có thông báo mới nào chèn vào
            if (toastCounter == currentToast)
            {
                lblToast.Visible = false;
            }
        }
    }
}
