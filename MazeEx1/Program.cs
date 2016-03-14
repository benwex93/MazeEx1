using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = "MyMaze";
            //string MazeString = "100101100";
            string MazeString = "1000010100000110";
            Location start = new Location(0,1);
            Location end = new Location(2,2);
            Maze Maze1 = new Maze(Name, MazeString, start, end);
        }
    }
}
