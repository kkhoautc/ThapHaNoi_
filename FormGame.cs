using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Forms;
using System.Xml.Linq;
using ThapHaNoi.GameLogic;
using ThapHaNoi.Manager;
using ThapHaNoi.Model;
using ThapHaNoi.Models;
using static System.Net.Mime.MediaTypeNames;
namespace ThapHaNoi
{
    public partial class FormGame : Form
    {
        private HanoiGame game;
        private int selectedTower = -1;
        // Dành cho AI Solver
        private List<HanoiState> aiSteps;
        private int currentStepIndex = 0;
        private System.Windows.Forms.Timer aiTimer;
        private GameMode _mode;

        private const int MAX_GAME_TIME = 300;

        public int moveCount = 0;
        private int timeSeconds = 0;

        string stateSound = "sound";

        private int minMoves = 0;

        private int score = 100;

        private System.Windows.Forms.Timer gameTimer;

        // private Panel panelSettings; // Vùng menu ẩn


        public enum GameMode
        {
            Manual, // Chơi thủ công bằng chuột/phím
            AISolve // AI tự động chạy
        }

        public FormGame(GameMode mode)
        {
            InitializeComponent();
            DatabaseManager.InitializeDatabase();
            SoundManager.InitSounds();

            this.DoubleBuffered = true;
            this.KeyPreview = true; // QUAN TRỌNG: Để Form nhận được sự kiện phím
            this._mode = mode;
            this.Text = "Tháp Hà Nội";

            




            this.StartPosition = FormStartPosition.CenterScreen;
            SetupGameUI(); 
            SetupSettingsPanel();
            StartGame();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (_mode == GameMode.AISolve)
            {
                // Vô hiệu hóa click chuột để người dùng không can thiệp khi AI đang chạy
                this.MouseClick -= Form1_MouseClick;
                this.btnUndo.Visible = false;
                this.btnRedo.Visible = false;
                this.lbStopContinue.Visible = true;
                this.lbScoreUI.Visible = false;
                this.lbScore.Visible = false;

                // Bắt đầu giải AI ngay lập tức
                RunAISolver();
            }
        }
        private void SetupGameUI()
        {
            // 1. Thiết lập Timer
            aiTimer = new System.Windows.Forms.Timer();
            aiTimer.Interval = 700; // Tốc độ AI di chuyển
            aiTimer.Tick += AiTimer_Tick;

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();

            // 2. Thiết lập Menu Cài đặt


            // 3. Label hiển thị thông số (Thêm vào Form)


            UpdateStatusLabel();
        }

        private void SetupSettingsPanel()
        {
            // 1. Tạo Panel bao quanh



            panelSettings.Location = new Point((this.ClientSize.Width - panelSettings.Width) / 2,
                                               (this.ClientSize.Height - panelSettings.Height) / 2);
            panelSettings.Visible = false; // Mặc định bị ẩn
            this.Controls.Add(panelSettings);
            panelSettings.BringToFront();



        }

        // Hàm hỗ trợ tạo nút bấm nhanh cho Menu

