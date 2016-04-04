using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class NodeDataClass
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public NodeDataClass(int row, int col)
        {
            this.Row = row * 2;
            this.Col = col * 2;
        }
    }
}
