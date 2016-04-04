using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class GameDataBase
    {
        //creates game list so that playes can meet up for a certain game
        static List<Game> gameList;
        //constructor that creates a new list of games
        public GameDataBase()
        {
            gameList = new List<Game>();
        }
        //adds a new game to list. Called by first player to connect
        public void AddGame(Game gameToAdd)
        {
            gameList.Add(gameToAdd);
        }
        //retrieves a game if it's already been created. Called by second player to connect
        public Game RetrieveGame(string name)
        {
            foreach (Game game in gameList)
            {
                if (game.name == name)
                    return game;
            }
            //doesn't have that particular maze
            return null;
        }
    }
}
