using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class FirstSearcher : ISolution
    {
        int mazeSize;
        protected Node start, end;
        protected char solvedPathValue;
        protected char visitedNodeValue = 'V';

        public void GetMazeInfo(Maze mazeToSolve)
        {
            this.name = mazeToSolve.name;
            this.mazeSize = mazeToSolve.mazeSize;
            this.start = mazeToSolve.start;
            this.end = mazeToSolve.end;
            this.solvedPathValue = mazeToSolve.mazeVals.solValue;
        }
        public void GetNodeSuccessors(Node currentNode, List<Node> nextBestNodeList)
        {
            if (currentNode.left != null)
            {
                currentNode.left.setWeight(start);
                if (currentNode.left.specialVal != visitedNodeValue)
                {
                    if(currentNode.left.specialVal != end.specialVal)
                        currentNode.left.specialVal = visitedNodeValue;
                    currentNode.left.prevNode = currentNode;
                    nextBestNodeList.Add(currentNode.left);
                }
            }
            if (currentNode.right != null)
            {
                currentNode.right.setWeight(start);
                if (currentNode.right.specialVal != visitedNodeValue)
                {
                    if (currentNode.right.specialVal != end.specialVal)
                        currentNode.right.specialVal = visitedNodeValue;
                    currentNode.right.prevNode = currentNode;
                    nextBestNodeList.Add(currentNode.right);
                }
            }
            if (currentNode.up != null)
            {
                currentNode.up.setWeight(start);
                if (currentNode.up.specialVal != visitedNodeValue)
                {
                    if (currentNode.up.specialVal != end.specialVal)
                        currentNode.up.specialVal = visitedNodeValue;
                    currentNode.up.prevNode = currentNode;
                    nextBestNodeList.Add(currentNode.up);
                }
            }
            if (currentNode.down != null)
            {
                currentNode.down.setWeight(start);
                if (currentNode.down.specialVal != visitedNodeValue)
                {
                    if (currentNode.down.specialVal != end.specialVal)
                        currentNode.down.specialVal = visitedNodeValue;
                    currentNode.down.prevNode = currentNode;
                    nextBestNodeList.Add(currentNode.down);
                }
            }
        }
        public void AssignSolutionToGraph(Node start, Node end, char solvedPathValue)
        {
            Node currentNode = end;
            while (currentNode != start)
            {
                currentNode.value = solvedPathValue;
                currentNode = currentNode.prevNode;
            }
        }
    }
}
