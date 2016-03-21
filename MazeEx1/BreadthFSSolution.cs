using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class BreadthFSSolution : Printable, ISolution
    {
        string name;
        int mazeSize;
        Node start;
        char solvedPathValue;
        char visitedNodeValue = 'V';

        public void SolveMaze(Maze mazeToSolve)
        {
            this.name = mazeToSolve.name;
            this.mazeSize = mazeToSolve.mazeSize;
            this.start = mazeToSolve.start;
            this.solvedPathValue = mazeToSolve.mazeVals.solValue;
            TraverseNodes(mazeToSolve.start,mazeToSolve.end);
        }
        public void TraverseNodes(Node start, Node end)
        {
            Node currentNode = start;
            start.specialVal = visitedNodeValue;
            Queue nodesVisited = new Queue();
            nodesVisited.Enqueue(currentNode);
            while(currentNode != end)
            {
                if(currentNode.left != null)
                {
                    if(currentNode.left.specialVal != visitedNodeValue)
                    {
                        currentNode.left.specialVal = visitedNodeValue;
                        currentNode.left.prevNode = currentNode;
                        nodesVisited.Enqueue(currentNode.left);
                    }
                }
                if (currentNode.right != null)
                {
                    if (currentNode.right.specialVal != visitedNodeValue)
                    {
                        currentNode.right.specialVal = visitedNodeValue;
                        currentNode.right.prevNode = currentNode;
                        nodesVisited.Enqueue(currentNode.right);
                    }
                }
                if (currentNode.up != null)
                {
                    if (currentNode.up.specialVal != visitedNodeValue)
                    {
                        currentNode.up.specialVal = visitedNodeValue;
                        currentNode.up.prevNode = currentNode;
                        nodesVisited.Enqueue(currentNode.up);
                    }
                }
                if (currentNode.down != null)
                {
                    if (currentNode.down.specialVal != visitedNodeValue)
                    {
                        currentNode.down.specialVal = visitedNodeValue;
                        currentNode.down.prevNode = currentNode;
                        nodesVisited.Enqueue(currentNode.down);
                    }
                }
                currentNode = (Node)nodesVisited.Dequeue();
            }
            AssignSolutionToGraph(start, currentNode);
        }
        public void AssignSolutionToGraph(Node start, Node end)
        {
            Node currentNode = end;
            while(currentNode != start)
            {
                currentNode.value = solvedPathValue;
                currentNode = currentNode.prevNode;
            }
        }
    }
}
