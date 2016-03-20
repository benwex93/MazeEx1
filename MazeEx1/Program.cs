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
            int commandNum;
            int generateType;
            string name;
            //must be between 2 and 75
            const int mazeSize =75;
            Maze mazeRetrieved;

            //get client input here
            commandNum = 1; generateType = 0; name = "Maze1";

            switch (commandNum)
            {
                case 1:
                    Maze maze = new Maze(name, mazeSize);
                    if (generateType == 0)
                        maze.CreateMaze(new RandomMazeMaker());
                    if (generateType == 1)
                        maze.CreateMaze(new DFSMazeMaker());
                    Console.Write(maze.ToString());
                    Console.Read();
                    //MazeDataBase.AddMaze(Maze);
                    //mazeRetrieved = MazeDataBase.RetrieveMaze(name);
                    //Console.WriteLine(mazeRetrieved.name);
                    //Console.WriteLine(mazeRetrieved.ToMazeString(mazeRetrieved.start, mazeRetrieved.mazeSize));
                    //Console.WriteLine(mazeRetrieved.start.location.i + " " + mazeRetrieved.start.location.j);
                    //Console.WriteLine(mazeRetrieved.end);
                    break;
                case 2:
                    mazeRetrieved = MazeDataBase.RetrieveMaze(name);
                    if (generateType == 0)
                        mazeRetrieved.Solve(new BreadthFSSolution());
                    if (generateType == 1)
                        mazeRetrieved.Solve(new BestFSSolution());
                    Console.WriteLine(mazeRetrieved.name);
                    Console.WriteLine(mazeRetrieved.ToString());
                    Console.WriteLine(mazeRetrieved.start.location.i + " " + mazeRetrieved.start.location.j);
                    Console.WriteLine(mazeRetrieved.end);
                    break;
                default:
                    break;
            }
        }
    }
}
