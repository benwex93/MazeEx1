using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class ISolution
    {
        public string name { get; set; }
        public string solutionString { get; set; }
        public int solutionType { get; set; }
        public virtual void Solve(Maze maze)
        {
            throw new NotImplementedException();
        }
        public void deleteSolutionFromMaze(Maze maze)
        {
            ResetNodes(maze.start, maze.end, maze.mazeVals);
            //resets start value since it was overwritten during reset
            maze.start.value = maze.mazeVals.startValue;
        }
        public void ResetNodes1(Node start, Node end, char pathValue)
        {
            Node currentNode = end;
            while (currentNode.prevNode != null)
            {
                currentNode.specialVal = '0';
                currentNode.value = pathValue;
                currentNode = currentNode.prevNode;
            }
        }
        public void ResetNodes(Node currentNode, Node end, CharVals mazeVals)
        {
            if (currentNode.left != null)
            {
                currentNode.left.weight = 0;
                currentNode.left.prevNode = null;
                currentNode.left.value = mazeVals.pathValue;
                if (currentNode.left.specialVal != mazeVals.endValue)
                {
                    currentNode.left.specialVal = '\0';
                    ResetNodes(currentNode.left, end, mazeVals);
                }
            }
            if (currentNode.right != null)
            {
                currentNode.right.weight = 0;
                currentNode.right.prevNode = null;
                currentNode.right.value = mazeVals.pathValue;
                if (currentNode.right.specialVal != mazeVals.endValue)
                {
                    currentNode.right.specialVal = '\0';
                    ResetNodes(currentNode.right, end, mazeVals);
                }
            }
            if (currentNode.up != null)
            {
                currentNode.up.weight = 0;
                currentNode.up.prevNode = null;
                currentNode.up.value = mazeVals.pathValue;
                if (currentNode.up.specialVal != mazeVals.endValue)
                {
                    currentNode.up.specialVal = '\0';
                    ResetNodes(currentNode.up, end, mazeVals);
                }
            }
            if (currentNode.down != null)
            {
                currentNode.down.weight = 0;
                currentNode.down.prevNode = null;
                currentNode.down.value = mazeVals.pathValue;
                if (currentNode.down.specialVal != mazeVals.endValue)
                {
                    currentNode.down.specialVal = '\0';
                    ResetNodes(currentNode.down, end, mazeVals);
                }
            }
        }
        public override string ToString()
        {
            return this.solutionString;
        }
    }
}
