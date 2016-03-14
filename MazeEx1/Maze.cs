using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Maze
    {
        string name, mazeString;
        Location beginning, end;
        Node [,] mazeArray;
        int arrayRowCount, arrayColCount;
        Node start;
        public Maze(string name, string mazeString, Location beginning, Location end)
        {
            this.name = name;
            this.mazeString = mazeString;
            this.beginning = beginning;
            this.end = end;
            InitMazeArray();
            start = new Node(beginning.GetRow(), beginning.GetCol(), '2');
            ConvertMaze2Graph(start);
            PrintArray();
        }
        public void InitMazeArray()
        {
            arrayRowCount = (int)Math.Sqrt(mazeString.Length);
            arrayColCount = arrayRowCount;
            mazeArray = new Node[arrayRowCount, arrayColCount];
            for(int i = 0; i < arrayRowCount; i++)
            {
                for (int j = 0; j < arrayColCount; j++)
                {
                    mazeArray[i, j] = new Node(i, j, mazeString[(i * arrayRowCount) + j]);
                }
            }
        }
        public void PrintArray()
        {
            for (int i = 0; i < arrayRowCount; i++)
            {
                for (int j = 0; j < arrayColCount; j++)
                {
                    Console.Write(mazeArray[i, j].GetValue());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public void ConvertMaze2Graph(Node node)
        {
            //try left
            //check if went of left side of grid
            if (node.getRow() - 1 >= 0)
            {
                int i = node.getRow() - 1;
                int j = node.getCol();
                //if hit wall, stops
                if (mazeArray[i, j].GetValue() == '1')
                {
                    node.left = null;
                }
                //found open spot and keeps going
                else if (mazeArray[i,j].GetValue() == '0')
                {
                    node.left = mazeArray[i, j];
                    mazeArray[i, j].setValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2')
                {
                    node.left = mazeArray[i, j];
                }
            }
            //went off grid
            else
            {
                node.left = null;
            }


            //try right
            //check if went of left side of grid
            if (node.getRow() + 1 < arrayRowCount)
            {
                int i = node.getRow() + 1;
                int j = node.getCol();
                //if hit wall, stops
                if (mazeArray[i, j].GetValue() == '1')
                {
                    node.right = null;
                }
                //found open spot and keeps going
                else if (mazeArray[i, j].GetValue() == '0')
                {
                    node.right = mazeArray[i, j];
                    mazeArray[i, j].setValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2')
                {
                    node.right = mazeArray[i, j];
                }
            }
            //went off grid
            else
            {
                node.right = null;
            }

            //try up
            //check if went of left side of grid
            if (node.getCol() - 1 >= 0)
            {
                int i = node.getRow();
                int j = node.getCol() - 1;
                //if hit wall, stops
                if (mazeArray[i, j].GetValue() == '1')
                {
                    node.up = null;
                }
                //found open spot and keeps going
                else if (mazeArray[i, j].GetValue() == '0')
                {
                    node.up = mazeArray[i, j];
                    mazeArray[i, j].setValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2')
                {
                    node.up = mazeArray[i, j];
                }
            }
            //went off grid
            else
            {
                node.up = null;
            }

            //try up
            //check if went of left side of grid
            if (node.getCol() + 1 < arrayColCount)
            {
                int i = node.getRow();
                int j = node.getCol() + 1;
                //if hit wall, stops
                if (mazeArray[i, j].GetValue() == '1')
                {
                    node.down = null;
                }
                //found open spot and keeps going
                else if (mazeArray[i, j].GetValue() == '0')
                {
                    node.down = mazeArray[i, j];
                    mazeArray[i, j].setValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2')
                {
                    node.down = mazeArray[i, j];
                }
            }
            //went off grid
            else
            {
                node.down = null;
            }
        }
        public void write(int write)
        {
            Console.Write(write);
            Console.ReadLine();
        }
    }
}
