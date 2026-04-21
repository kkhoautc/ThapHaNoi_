using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi.Model
{
    public class Tower
    {
        public Stack<Disk> Disks { get; private set; } = new Stack<Disk>();

        public bool CanPush(Disk disk)
        {
            return Disks.Count == 0 || Disks.Peek().Size > disk.Size;
        }

        public void Push(Disk disk)
        {
            if (CanPush(disk))
                Disks.Push(disk);
        }

        public Disk Pop()
        {
            return Disks.Pop();
        }
    }
}
