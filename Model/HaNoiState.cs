using System;
using System.Collections.Generic;
using System.Linq;

namespace ThapHaNoi.Models
{
    public class HanoiState
    {
        // Trạng thái các cột: List[0] là cột 1, List[1] là cột 2...
        // Mỗi List<int> chứa kích thước các đĩa (ví dụ: 4, 3, 2, 1)
        public List<List<int>> Columns { get; set; }
        public HanoiState Parent { get; set; } // Để truy vết đường đi
        public string Description { get; set; } // Lưu bước đi: "1 -> 3"

        public HanoiState(List<List<int>> columns)
        {
            // Clone dữ liệu để tránh tham chiếu chồng chéo
            Columns = columns.Select(c => c.ToList()).ToList();
        }

        // Tạo mã định danh duy nhất cho mỗi trạng thái để kiểm tra trùng lặp (Visited)
        public string GetKey()
        {
            return string.Join("|", Columns.Select(c => string.Join(",", c)));
        }
    }
}