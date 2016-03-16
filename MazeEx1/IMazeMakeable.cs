using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    interface IMazeMakeable
    {
        ISolvable createMaze(Maze mazeToMake);
    }
}
