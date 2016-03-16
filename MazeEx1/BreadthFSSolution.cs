using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class BreadthFSSolution : Printable, ISolvable
    {
        public string name { get; }
        public int mazeSize { get; }
        public BreadthFSSolution(Maze mazeToSolve)
        {
            this.name = mazeToSolve.name;
            this.mazeSize = mazeToSolve.mazeSize;
        }
        public void SolveMaze(Maze maze)
        {
            throw new NotImplementedException();
        }


    }
}
