using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi.Manager
{
    public static class CustomMsgBox
    {
        // Hàm này sẽ đóng giả làm MessageBox.Show()
        public static void Show(string message, string title = "Congratulations",string form = "")
        {
            using (Form msgForm = new Form())
            {
                // 1. CẤU HÌNH FORM CHÍNH
                Button btnOk = new Button();

                Label lblMessage = new Label();
                if (form == "Player")
                {
                    msgForm.Size = new Size(600, 450);
                    btnOk.Location = new Point((600 - 160) / 2, 375);
                    lblMessage.Size = new Size(600 - 20, 300);
                }
                else
                {
                    msgForm.Size = new Size(400, 300);
                    btnOk.Location = new Point((400 - 160) / 2, 220);
                    lblMessage.Size = new Size(400 - 20, 165);
                }

                msgForm.BackColor = Color.Gold;
                msgForm.FormBorderStyle = FormBorderStyle.None; 
                msgForm.StartPosition = FormStartPosition.CenterParent;
                msgForm.ShowInTaskbar = false;

                // panel
                Panel mainPanel = new Panel();
                mainPanel.Size = new Size(msgForm.Width - 4, msgForm.Height - 4);
                mainPanel.Location = new Point(2, 2);
                mainPanel.BackColor = Color.FromArgb(23, 21, 32); 
                msgForm.Controls.Add(mainPanel);

                // 3. THANH TIÊU ĐỀ (Header)
                Panel headerPanel = new Panel();
                headerPanel.Size = new Size(mainPanel.Width, 40);
                headerPanel.Dock = DockStyle.Top;
                headerPanel.BackColor = Color.FromArgb(45, 45, 50);
                mainPanel.Controls.Add(headerPanel);

                Label lblTitle = new Label();
                lblTitle.Text = title.ToUpper(); 
                lblTitle.ForeColor = Color.Gold;
                lblTitle.Font = new Font("Segoe UI Black", 14, FontStyle.Bold);
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                lblTitle.Dock = DockStyle.Fill;
                headerPanel.Controls.Add(lblTitle);

                // 4. NỘI DUNG THÔNG BÁO
                lblMessage.Text = message;
                lblMessage.ForeColor = Color.White;
                lblMessage.Font = new Font("Segoe UI Semibold", 24, FontStyle.Regular);
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Location = new Point(10, 60);
                mainPanel.Controls.Add(lblMessage);

              
                btnOk.Text = "TIẾP TỤC";
                btnOk.Size = new Size(160, 45);
               
                btnOk.BackColor = Color.FromArgb(0, 150, 136); 
                btnOk.ForeColor = Color.White;
                btnOk.FlatStyle = FlatStyle.Flat;
                btnOk.FlatAppearance.BorderSize = 0;
                btnOk.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btnOk.Cursor = Cursors.Hand;

                // Hiệu ứng khi rê chuột vào nút
                btnOk.MouseEnter += (s, e) => btnOk.BackColor = Color.FromArgb(0, 180, 160);
                btnOk.MouseLeave += (s, e) => btnOk.BackColor = Color.FromArgb(0, 150, 136);

                btnOk.DialogResult = DialogResult.OK;
                mainPanel.Controls.Add(btnOk);

                // 6. HIỂN THỊ
                msgForm.ShowDialog();
            }
        }
        public static void ShowLeaderboard(System.Data.DataTable dt, string title = "")
        {
            using (Form msgForm = new Form())
            {
                msgForm.Size = new Size(600, 450);
                msgForm.BackColor = Color.Gold;
                msgForm.FormBorderStyle = FormBorderStyle.None;
                msgForm.StartPosition = FormStartPosition.CenterParent;

                Panel mainPanel = new Panel
                {
                    Size = new Size(msgForm.Width - 4, msgForm.Height - 4),
                    Location = new Point(2, 2),
                    BackColor = Color.FromArgb(23, 21, 32)
                };
                msgForm.Controls.Add(mainPanel);

                // 1. Tiêu đề (Header)
                Label lblTitle = new Label
                {
                    Text = title.ToUpper(),
                    ForeColor = Color.Gold,
                    Font = new Font("Segoe UI Black", 16, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top,
                    Height = 60
                };
                mainPanel.Controls.Add(lblTitle);

                // 2. Bảng dữ liệu (DataGridView)
                DataGridView dgv = new DataGridView
                {
                    DataSource = dt,
                    Size = new Size(mainPanel.Width - 40, 260),
                    Location = new Point(20, 70),
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    BorderStyle = BorderStyle.None,
                    BackgroundColor = Color.FromArgb(30, 30, 35)
                };

                // Style cho bảng để hợp với Game
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 50);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 50);
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 40);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 65);
                dgv.GridColor = Color.FromArgb(50, 50, 55);

                mainPanel.Controls.Add(dgv);

               
                Button btnClose = new Button
                {
                    Text = "ĐÓNG",
                    Size = new Size(150, 45),
                    Location = new Point((mainPanel.Width - 150) / 2, 350),
                    BackColor = Color.Crimson,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => msgForm.Close();
                mainPanel.Controls.Add(btnClose);

                msgForm.ShowDialog();
            }
        }
        public static void ShowImage(string message, string title = "")
        {
            using (Form msgForm = new Form())
            {

                Color themeColor = Color.Gold;
              

                msgForm.Size = new Size(450, 700);
                msgForm.BackColor = themeColor;
                msgForm.FormBorderStyle = FormBorderStyle.None;
                msgForm.StartPosition = FormStartPosition.CenterParent;

                Panel mainPanel = new Panel { Size = new Size(446, 776), Location = new Point(2, 2), BackColor = Color.FromArgb(30, 30, 35) };
                msgForm.Controls.Add(mainPanel);

                // 1. Tiêu đề
                Label lblTitle = new Label { Text = title.ToUpper(), ForeColor = themeColor, Font = new Font("Segoe UI Black", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 45 };
                mainPanel.Controls.Add(lblTitle);

                // 2. Khu vực chứa Ảnh (PictureBox)
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Properties.Resources.qr;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Tự động co giãn ảnh cho vừa khung hình mà không bị méo
                pictureBox.Size = new Size(400, 400); // Kích thước khung ảnh
                pictureBox.Location = new Point((mainPanel.Width - 400) / 2, 55); // Căn giữa
                pictureBox.BackColor = Color.FromArgb(20, 20, 25);
                mainPanel.Controls.Add(pictureBox);

                Label lblMessage = new Label { Text = message, ForeColor = Color.White, Font = new Font("Segoe UI", 15), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(10, 500), Size = new Size(426, 80) };
                mainPanel.Controls.Add(lblMessage);

                // 4. Nút bấm ĐỒNG Ý
                Button btnOk = new Button
                {
                    Text = "ĐỒNG Ý",
                    Size = new Size(200, 45),
                    Location = new Point((mainPanel.Width - 200) / 2, 600),
                    BackColor = themeColor,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnOk.FlatAppearance.BorderSize = 0;
                btnOk.DialogResult = DialogResult.OK;
                mainPanel.Controls.Add(btnOk);

                msgForm.ShowDialog();
            }
        }
    }
   
}
