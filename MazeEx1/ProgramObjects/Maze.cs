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
        public string name { get; set; }
        public int mazeSize { get; set; }
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
        public Maze Clone()
        {
            Maze mazeClone = new Maze(this.name,this.mazeSize, this.mazeVals);
            mazeClone.start = this.start.Clone();
            CloneNodes(this.start, mazeClone.start);
            mazeClone.end = this.end.Clone();
            return mazeClone;
        }
        public void CloneNodes(Node currentNode, Node nodeToClone)
        {
            if(currentNode.left != null)
            {
                nodeToClone.left = currentNode.left.Clone();
                CloneNodes(currentNode.left, nodeToClone.left);
            }
            if (currentNode.right != null)
            {
                nodeToClone.right = currentNode.right.Clone();
                CloneNodes(currentNode.right, nodeToClone.right);
            }
            if (currentNode.up != null)
            {
                nodeToClone.up = currentNode.up.Clone();
                CloneNodes(currentNode.up, nodeToClone.up);
            }
            if (currentNode.down != null)
            {
                nodeToClone.down = currentNode.down.Clone();
                CloneNodes(currentNode.down, nodeToClone.down);
            }
        }
    }
}
