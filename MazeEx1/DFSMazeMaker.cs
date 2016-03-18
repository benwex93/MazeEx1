using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class DFSMazeMaker:IMazeMakeable
    {
        static Random randomNumberGenerator;
        int mazeSize;
        Node[,] mazeArray;
        public void createMaze(Maze mazeToMake)
        {
            this.mazeSize = mazeToMake.mazeSize;
            randomNumberGenerator = new Random();
            int i = randomNumberGenerator.Next(0, mazeToMake.mazeSize);
            int j = randomNumberGenerator.Next(0, mazeToMake.mazeSize);

            mazeToMake.start = new Node(i, j, '*');
            mazeArray = new Node[mazeSize, mazeSize];
            mazeArray[mazeToMake.start.location.i, mazeToMake.start.location.j] = mazeToMake.start;
            traverveNodes(mazeToMake.start, mazeToMake.start.location.i, mazeToMake.start.location.j);
        }
        public void traverveNodes(Node node, int i, int j)
        {
            List<int> directionsList = new List<int>();
            for (int directionCases = 0; directionCases < 4; directionCases++)
                directionsList.Add(directionCases);
            //visits all nodes in order starting with random one 
            while (directionsList.Count > 0)
            {
                int randomIndex = randomNumberGenerator.Next(0, directionsList.Count);
                switch (directionsList.ElementAt(randomIndex))
                {
                    //go up
                    case 0:
                        if (i - 1 < 0) //if out of bounds
                            node.left = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i - 1, j] == null) {
                            mazeArray[i - 1, j] = new Node(i - 1, j, '0');
                            node.left = mazeArray[i - 1, j];
                            traverveNodes(mazeArray[i - 1, j], i - 1, j);
                        }
                        //otherwise reached already visited node
                        else { node.left = null; }
                        break;
                    //go down
                    case 1:
                        if (i + 1 >= mazeSize) //if out of bounds
                            node.right = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i + 1, j] == null)
                        {
                            mazeArray[i + 1, j] = new Node(i + 1, j, '0');
                            node.right = mazeArray[i + 1, j];
                            traverveNodes(mazeArray[i + 1, j], i + 1, j);
                        }
                        //otherwise reached already visited node
                        else { node.right = null; }
                        break;
                    //go left
                    case 2:
                        if (j - 1 < 0) //if out of bounds
                            node.up = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i, j - 1] == null)
                        {
                            mazeArray[i, j - 1] = new Node(i, j - 1, '0');
                            node.up = mazeArray[i, j - 1];
                            traverveNodes(mazeArray[i, j - 1], i, j - 1);
                        }
                        //otherwise reached already visited node
                        else { node.up = null; }
                        break;
                    //go right
                    case 3:
                        if (j + 1 >= mazeSize) //if out of bounds
                            node.down = null;
                        //if in bounds can safely run check on maze to see if found available node
                        else if (mazeArray[i, j + 1] == null)
                        {
                            mazeArray[i, j + 1] = new Node(i, j + 1, '0');
                            node.down = mazeArray[i, j + 1];
                            traverveNodes(mazeArray[i, j + 1], i, j + 1);
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
