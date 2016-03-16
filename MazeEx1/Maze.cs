using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Maze : Printable
    {
        public Node start { get; }
        public Node end { get; }
        public string name { get; }
        public int mazeSize { get; }
        public BreadthFSSolution BreadthFS { get; set; }
        public BestFSSolution BestFS { get; set; }
        public Maze(string name, int mazeSize, int generateType)
        {
            this.name = name;
            this.mazeSize = mazeSize;
            if (generateType == 0)
            {
                RandomMazeMaker rmm = new RandomMazeMaker();
                rmm.createMaze(this);
            }
            else if (generateType == 1)
            {
                DFSMazeMaker dfsmm = new DFSMazeMaker();
                dfsmm.createMaze(this);
            }
            else
                throw new InvalidOperationException();
        }
        public void Solve(int solveType)
        {
            if (solveType == 0 && this.BreadthFS == null)
                BreadthFS = new BreadthFSSolution(this);
            else if (solveType == 1 && this.BestFS == null)
                BestFS = new BestFSSolution(this);
            else if(solveType != 0 && solveType != 1)
                throw new InvalidOperationException();
        }
    }
}
