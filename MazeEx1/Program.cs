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
            int generateType, solveType;
            string name;
            //must be between 2 and 75
            const int mazeSize = 10;
            CharVals mazeVals = new CharVals('S', 'E', '*', ' ', '█');

            //get client input here
            commandNum = 1; generateType = 0; solveType = 1; name = "";
            MazeDataBase MDB = new MazeDataBase();
            while (commandNum != 3)
            {
                Console.WriteLine("1. Create maze \n2. Solve created maze \n3. Quit");
                commandNum = (Console.Read()) - '0';
                Console.ReadLine();
                switch (commandNum)
                {
                    case 1:
                        Console.WriteLine("Please Enter Name of Maze To Create");
                        name = Console.ReadLine();
                        Maze maze = new Maze(name, mazeSize, mazeVals);
                        if (generateType == 0)
                            maze.CreateMaze(new RandomMazeMaker());
                        if (generateType == 1)
                            maze.CreateMaze(new DFSMazeMaker());
                        MDB.AddMaze(maze);
                        break;
                    case 2:
                        Console.WriteLine("Please Enter Name of Maze To Solve");
                        //tries to see if solution already exists
                        name = Console.ReadLine();
                        ISolution mazeSolution = MDB.RetrieveMazeSolution(name, solveType);
                        //maze is solved according to the solve type
                        if (mazeSolution != null)
                            Console.WriteLine(mazeSolution);
                        //maze is not solved according to the solve type
                        else
                        {
                            Maze mazeToSolve = MDB.RetrieveMaze(name);
                            if (mazeToSolve == null)
                                Console.WriteLine("Maze Does Not Exist or Has Not Been Solved or Has Not BeenSolved According to That Type");
                            else if (solveType == 0)
                            {
                                BreadthFSSolution breadthFS = new BreadthFSSolution();
                                mazeToSolve.SolveMaze(breadthFS);
                                MDB.SaveSolToFile(breadthFS);
                                Console.Write(breadthFS.ToString());
                            }
                            else if (solveType == 1)
                            {
                                BestFSSolution bestFS = new BestFSSolution();
                                mazeToSolve.SolveMaze(bestFS);
                                MDB.SaveSolToFile(bestFS);
                                Console.Write(bestFS.ToString());
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
