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
        Node start, finish;
        public Maze(string name, string mazeString, Location beginning, Location end)
        {
            this.name = name;
            this.mazeString = mazeString;
            this.beginning = beginning;
            this.end = end;
            InitMazeArray();
            start = mazeArray[beginning.GetRow(), beginning.GetCol()];
            start.SetValue('*');
            finish = mazeArray[end.GetRow(), end.GetCol()];
            finish.SetValue('#');
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
                    node.SetLeft(null);
                }
                //found open spot and keeps going
                else if (mazeArray[i,j].GetValue() == '0' || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetLeft(mazeArray[i, j]);
                    if(mazeArray[i, j].GetValue() == '0')
                        mazeArray[i, j].SetValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2' || mazeArray[i, j].GetValue() == '*'
                    || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetLeft(mazeArray[i, j]);
                }
            }
            //went off grid
            else
            {
                node.SetLeft(null);
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
                    node.SetRight(null);
                }
                //found open spot and keeps going
                else if (mazeArray[i, j].GetValue() == '0' || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetRight(mazeArray[i, j]);
                    if (mazeArray[i, j].GetValue() == '0')
                        mazeArray[i, j].SetValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2' || mazeArray[i, j].GetValue() == '*'
                    || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetRight(mazeArray[i, j]);
                }
            }
            //went off grid
            else
            {
                node.SetRight(null);
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
                    node.SetUp(null);
                }
                //found open spot and keeps going
                else if (mazeArray[i, j].GetValue() == '0' || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetUp(mazeArray[i, j]);
                    if (mazeArray[i, j].GetValue() == '0')
                        mazeArray[i, j].SetValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2' || mazeArray[i, j].GetValue() == '*'
                    || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetUp(mazeArray[i, j]);
                }
            }
            //went off grid
            else
            {
                node.SetUp(null);
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
                    node.SetDown(null);
                }
                //found open spot and keeps going
                else if (mazeArray[i, j].GetValue() == '0' || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetDown(mazeArray[i, j]);
                    if (mazeArray[i, j].GetValue() == '0')
                        mazeArray[i, j].SetValue('2');
                    ConvertMaze2Graph(mazeArray[i, j]);
                }
                else if (mazeArray[i, j].GetValue() == '2' || mazeArray[i, j].GetValue() == '*'
                    || mazeArray[i, j].GetValue() == '#')
                {
                    node.SetDown(mazeArray[i, j]);
                }
            }
            //went off grid
            else
            {
                node.SetDown(null);
            }
        }
        public void write(int write)
        {
            Console.Write(write);
            Console.ReadLine();
        }
    }
}
