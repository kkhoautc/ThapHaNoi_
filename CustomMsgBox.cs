using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi
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

                msgForm.BackColor = Color.Gold; // Màu này sẽ đóng vai trò làm viền ngoài (Border)
                msgForm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền Windows
                msgForm.StartPosition = FormStartPosition.CenterParent;
                msgForm.ShowInTaskbar = false;

                // 2. PANEL NỀN (Tạo hiệu ứng viền bằng cách lùi vào 2px)
                Panel mainPanel = new Panel();
                mainPanel.Size = new Size(msgForm.Width - 4, msgForm.Height - 4);
                mainPanel.Location = new Point(2, 2);
                mainPanel.BackColor = Color.FromArgb(23, 21, 32); // Màu nền tối đặc trưng của game
                msgForm.Controls.Add(mainPanel);

                // 3. THANH TIÊU ĐỀ (Header)
                Panel headerPanel = new Panel();
                headerPanel.Size = new Size(mainPanel.Width, 40);
                headerPanel.Dock = DockStyle.Top;
                headerPanel.BackColor = Color.FromArgb(45, 45, 50);
                mainPanel.Controls.Add(headerPanel);

                Label lblTitle = new Label();
                lblTitle.Text = title.ToUpper(); // Viết hoa toàn bộ cho chuyên nghiệp
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

                // 5. NÚT BẤM (Thiết kế kiểu nút bấm trong game)
                btnOk.Text = "TIẾP TỤC";
                btnOk.Size = new Size(160, 45);
               
                btnOk.BackColor = Color.FromArgb(0, 150, 136); // Màu xanh Teal nổi bật
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
    }
   
}
