using System.Collections.Generic;
using ThapHaNoi.Model;
using ThapHaNoi.Models;

namespace ThapHaNoi.GameLogic
{
    public class HanoiGame
    {
        public List<Tower> Towers { get; set; }
        public int NumDisks { get; set; }

        // Quản lý Undo và Redo
        private Stack<MoveStep> undoStack = new Stack<MoveStep>();
        private Stack<MoveStep> redoStack = new Stack<MoveStep>();

        public HanoiGame(int towerCount, int diskCount)
        {
            NumDisks = diskCount;
            Towers = new List<Tower>();
            for (int i = 0; i < towerCount; i++) Towers.Add(new Tower());
            ResetGame();
        }

        public void ResetGame()
        {
            foreach (var tower in Towers) tower.Disks.Clear();
            undoStack.Clear();
            redoStack.Clear();

            for (int i = NumDisks; i >= 1; i--)
            {
                Towers[0].Disks.Push(new Disk(i));
            }
        }

        // Hàm di chuyển chính
        // isUndoRedo: Nếu là True, sẽ không lưu vào UndoStack (tránh lặp vô tận)
        public bool Move(int from, int to, bool isSystemMove = false)
        {
            if (from == to || from < 0 || to < 0) return false;
            if (Towers[from].Disks.Count == 0) return false;

            Disk movingDisk = Towers[from].Disks.Peek();
            if (Towers[to].Disks.Count > 0 && Towers[to].Disks.Peek().Size < movingDisk.Size)
                return false;

            Towers[to].Disks.Push(Towers[from].Disks.Pop());

            // Nếu không phải là lệnh Undo/Redo thì mới lưu vào lịch sử
            if (!isSystemMove)
            {
                undoStack.Push(new MoveStep(from, to));
                redoStack.Clear();
            }
            return true;
        }

        // QUAY LẠI (UNDO)
        public MoveStep? Undo()
        {
            if (undoStack.Count == 0) return null;
            MoveStep step = undoStack.Pop();
            // Di chuyển ngược lại (To -> From)
            Towers[step.From].Disks.Push(Towers[step.To].Disks.Pop());
            redoStack.Push(step);
            return step;
        }

        public MoveStep? Redo()
        {
            if (redoStack.Count == 0) return null;
            MoveStep step = redoStack.Pop();
            // Di chuyển xuôi lại (From -> To)
            Towers[step.To].Disks.Push(Towers[step.From].Disks.Pop());
            undoStack.Push(step);
            return step;
        }
       
    }
}