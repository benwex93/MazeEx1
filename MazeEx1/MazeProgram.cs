﻿using System;
namespace MazeEx1
{
    class MazeProgram
    {
        static IDataClass data;
        static MazeDataBase MDB;
        static GameDataBase GDB;
        static CharVals mazeVals;
        const int mazeSize = 25;
        public MazeProgram()
        {
            MDB = new MazeDataBase();
            GDB = new GameDataBase();
            mazeVals = new CharVals('S', 'E', '*', ' ', '█');
        }
        public static void GenerateMaze(string name, int generateType)
        {
            Maze maze = new Maze(name, mazeSize, mazeVals);
            if (generateType == 0)
                maze.CreateMaze(new RandomMazeMaker());
            else if (generateType == 1)
                maze.CreateMaze(new DFSMazeMaker());
            MDB.AddMaze(maze);
            data = new MazeDataClass(maze.name, maze.ToString(), new NodeDataClass(maze.start.location.row, maze.start.location.col),
                new NodeDataClass(maze.end.location.row, maze.end.location.col));
        }
        public static void SolveMaze(string name, int solveType)
        {
            SolutionDataClass mazeSolution = MDB.RetrieveMazeSolution(name);
            //maze is solved according to the solve type
            if (mazeSolution != null)
                data = mazeSolution;
            //maze is not solved according to the solve type
            else
            {
                Maze mazeToSolve = MDB.RetrieveMaze(name);
                if (solveType == 0)
                {
                    BreadthFSSolution breadthFS = new BreadthFSSolution();
                    mazeToSolve.SolveMaze(breadthFS);
                    MDB.SaveSolToFile(breadthFS);
                    data = new SolutionDataClass(name, breadthFS.solutionString,
                        new NodeDataClass(breadthFS.start.location.row, breadthFS.start.location.col),
                        new NodeDataClass(breadthFS.end.location.row, breadthFS.end.location.col));
                }
                else if (solveType == 1)
                {
                    BestFSSolution bestFS = new BestFSSolution();
                    mazeToSolve.SolveMaze(bestFS);
                    MDB.SaveSolToFile(bestFS);
                    data = new SolutionDataClass(name, bestFS.solutionString,
                        new NodeDataClass(bestFS.start.location.row, bestFS.start.location.col),
                        new NodeDataClass(bestFS.end.location.row, bestFS.end.location.col));
                }
            }
        }
        public static void Multiplayer(string name, int type)
        {
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
                data = new MultiplayerDataClass(game.name, game.mazeOne.name,
                    new MazeDataClass(game.mazeOne.name, game.mazeOne.ToString(),
                    new NodeDataClass(game.mazeOne.start.location.row, game.mazeOne.start.location.col),
                    new NodeDataClass(game.mazeOne.end.location.row, game.mazeOne.end.location.col)),
                    new MazeDataClass(game.mazeTwo.name, game.mazeTwo.ToString(),
                    new NodeDataClass(game.mazeTwo.start.location.row, game.mazeTwo.start.location.col),
                    new NodeDataClass(game.mazeTwo.end.location.row, game.mazeTwo.end.location.col)));
            }
        }
        public IDataClass GetData()
        {
            return data;
        }
    }
}
