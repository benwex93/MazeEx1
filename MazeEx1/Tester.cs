using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Tester
    {
        static void Main(string[] args)
        {
            int commandNum;
            int generateType, solveType;
            string name;
            //must be between 2 and 75
            const int mazeSize = 3;
            CharVals mazeVals = new CharVals('S', 'E', '*', ' ', '█');

            //get client input here
            commandNum = 1; generateType = 1; solveType = 1; name = "";
            MazeDataBase MDB = new MazeDataBase();
            GameDataBase GDB = new GameDataBase();
            while (commandNum != 5)
            {
                Console.WriteLine("1. Create maze \n2. Solve created maze \n3. Multiplayer \n4. Move \n5. Quit");
                commandNum = (Console.Read()) - '0';
                Console.ReadLine();
                switch (commandNum)
                {
                    case 1:
                        Console.WriteLine("Please Enter Name of Maze To Create");
                        name = Console.ReadLine();
                        Console.WriteLine("Please Enter Type of Maker: 0 - Random, 1 - DFS");
                        generateType = Int32.Parse(Console.ReadLine());
                        Maze maze = new Maze(name, mazeSize, mazeVals);
                        if (generateType == 0)
                            maze.CreateMaze(new RandomMazeMaker());
                        else if (generateType == 1)
                            maze.CreateMaze(new DFSMazeMaker());
                        MDB.AddMaze(maze);
                        MazeDataClass MazeDC = new MazeDataClass(maze.name, maze.ToString(), new NodeDataClass(maze.start.location.row, maze.start.location.col),
                            new NodeDataClass(maze.end.location.row, maze.end.location.col));
                        Console.Write(MazeDC);
                        break;
                    case 2:
                        Console.WriteLine("Please Enter Name of Maze To Solve: 0 - Random, 1 - DFS");
                        //tries to see if solution already exists
                        name = Console.ReadLine();
                        Console.WriteLine("Please Type of Solution");
                        solveType = Int32.Parse(Console.ReadLine());
                        SolutionDataClass mazeSolution = MDB.RetrieveMazeSolution(name);
                        //maze is solved according to the solve type
                        if (mazeSolution != null)
                            Console.WriteLine(mazeSolution);
                        //maze is not solved according to the solve type
                        else
                        {
                            Maze mazeToSolve = MDB.RetrieveMaze(name);
                            if (mazeToSolve == null)
                                Console.WriteLine("Maze Does Not Exist or Has Not Been Solved");
                            else if (solveType == 0)
                            {
                                BreadthFSSolution breadthFS = new BreadthFSSolution();
                                mazeToSolve.SolveMaze(breadthFS);
                                MDB.SaveSolToFile(breadthFS);
                                SolutionDataClass SolDC = new SolutionDataClass(name, breadthFS.solutionString, 
                                    new NodeDataClass(breadthFS.start.location.row, breadthFS.start.location.col),
                                    new NodeDataClass(breadthFS.end.location.row, breadthFS.end.location.col));
                                Console.Write(SolDC);
                            }
                            else if (solveType == 1)
                            {
                                BestFSSolution bestFS = new BestFSSolution();
                                mazeToSolve.SolveMaze(bestFS);
                                MDB.SaveSolToFile(bestFS);
                                SolutionDataClass SolDC = new SolutionDataClass(name, bestFS.solutionString,
                                    new NodeDataClass(bestFS.start.location.row, bestFS.start.location.col),
                                    new NodeDataClass(bestFS.end.location.row, bestFS.end.location.col));
                                Console.Write(SolDC);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Please Enter Name of Game To Create");
                        //tries to see if solution already exists
                        name = Console.ReadLine();
                        Game game = GDB.RetrieveGame(name);
                        if (game == null)
                        {
                            game = new Game(name, mazeSize, mazeVals);
                            GDB.AddGame(game);
                        }
                        else {
                            game.AddSecondPlayer();
                            MDB.AddMaze(game.mazeOne);
                            MDB.AddMaze(game.mazeTwo);
                            MultiplayerDataClass MultiDC = new MultiplayerDataClass(game.name, game.mazeOne.name,
                                new MazeDataClass(game.mazeOne.name, game.mazeOne.ToString(),
                                new NodeDataClass(game.mazeOne.start.location.row, game.mazeOne.start.location.col),
                                new NodeDataClass(game.mazeOne.end.location.row, game.mazeOne.end.location.col)),
                                new MazeDataClass(game.mazeTwo.name, game.mazeTwo.ToString(),
                                new NodeDataClass(game.mazeTwo.start.location.row, game.mazeTwo.start.location.col),
                                new NodeDataClass(game.mazeTwo.end.location.row, game.mazeTwo.end.location.col)));

                            Console.WriteLine(MultiDC);
                        }
                        break;
                    case 4:
                        // Console.WriteLine("Please Enter Your Move");
                        //tries to see if solution already exists
                        //name = Console.ReadLine();
                        Console.WriteLine("Please Enter Name of Maze To Solve");
                        //tries to see if solution already exists
                        name = Console.ReadLine();
                        Maze test = MDB.RetrieveMaze(name);
                        Maze test2 = test.Clone();
                        if (test == null)
                            Console.WriteLine("Maze Does Not Exist or Has Not Been Solved");
                        else 
                        {
                            BreadthFSSolution breadthFS = new BreadthFSSolution();
                            test.SolveMaze(breadthFS);
                            MDB.SaveSolToFile(breadthFS);
                            Console.WriteLine(breadthFS.solutionString);

                            BestFSSolution bestFS = new BestFSSolution();
                            test2.SolveMaze(bestFS);
                            MDB.SaveSolToFile(bestFS);
                            Console.WriteLine(bestFS.solutionString);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
