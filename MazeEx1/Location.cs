using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Location
    {
        int row;
        int col;
        public Location(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public int GetRow()
        {
            return row;
        }
        public void SetRow(int i)
        {
            this.row = i;
        }
        public int GetCol()
        {
            return col;
        }
        public void SetCol(int j)
        {
            this.col = j;
        }

    }
}
