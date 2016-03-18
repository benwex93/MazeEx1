using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    abstract class Printable
    {
        char[,] visualMazeArray;
        int mazeSize;
        public string ToMazeString(Node start, int mazeSize)
        {
            this.mazeSize = mazeSize;
            visualMazeArray = new char[mazeSize * 2, mazeSize * 2];
            traverveNodes(start, start.location.i * 2, start.location.j * 2);
            visualMazeArray[start.location.i * 2, start.location.j * 2] = '*';
            string mazeString = "";
            for (int col = 0; col < mazeSize * 2; col++)
            {
                for (int row = 0; row < mazeSize * 2; row++)
                {
                    if (visualMazeArray[col, row] == '\0')
                        Console.Write('X');
                    else if (visualMazeArray[col, row] == '*')
                        Console.Write('S');
                    else
                        Console.Write(" ");
                        //Console.Write(visualMazeArray[i, j]);
                }
                Console.WriteLine();
               // mazeString += "\n";
            }
            return mazeString;
        }
        public void traverveNodes(Node node, int i, int j)
        {
            //go left
            if (node.left != null)
            {
                visualMazeArray[i - 1, j] = node.left.value;
                visualMazeArray[i - 2, j] = node.left.value;
                traverveNodes(node.left, i-2, j);
            }
            //go right
            if (node.right != null)
            {
                visualMazeArray[i + 1, j] = node.right.value;
                visualMazeArray[i + 2, j] = node.right.value;
                traverveNodes(node.right, i + 2, j);
            }
            //go up
            if (node.up != null)
            {
                visualMazeArray[i, j - 1] = node.up.value;
                visualMazeArray[i, j - 2] = node.up.value;
                traverveNodes(node.up, i, j - 2);
            }
            //go down
            if (node.down != null)
            {
                visualMazeArray[i, j + 1] = node.down.value;
                visualMazeArray[i, j + 2] = node.down.value;
                traverveNodes(node.down, i, j + 2);
            }
        }
    }
}
