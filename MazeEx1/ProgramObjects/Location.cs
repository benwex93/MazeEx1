using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Location
    {
        public int col { get;}
        public int row { get;}
        public Location(int col, int row)
        {
            this.col = col;
            this.row = row;
        }
    }
}
