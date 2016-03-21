using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class DFSMazeMaker:IMazeMakeable
    {
        static Random randomNumberGenerator = new Random();
        int mazeSize;
        Node[,] mazeArray;
        char pathValue;
        public void CreateMaze(Maze mazeToMake)
        {
            this.mazeSize = mazeToMake.mazeSize;
            this.pathValue = mazeToMake.mazeVals.pathValue;
            mazeArray = new Node[mazeSize, mazeSize];
            CreateStart(mazeToMake);
            TraverveNodes(mazeToMake.start, mazeToMake.start.location.i, mazeToMake.start.location.j);
            CreateEnd(mazeToMake);
        }
        public void CreateStart(Maze mazeToMake)
        {
            //randomNumberGenerator
            int i = randomNumberGenerator.Next(0, mazeToMake.mazeSize);
            int j = randomNumberGenerator.Next(0, mazeToMake.mazeSize);

            mazeToMake.start = new Node(i, j, mazeToMake.mazeVals.pathValue, 0);
            mazeToMake.start.specialVal = mazeToMake.mazeVals.startValue;
            mazeArray[mazeToMake.start.location.i, mazeToMake.start.location.j] = mazeToMake.start;
        }
        public void CreateEnd(Maze mazeToMake)
        {
            int greatestLengthFromStart = 0;
            Node end = null;
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    if (greatestLengthFromStart < mazeArray[i, j].lengthFromStart)
                    {
                        greatestLengthFromStart = mazeArray[i, j].lengthFromStart;
                        end = mazeArray[i, j];
                    }
                }
            }
            if(end != null)
            {
                end.specialVal = mazeToMake.mazeVals.endValue;
                mazeToMake.end = end;
            }
        }
        public void TraverveNodes(Node node, int i, int j)
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
                        else if (mazeArray[i - 1, j] == null) {
                            mazeArray[i - 1, j] = new Node(i - 1, j, pathValue, node.lengthFromStart + 1);
                            node.left = mazeArray[i - 1, j];
                            TraverveNodes(mazeArray[i - 1, j], i - 1, j);
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
                            mazeArray[i + 1, j] = new Node(i + 1, j, pathValue, node.lengthFromStart + 1);
                            node.right = mazeArray[i + 1, j];
                            TraverveNodes(mazeArray[i + 1, j], i + 1, j);
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
                            mazeArray[i, j - 1] = new Node(i, j - 1, pathValue, node.lengthFromStart + 1);
                            node.up = mazeArray[i, j - 1];
                            TraverveNodes(mazeArray[i, j - 1], i, j - 1);
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
                            mazeArray[i, j + 1] = new Node(i, j + 1, pathValue, node.lengthFromStart + 1);
                            node.down = mazeArray[i, j + 1];
                            TraverveNodes(mazeArray[i, j + 1], i, j + 1);
                        }
                        //otherwise reached already visited node
                        else { node.down = null; }
                        break;
                    default:
                        break;
                }
                directionsList.RemoveAt(randomIndex);
            }
        }
    }
}
