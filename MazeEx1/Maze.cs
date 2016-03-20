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
        public ISolution mazeSolution { get; set; }
        public Maze(string name, int mazeSize)
        {
            this.name = name;
            this.mazeSize = mazeSize;
        }
        public void CreateMaze(IMazeMakeable makeType)
        {
            makeType.CreateMaze(this);
        }
        public void Solve(ISolution solveType)
        {
            //if Maze has no solution yet of this type
            if(this.mazeSolution.GetType() == solveType.GetType() && mazeSolution == null)
                solveType.SolveMaze(this);
        }
        public override string ToString()
        {
            return GetString(start, end, mazeSize);
        }
    }
}
