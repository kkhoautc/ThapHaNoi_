using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi.Manager
{
    public static class DatabaseManager
    {
        // File DB sẽ tự động được tạo trong thư mục chứa file .exe của game
        private static string dbPath = "HanoiData.sqlite";
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        // Hàm này gọi 1 lần khi mở game để đảm bảo file và bảng đã tồn tại
        public static void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Leaderboard (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PlayDate TEXT,
                        Mode TEXT,
                        Moves INTEGER,
                        Time INTEGER,
                        Score INTEGER
                    )";
                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Hàm lưu thành tích mới
        public static void SaveScore(string mode, int moves, int time, int score)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Leaderboard (PlayDate, Mode, Moves, Time, Score) VALUES (@date, @mode, @moves, @time, @score)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    cmd.Parameters.AddWithValue("@mode", mode);
                    cmd.Parameters.AddWithValue("@moves", moves);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Hàm lấy danh sách Top 10 thành tích cao nhất
        public static DataTable GetTopScores()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // Sắp xếp Điểm giảm dần, Thời gian tăng dần
                string selectQuery = "SELECT PlayDate as 'Ngày chơi', Mode as 'Độ khó', Moves as 'Số bước', Time as 'Thời gian(s)', Score as 'Điểm' FROM Leaderboard ORDER BY Score DESC, Time ASC LIMIT 10";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
