using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Maze : Printable
    {
        public Node start { get; set; }
        public Node end { get; set; }
        public string name { get; }
        public int mazeSize { get; }
        public CharVals mazeVals { get; set; }
        public bool isSolved { get; set; }
        public Maze(string name, int mazeSize, CharVals mazeVals)
        {
            this.name = name;
            this.mazeSize = mazeSize;
            this.mazeVals = mazeVals;
        }
        public void CreateMaze(IMazeMakeable makeType)
        {
            makeType.CreateMaze(this);
        }
        public void SolveMaze(ISolution solveType)
        {
            solveType.Solve(this);
        }
        public override string ToString()
        {
            return GetString(start, end, mazeSize, mazeVals);
        }
    }
}
