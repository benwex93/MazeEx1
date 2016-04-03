using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class BreadthFSSolution : FirstSearcher
    {
        public override void Solve(Maze maze)
        {
            GetMazeInfo(maze);
            TraverseNodes(start, end);
            maze.isSolved = true;
            this.solutionString = maze.ToString();
            this.solutionType = 0;
            deleteSolutionFromMaze(maze);
        }
        public void TraverseNodes(Node start, Node end)
        {
            Node currentNode = start;
            start.specialVal = visitedNodeValue;
            Queue open = new Queue();
            open.Enqueue(currentNode);
            List<Node> nextNodeList = new List<Node>();
            while (currentNode.specialVal != end.specialVal)
            {
                GetNodeSuccessors(currentNode, nextNodeList);

                foreach (Node bestNode in nextNodeList)
                    open.Enqueue(bestNode);
                currentNode = (Node)open.Dequeue();
                nextNodeList.Clear();
            }
            AssignSolutionToGraph(start, currentNode, solvedPathValue);
        }

    }
}
