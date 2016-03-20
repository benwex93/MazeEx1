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
        public void SolveMaze(Maze mazeToSolve)
        {
            this.name = mazeToSolve.name;
            this.mazeSize = mazeToSolve.mazeSize;
            this.start = mazeToSolve.start;
            TraverseNodes(mazeToSolve.start);
        }
        public void TraverseNodes(Node start)
        {
            Node currentNode = start;
            start.value = 'V';
            Queue nodesVisited = new Queue();
            nodesVisited.Enqueue(currentNode);
            while(currentNode.specialVal != '#')
            {
                if(currentNode.left != null)
                {
                    if(currentNode.left.value != 'V')
                    {
                        currentNode.left.value = 'V';
                        nodesVisited.Enqueue(currentNode.left);
                    }
                }
                if (currentNode.right != null)
                {
                    if (currentNode.right.value != 'V')
                    {
                        currentNode.right.value = 'V';
                        nodesVisited.Enqueue(currentNode.right);
                    }
                }
                if (currentNode.up != null)
                {
                    if (currentNode.up.value != 'V')
                    {
                        currentNode.up.value = 'V';
                        nodesVisited.Enqueue(currentNode.up);
                    }
                }
                if (currentNode.down != null)
                {
                    if (currentNode.down.value != 'V')
                    {
                        currentNode.down.value = 'V';
                        nodesVisited.Enqueue(currentNode.down);
                    }
                }
                currentNode = (Node)nodesVisited.Dequeue();
            }
        }
    }
}
