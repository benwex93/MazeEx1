using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class RandomMazeMaker : IMazeMakeable
    {
        static Random randomNumberGenerator = new Random();
        int mazeSize;
        Node[,] mazeArray;
        char pathValue;
        char mainPathValue = 'M';
        public void CreateMaze(Maze mazeToMake)
        {
            this.mazeSize = mazeToMake.mazeSize;
            this.pathValue = mazeToMake.mazeVals.pathValue;
            mazeArray = new Node[mazeSize, mazeSize];
            CreateStart(mazeToMake);
            CreateEnd(mazeToMake);
            RandomizeRemainingNodes();
        }
        public void CreateStart(Maze mazeToMake)
        {
            //randomNumberGenerator
            int i = randomNumberGenerator.Next(0, mazeToMake.mazeSize);
            int j = randomNumberGenerator.Next(0, mazeToMake.mazeSize);

            mazeToMake.start = new Node(i, j, pathValue, 0);
            mazeToMake.start.specialVal = mazeToMake.mazeVals.startValue;
            mazeArray[mazeToMake.start.location.i, mazeToMake.start.location.j] = mazeToMake.start;
        }
        public void CreateEnd(Maze mazeToMake)
        {
            MakeStartEndPath(mazeToMake.start, mazeToMake.start.location.i, mazeToMake.start.location.j);
            int greatestLengthFromStart = 0;
            Node end = null;
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    if (mazeArray[i, j] != null)
                    {
                        if (greatestLengthFromStart < mazeArray[i, j].lengthFromStart)
                        {
                            greatestLengthFromStart = mazeArray[i, j].lengthFromStart;
                            end = mazeArray[i, j];
                        }
                    }
                }
            }
            if (end != null)
            {
                end.specialVal = mazeToMake.mazeVals.endValue;
                mazeToMake.end = end;
            }
        }
        public bool MakeStartEndPath(Node node, int i, int j)
        {
            //if not at starting node
            List<int> directionsList = new List<int>();
            for (int directionCases = 0; directionCases < 4; directionCases++)
                directionsList.Add(directionCases);
            //visits all nodes in order starting with random one 
            while (directionsList.Count > 0)
            {
                int randomIndex = randomNumberGenerator.Next(0, directionsList.Count);
                switch (directionsList.ElementAt(randomIndex))
                {
                    //go left
                    case 0:
                        if (i - 1 < 0) //if out of bounds
                            node.left = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i - 1, j] == null)
                        {
                            //end after making path of size mazesize*mazesize/2
                            if (node.lengthFromStart >= mazeSize)
                                return true;
                            else
                            {
                                mazeArray[i - 1, j] = new Node(i - 1, j, pathValue, node.lengthFromStart + 1);
                                node.left = mazeArray[i - 1, j];
                                node.left.specialVal = mainPathValue;
                                if (MakeStartEndPath(mazeArray[i - 1, j], i - 1, j))
                                    return true;
                                mazeArray[i - 1, j] = null;
                            }
                        }
                        //otherwise reached already visited node
                        else { node.left = null; }
                        break;
                    //go right
                    case 1:
                        if (i + 1 >= mazeSize) //if out of bounds
                            node.right = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i + 1, j] == null)
                        {
                            if (node.lengthFromStart >= mazeSize)
                                return true;
                            else
                            {
                                mazeArray[i + 1, j] = new Node(i + 1, j, pathValue, node.lengthFromStart + 1);
                                node.right = mazeArray[i + 1, j];
                                node.right.specialVal = mainPathValue;
                                if(MakeStartEndPath(mazeArray[i + 1, j], i + 1, j)) //if led to final path
                                    return true;
                                mazeArray[i + 1, j] = null;
                            }
                        }
                        //otherwise reached already visited node
                        else { node.right = null; }
                        break;
                    //go up
                    case 2:
                        if (j - 1 < 0) //if out of bounds
                            node.up = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i, j - 1] == null)
                        {
                            if (node.lengthFromStart >= mazeSize)
                                return true;
                            else
                            {
                                mazeArray[i, j - 1] = new Node(i, j - 1, pathValue, node.lengthFromStart + 1);
                                node.up = mazeArray[i, j - 1];
                                node.up.specialVal = mainPathValue;
                                if (MakeStartEndPath(mazeArray[i, j - 1], i, j - 1))
                                    return true;
                                mazeArray[i, j - 1] = null;
                            }
                        }
                        //otherwise reached already visited node
                        else { node.up = null; }
                        break;
                    //go down
                    case 3:
                        if (j + 1 >= mazeSize) //if out of bounds
                            node.down = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i, j + 1] == null)
                        {
                            if (node.lengthFromStart >= mazeSize)
                                return true;
                            else
                            {
                                mazeArray[i, j + 1] = new Node(i, j + 1, pathValue, node.lengthFromStart + 1);
                                node.down = mazeArray[i, j + 1];
                                node.down.specialVal = mainPathValue;
                                if (MakeStartEndPath(mazeArray[i, j + 1], i, j + 1))
                                    return true;
                                mazeArray[i, j + 1] = null;
                            }
                        }
                        //otherwise reached already visited node
                        else { node.down = null; }
                        break;
                    default:
                        break;
                }
                directionsList.RemoveAt(randomIndex);
            }
            //else reached dead end
            return false;
        }
        /// <summary>
        /// Traverses through original path node by node randomly exploring outward until it reaches itself again or a wall
        /// </summary>
        public void RandomizeRemainingNodes()
        {
            Node nodeToBranchOut;
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    if (mazeArray[i, j] != null)
                    {
                        //if found one of the nodes on the main path
                        if (mazeArray[i, j].specialVal == mainPathValue)
                        {
                            nodeToBranchOut = mazeArray[i, j];
                            //makes list so it can loop through all direction in random order
                            List<int> directionsList = new List<int>();
                            for (int directionCases = 0; directionCases < 4; directionCases++)
                                directionsList.Add(directionCases);
                            //visits all nodes in order starting with random one 
                            while (directionsList.Count > 0)
                            {
                                int randomIndex = randomNumberGenerator.Next(0, directionsList.Count);
                                switch (directionsList.ElementAt(randomIndex))
                                {
                                    //go left
                                    case 0:
                                        if (nodeToBranchOut.location.i - 1 < 0)
                                        { //if out of bounds removes direction from possible direction list
                                            nodeToBranchOut.left = null;
                                            directionsList.RemoveAt(randomIndex);
                                        }
                                        //if node to left is null, initializes it and explores it
                                        else if (mazeArray[nodeToBranchOut.location.i - 1, nodeToBranchOut.location.j] == null)
                                        {
                                            mazeArray[nodeToBranchOut.location.i - 1, nodeToBranchOut.location.j]
                                                = new Node(nodeToBranchOut.location.i - 1, nodeToBranchOut.location.j, pathValue, 0);
                                            nodeToBranchOut.left = mazeArray[nodeToBranchOut.location.i - 1, nodeToBranchOut.location.j];
                                            nodeToBranchOut = nodeToBranchOut.left;
                                            //can explore all directions now
                                            directionsList.Clear();
                                            for (int directionCases = 0; directionCases < 4; directionCases++)
                                                directionsList.Add(directionCases);
                                        }
                                        //if node to left has already been initialized and is not wall does not do anything
                                        else
                                            directionsList.RemoveAt(randomIndex);
                                        break;
                                    //go right
                                    case 1:
                                        if (nodeToBranchOut.location.i + 1 >= mazeSize)  { //if out of bounds
                                            nodeToBranchOut.right = null;
                                            directionsList.RemoveAt(randomIndex);
                                        }
                                        //if node from main path allow it to connect to other nodes
                                        else if (mazeArray[nodeToBranchOut.location.i + 1, nodeToBranchOut.location.j] == null)
                                        {
                                            mazeArray[nodeToBranchOut.location.i + 1, nodeToBranchOut.location.j]
                                                = new Node(nodeToBranchOut.location.i + 1, nodeToBranchOut.location.j, pathValue, 0);
                                            nodeToBranchOut.right = mazeArray[nodeToBranchOut.location.i + 1, nodeToBranchOut.location.j];
                                            nodeToBranchOut = nodeToBranchOut.right;
                                            directionsList.Clear();
                                            for (int directionCases = 0; directionCases < 4; directionCases++)
                                                directionsList.Add(directionCases);
                                        }
                                        else
                                            directionsList.RemoveAt(randomIndex);
                                        break;
                                    //go up
                                    case 2:
                                        if (nodeToBranchOut.location.j - 1 < 0)  { //if out of bounds
                                            nodeToBranchOut.up = null;
                                            directionsList.RemoveAt(randomIndex);
                                        }
                                        //if node from main path allow it to connect to other nodes
                                        else if (mazeArray[nodeToBranchOut.location.i, nodeToBranchOut.location.j - 1] == null)
                                        {
                                            mazeArray[nodeToBranchOut.location.i, nodeToBranchOut.location.j - 1]
                                                = new Node(nodeToBranchOut.location.i, nodeToBranchOut.location.j - 1, pathValue, 0);
                                            nodeToBranchOut.up = mazeArray[nodeToBranchOut.location.i, nodeToBranchOut.location.j - 1];
                                            nodeToBranchOut = nodeToBranchOut.up;
                                            directionsList.Clear();
                                            for (int directionCases = 0; directionCases < 4; directionCases++)
                                                directionsList.Add(directionCases);
                                        }
                                        else
                                            directionsList.RemoveAt(randomIndex);
                                        break;
                                    //go down
                                    case 3:
                                        if (nodeToBranchOut.location.j + 1 >= mazeSize) {  //if out of bounds
                                            nodeToBranchOut.down = null;
                                            directionsList.RemoveAt(randomIndex);
                                        }
                                        //if node from main path allow it to connect to other nodes
                                        else if (mazeArray[nodeToBranchOut.location.i, nodeToBranchOut.location.j + 1] == null)
                                        {
                                            mazeArray[nodeToBranchOut.location.i, nodeToBranchOut.location.j + 1]
                                                = new Node(nodeToBranchOut.location.i, nodeToBranchOut.location.j + 1, pathValue, 0);
                                            nodeToBranchOut.down = mazeArray[nodeToBranchOut.location.i, nodeToBranchOut.location.j + 1];
                                            nodeToBranchOut = nodeToBranchOut.down;
                                            directionsList.Clear();
                                            for (int directionCases = 0; directionCases < 4; directionCases++)
                                                directionsList.Add(directionCases);
                                        }
                                        else
                                            directionsList.RemoveAt(randomIndex);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
