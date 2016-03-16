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
            string name1 = "Maze1", name2 = "Maze2";
            const int Random = 0, DFS = 1, BreadthFS = 0, BestFS = 1, mazeSize = 8;
            Maze mazeRetrieved;

            //Generate Random Maze of size 8 x 8
            Maze Maze1 = new Maze(name1, mazeSize, Random);
            MazeDataBase.AddMaze(Maze1);
            mazeRetrieved = MazeDataBase.RetrieveMaze(name1);
            Console.WriteLine(mazeRetrieved.name);
            Console.WriteLine(mazeRetrieved.ToMazeString(mazeRetrieved.start));
            Console.WriteLine(mazeRetrieved.start.location.i + " " + mazeRetrieved.start.location.j);
            Console.WriteLine(mazeRetrieved.end);

            //Generate DFS Maze of size 8 x 8
            Maze Maze2 = new Maze(name2, mazeSize, DFS);
            MazeDataBase.AddMaze(Maze1);
            mazeRetrieved = MazeDataBase.RetrieveMaze(name2);
            Console.WriteLine(mazeRetrieved.name);
            Console.WriteLine(mazeRetrieved.ToMazeString(mazeRetrieved.start));
            Console.WriteLine(mazeRetrieved.start.location.i + " " + mazeRetrieved.start.location.j);
            Console.WriteLine(mazeRetrieved.end);

            //Get BRFS Maze Solution for Maze 1
            mazeRetrieved = MazeDataBase.RetrieveMaze(name1);
            mazeRetrieved.Solve(BreadthFS);
            Console.WriteLine(mazeRetrieved.name);
            Console.WriteLine(mazeRetrieved.ToMazeString(mazeRetrieved.start));
            Console.WriteLine(mazeRetrieved.start.location.i + " " + mazeRetrieved.start.location.j);
            Console.WriteLine(mazeRetrieved.end);

            //Get BFS Maze Solution for Maze 2
            mazeRetrieved = MazeDataBase.RetrieveMaze(name2);
            mazeRetrieved.Solve(BestFS);
            Console.WriteLine(mazeRetrieved.name);
            Console.WriteLine(mazeRetrieved.ToMazeString(mazeRetrieved.start));
            Console.WriteLine(mazeRetrieved.start.location.i + " " + mazeRetrieved.start.location.j);
            Console.WriteLine(mazeRetrieved.end);
        }
    }
}
