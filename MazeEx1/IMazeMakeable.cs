using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    interface IMazeMakeable
    {
        void CreateStart(Maze mazeToMake);
        void CreateEnd(Maze mazeToMake);
        void CreateMaze(Maze mazeToMake);
    }
}
