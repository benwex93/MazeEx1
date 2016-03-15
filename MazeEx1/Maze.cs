using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Maze
    {
        string name;
        Location beginning, end;
        Node [,] mazeArray;
        int arrayRowCount, arrayColCount;
        Node start, finish;
        public Maze(string name, string mazeString, Location beginning, Location end)
        {
            this.name = name;
            this.beginning = beginning;
            this.end = end;
            //allocate maze array with nodes
            InitilizeMazeArray(mazeString);
            //create connected graph of path using maze array
            ConvertMaze2Graph(start);
            PrintArray();
        }
        public void InitilizeMazeArray(string mazeString)
        {
            //creates square array of sqr(str.len)*sqr(str.len)
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
            //assign start to node
            this.start = mazeArray[beginning.GetRow(), beginning.GetCol()];
            this.start.SetValue('*');
            //assign finish to node
            this.finish = mazeArray[end.GetRow(), end.GetCol()];
            this.finish.SetValue('#');
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
        public void TraverseNode(Node node, char direction, int i, int j)
        {
            bool open = false;
            switch (direction)
            {
                case 'L':
                    if (i < 0)
                        node.SetLeft(null);
                    else if (mazeArray[i, j].GetValue() == '1')
                        node.SetLeft(null);
                    else { node.SetLeft(mazeArray[i, j]); open = true; }
                    break;
                case 'R':
                    if (i >= arrayRowCount)
                        node.SetRight(null);
                    else if (mazeArray[i, j].GetValue() == '1')
                        node.SetLeft(null);
                    else { node.SetLeft(mazeArray[i, j]); open = true; }
                    break;
                case 'U':
                    if (j < 0)
                        node.SetUp(null);
                    else if (mazeArray[i, j].GetValue() == '1')
                        node.SetUp(null);
                    else { node.SetLeft(mazeArray[i, j]); open = true; }
                    break;
                case 'D':
                    if (j >= arrayColCount)
                        node.SetDown(null);
                    else if (mazeArray[i, j].GetValue() == '1')
                        node.SetDown(null);
                    else { node.SetLeft(mazeArray[i, j]); open = true; }
                    break;
                default:
                    break;
            }
            if (open && (mazeArray[i, j].GetValue() == '0' || mazeArray[i, j].GetValue() == '#'))
            {
                //must set value before travering if reached 0
                if (mazeArray[i, j].GetValue() == '0')
                    mazeArray[i, j].SetValue('2');
                TraverseNode(mazeArray[i, j], 'L', i - 1, j);
                TraverseNode(mazeArray[i, j], 'R', i + 1, j);
                TraverseNode(mazeArray[i, j], 'U', i, j - 1);
                TraverseNode(mazeArray[i, j], 'D', i, j + 1);
            }
        }
        public void ConvertMaze2Graph(Node start)
        {
            TraverseNode(start, 'L', start.getRow() - 1, start.getCol());
            TraverseNode(start, 'R', start.getRow() + 1, start.getCol());
            TraverseNode(start, 'U', start.getRow(), start.getCol() - 1);
            TraverseNode(start, 'D', start.getRow(), start.getCol() + 1);
        }
        public void write(int write)
        {
            Console.Write(write);
            Console.ReadLine();
        }
    }
}
