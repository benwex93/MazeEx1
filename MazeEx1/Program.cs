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
            //must be perfect square
            string MazeString = "0000110011100001001011110000000001011110000100010100010000011000";
            Location start = new Location(0,0);
            Location end = new Location(7,7);
            Maze Maze1 = new Maze(Name, MazeString, start, end);
        }
    }
}
