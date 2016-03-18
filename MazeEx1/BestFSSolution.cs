using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class BestFSSolution :  Printable , ISolution
    {
        string name;
        int mazeSize;
        public BestFSSolution()
        {

        }
        public void SolveMaze(Maze maze)
        {
            this.name = maze.name;
            this.mazeSize = maze.mazeSize;
        }

    }
}