        private int GetOptimalMoves(int towers, int disks)
        {
            // Ràng buộc an toàn: Nếu số đĩa quá nhỏ
            if (disks < 3) return (disks == 1) ? 1 : 3;

            if (towers == 3)
            {
                switch (disks)
                {
                    case 3: return 7;
                    case 4: return 15;
                    case 5: return 31;
                    case 6: return 63;
                    case 7: return 127;
                    default: return 0; // Tránh lỗi nếu nhập ngoài vùng
                }
            }
            else if (towers == 4)
            {
                switch (disks)
                {
                    case 3: return 5;
                    case 4: return 9;
                    case 5: return 13;
                    case 6: return 17;
                    case 7: return 25;
                    default: return 0;
                }
            }
            else if (towers == 5)
            {
                switch (disks)
                {
                    case 3: return 5;
                    case 4: return 7;
                    case 5: return 11;
                    case 6: return 15;
                    case 7: return 19;
                    default: return 0;
                }
            }

            return 0; // Trả về 0 nếu các điều kiện trên không khớp
        }
        private void UpdateStatusLabel()
        {
            int penaltyPerMove = 5;
            score = 100;

            if (moveCount > minMoves)
            {
                score = 100 - (moveCount - minMoves) * penaltyPerMove;
            }

            // Đảm bảo điểm không bao giờ bị âm
            if (score < 0) score = 0;

            lbScore.Text = $"{score}";

            lbminMove.Text = $"Số bước tối thiểu : {minMoves}";

            lbCheDo.Text = $"Chế độ: {(_mode == GameMode.Manual ? "Người chơi" : "AI Solver")}";
            lbCount.Text = $"{moveCount}";
            lbTime.Text = $"{timeSeconds}s";

        }
        private void RunAISolver()
        {
            int towers = Config.TowerCount;
            int disks = Config.DiskCount;
            aiSteps = HanoiSolver.SolveBFS(towers, disks);
            if (aiSteps != null)
            {
                currentStepIndex = 0;
                aiTimer.Start();
            }
        }
        private void StartGame()
        {
            int towers = Config.TowerCount;
            int disks = Config.DiskCount;

            minMoves = GetOptimalMoves(towers, disks);

            game = new HanoiGame(towers, disks);
            selectedTower = -1;
            UpdateStatusLabel();
            this.Invalidate();
        }
        private void RestartGame()
        {
            game.ResetGame();
            moveCount = 0;
            timeSeconds = 0;
            UpdateStatusLabel();
            Invalidate();
        }
        // Tách logic xử lý chọn cột ra để dùng chung cho cả Chuột và Phím
        private void HandleTowerSelection(int towerIndex)
        {
            if (towerIndex < 0 || towerIndex >= game.Towers.Count || _mode == GameMode.AISolve) return;

            if (selectedTower == -1)
            {
                // Bước 1: Chọn cột (chỉ chọn nếu cột có đĩa)
                if (game.Towers[towerIndex].Disks.Count > 0)
                {
                    selectedTower = towerIndex;
                }
            }
            else
            {
                // Bước 2: Di chuyển từ cột cũ sang cột mới
                if (game.Move(selectedTower, towerIndex))
                {
                    moveCount++;
                    UpdateStatusLabel();
                    SoundManager.PlayMove();

                    // Kiểm tra thắng cuộc (Đĩa dồn hết về cột cuối)
                    if (game.Towers[Config.TowerCount-1].Disks.Count == game.NumDisks)
                    {
                        this.Invalidate();
                        gameTimer.Stop();
                        string modeStr = $"{Config.TowerCount} Cột - {Config.DiskCount} Đĩa";

                        // LƯU VÀO DATABASE NẾU LÀ NGƯỜI CHƠI (Không lưu điểm của AI)
                        if (_mode == GameMode.Manual)
                        {
                            DatabaseManager.SaveScore(modeStr, moveCount, timeSeconds, score);
                        }
                        SoundManager.PlayWin();
                        CustomMsgBox.Show($"Chúc mừng!\nBạn đã thắng trong {moveCount} bước\nĐiểm của bạn : {score}\nThời gian : {timeSeconds} giây\nĐã lưu vào thành tích của bạn !", "Congratulations", "Player");

                        RestartGame();
                    }
                }
                else
                {
                    SoundManager.PlayError();
                }
                    selectedTower = -1;
            }
            this.Invalidate();
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                // Chỉ xử lý nếu đang ở chế độ AI và AI đã bắt đầu (có danh sách bước đi)
                if (_mode == GameMode.AISolve && aiSteps != null)
                {
                    if (aiTimer.Enabled)
                    {
                        aiTimer.Stop();
                        gameTimer.Stop();
                        lbStopContinue.Text = $"Nhấn phím Space để tiếp tục !";

                    }
                    else
                    {
                        // Nếu đang dừng -> Nhấn Space để giải tiếp
                        if (currentStepIndex < aiSteps.Count)
                        {
                            aiTimer.Start();
                            gameTimer.Start();
                            lbStopContinue.Text = $"Nhấn phím Space để tạm dừng !";
                            UpdateStatusLabel();

                        }
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // Xử lý khi nhấn phím 1, 2, 3 (cả phím số hàng trên và phím NumPad)
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) HandleTowerSelection(0);
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) HandleTowerSelection(1);
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) HandleTowerSelection(2);
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) HandleTowerSelection(3);
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5) HandleTowerSelection(4);
            // Phím R để chơi lại
            if (e.KeyCode == Keys.R) StartGame();

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 950)
            {
                int gameAreaWidth = 950;
                int towerCount = game.Towers.Count;

                int towerZoneWidth = gameAreaWidth / towerCount;

                int clickedTower = e.X / towerZoneWidth;

                if (clickedTower >= towerCount) clickedTower = towerCount - 1;


                HandleTowerSelection(clickedTower);
            }
        }
        private void DrawRoundedRectangle(Graphics g, Brush brush, Rectangle bounds, int radius, bool drawVien = true)
        {
            if (radius <= 0)
            {
                g.FillRectangle(brush, bounds);
                if (drawVien) g.DrawRectangle(Pens.Black, bounds);
                return;
            }

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            // Thêm 4 góc bo (AddArc) vào Path
            path.AddArc(arc, 180, 90); // Góc trên bên trái
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90); // Góc trên bên phải
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);   // Góc dưới bên phải
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);  // Góc dưới bên trái
            path.CloseFigure();        // Đóng đường vẽ

            // 1. Tô màu đĩa
            g.FillPath(brush, path);

            // 2. Vẽ viền đĩa (tùy chọn)
            if (drawVien)
            {
                using (Pen pen = new Pen(Color.Black, 1.5f)) // Viền đen hơi đậm chút
                {
                    g.DrawPath(pen, path);
                }
            }
        }
        private void DrawGame(Graphics g)
        {
            // --- 1. KHỬ RĂNG CƯA ---
            // Cực kỳ quan trọng để góc bo mượt mà
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // --- 2. LÀM SẠCH NỀN VỚI MÀU TỐI ---

            Brush[] diskBrushes = {
                Brushes.DeepSkyBlue, // Màu cho đĩa 1
                Brushes.SpringGreen,  // Màu cho đĩa 2
                Brushes.Orange,       // Màu cho đĩa 3
                Brushes.Fuchsia,      // Màu cho đĩa 4
                Brushes.Yellow,       // Màu cho đĩa 5
                Brushes.Red           // Màu cho đĩa 6
            };
            int gameAreaWidth = 950;
            int towerCount = game.Towers.Count; // Lấy động số lượng cột

            // Chia đều 950px cho số lượng cột
            int towerZoneWidth = gameAreaWidth / towerCount;
            int baseY = this.ClientSize.Height - 100;

            for (int i = 0; i < towerCount; i++)
            {
                // --- 2. TÍNH TOÁN TỌA ĐỘ TỈ LỆ ---
                // Tâm của mỗi tháp sẽ nằm chính giữa phân vùng của nó
                int centerX = (i * towerZoneWidth) + (towerZoneWidth / 2);

                // Độ rộng đế tháp bằng 80% chiều rộng phân vùng để luôn có khoảng cách giữa các đế
                int baseW = (int)(towerZoneWidth * 0.8);
                int baseX = centerX - (baseW / 2);

                // Vẽ đế tháp
                Rectangle baseBounds = new Rectangle(baseX, baseY, baseW, 20);
                DrawRoundedRectangle(g, Brushes.Gray, baseBounds, 5);

                // Vẽ cột (luôn nằm giữa centerX)
                Brush columnBrush = (selectedTower == i) ? Brushes.Gold : Brushes.Gray;
                g.FillRectangle(columnBrush, centerX - 5, baseY - 250, 10, 250);

                // --- 3. VẼ ĐĨA TỈ LỆ ---
                var disks = game.Towers[i].Disks.ToArray().Reverse().ToArray();
                int y = baseY;

                for (int j = 0; j < disks.Length; j++)
                {
                    var disk = disks[j];

                    // Độ rộng đĩa cũng phải tỉ lệ theo độ rộng phân vùng cột
                    // Đĩa to nhất không được vượt quá 90% độ rộng phân vùng cột
                    double maxDiskWidth = towerZoneWidth * 0.9;
                    int diskWidth = (int)((disk.Size / (double)game.NumDisks) * maxDiskWidth);

                    int diskHeight = 25;

                    Brush diskBrush = diskBrushes[disk.Size % diskBrushes.Length];
                    if (selectedTower == i && j == disks.Length - 1) diskBrush = Brushes.Red;

                    Rectangle diskBounds = new Rectangle(centerX - diskWidth / 2, y - diskHeight, diskWidth, diskHeight);
                    DrawRoundedRectangle(g, diskBrush, diskBounds, 10, true);

                    y -= (diskHeight + 5);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGame(e.Graphics);
        }
        private void AiTimer_Tick(object sender, EventArgs e)
        {
            if (aiSteps != null && currentStepIndex < aiSteps.Count)
            {
                var state = aiSteps[currentStepIndex];

                // Cập nhật các cột đĩa
                for (int i = 0; i < game.Towers.Count; i++)
                {
                    game.Towers[i].Disks.Clear();
                    foreach (int diskSize in state.Columns[i])
                        game.Towers[i].Disks.Push(new Disk(diskSize));
                }

             
                moveCount = currentStepIndex;
                UpdateStatusLabel();          
                                            

                currentStepIndex++;
                Invalidate();
            }
            else
            {
                gameTimer.Stop();
                aiTimer.Stop();
                CustomMsgBox.Show($"AI đã giải trong {moveCount} bước\nThời gian : {timeSeconds} giây", "AI Solver", "AI");
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timeSeconds++;

            if (timeSeconds >= MAX_GAME_TIME)
            {
                gameTimer.Stop();

                SoundManager.PlayError();

                CustomMsgBox.Show("RẤT TIẾC!\nThời gian đã hết. Bạn cần nhanh tay hơn ở lần sau!",
                                  "GAME OVER");

                this.Close();
                return;
            }

            UpdateStatusLabel();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }



        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (game.Undo() != null)
            {
                moveCount--;
                UpdateStatusLabel();

                SoundManager.PlayMove();
                Invalidate();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (game.Redo() != null)
            {
                moveCount++;
                UpdateStatusLabel();
                SoundManager.PlayMove();
                Invalidate();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
       
            panelSettings.Visible = true;


            panelSettings.BringToFront(); 

            //  Tạm dừng game
            StopGame(); 
        }
        public void StopGame()
        {
            if (_mode == GameMode.Manual)
            {
                gameTimer.Stop();
            }
            else
            {
                aiTimer.Stop();
            }
        }
        public void ContinueGame()
        {
            if (_mode == GameMode.Manual)
            {
                gameTimer.Start();
            }
            else
            {
                aiTimer.Start();
            }
        }
        private void lblStats_Click(object sender, EventArgs e)
        {

        }

        private void btnHomeGame_Click(object sender, EventArgs e)
        {
            SoundManager.PlaySound();
            this.Close();
        }

        private void btnReplayGame_Click(object sender, EventArgs e)
        {
            RestartGame();
            panelSettings.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            panelSettings.Visible = false;
            if (_mode == GameMode.Manual)
            {
                gameTimer.Start();
            }
            else
            {
                aiTimer.Start();
            }
        }


        private void btnSound_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            SoundManager.IsSoundEnabled = !SoundManager.IsSoundEnabled;

            if (stateSound == "sound")
            {
                stateSound = "mute";
                btnSound.BackgroundImage = Properties.Resources.btnMute;
                
            }
            else
            {
                stateSound = "sound";
                btnSound.BackgroundImage = Properties.Resources.btnSound;
                SoundManager.setEnable(true);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomMsgBox.ShowImage("Cảm ơn sự đóng góp của các bạn!!!","Donate");
        }
    }
}