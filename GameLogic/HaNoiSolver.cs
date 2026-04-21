using System.Collections.Generic;
using System.Linq;
using ThapHaNoi.Models;

namespace ThapHaNoi.GameLogic
{
    public class HanoiSolver
    {
        public static List<HanoiState> SolveBFS(int numTowers, int numDisks)
        {
            // Trạng thái ban đầu: Tất cả đĩa ở cột 0
            var startCols = new List<List<int>>();
            startCols.Add(Enumerable.Range(1, numDisks).Reverse().ToList());
            for (int i = 1; i < numTowers; i++) startCols.Add(new List<int>());

            var startState = new HanoiState(startCols);
            var queue = new Queue<HanoiState>();
            var visited = new HashSet<string>();

            queue.Enqueue(startState);
            visited.Add(startState.GetKey());

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                // Kiểm tra đích: Cột cuối cùng đủ đĩa
                if (current.Columns[numTowers - 1].Count == numDisks)
                    return ReconstructPath(current);

                // Thử tất cả các bước di chuyển hợp lệ (Operators)
                for (int from = 0; from < numTowers; from++)
                {
                    for (int to = 0; to < numTowers; to++)
                    {
                        if (from == to) continue;

                        var fromCol = current.Columns[from];
                        var toCol = current.Columns[to];

                        if (fromCol.Count > 0 && (toCol.Count == 0 || fromCol.Last() < toCol.Last()))
                        {
                            var nextCols = current.Columns.Select(c => c.ToList()).ToList();
                            int diskSize = nextCols[from].Last();
                            nextCols[from].RemoveAt(nextCols[from].Count - 1);
                            nextCols[to].Add(diskSize);

                            var nextState = new HanoiState(nextCols)
                            {
                                Parent = current,
                                Description = $"Đĩa {diskSize}: Cột {from + 1} -> {to + 1}"
                            };

                            if (!visited.Contains(nextState.GetKey()))
                            {
                                visited.Add(nextState.GetKey());
                                queue.Enqueue(nextState);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private static List<HanoiState> ReconstructPath(HanoiState goal)
        {
            var path = new List<HanoiState>();
            while (goal != null) { path.Add(goal); goal = goal.Parent; }
            path.Reverse();
            return path;
        }
    }
}