using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi.Model
{
    public class Disk
    {
        public int Size { get; set; }

        public Disk(int size)
        {
            Size = size;
        }
    }
}
