using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Game
    {
        public string name { get; }
        public Maze mazeOne { get; set; }
        public Maze mazeTwo { get; set; }
        public Game(string name, int mazeSize, CharVals mazeVals)
        {
            this.name = name;
            mazeOne = new Maze(name + "playerOne", mazeSize, mazeVals);
            mazeOne.CreateMaze(new DFSMazeMaker());
        }
        public void AddSecondPlayer()
        {
            mazeTwo = mazeOne.Clone();
            mazeTwo.name = name + "playerTwo";
            ShiftStart(mazeOne, mazeTwo);
        }
        public void ShiftStart(Maze mazeOne, Maze mazeTwo)
        {
            mazeTwo.start.specialVal = mazeTwo.mazeVals.pathValue;
            Node temp = mazeTwo.start.Clone();
            if (mazeTwo.start.left != null)
            {
                mazeTwo.start = mazeTwo.start.left;
                temp.left = null;
                mazeTwo.start.right = temp;
            }
            else if (mazeTwo.start.right != null)
            {
                mazeTwo.start = mazeTwo.start.right;
                temp.right = null;
                mazeTwo.start.left = temp;
            }
            else if (mazeTwo.start.up != null)
            {
                mazeTwo.start = mazeTwo.start.up;
                temp.up = null;
                mazeTwo.start.down = temp;
            }
            else if (mazeTwo.start.down != null)
            {
                mazeTwo.start = mazeTwo.start.down;
                temp.down = null;
                mazeTwo.start.up = temp;
            }
            mazeTwo.start.specialVal = mazeTwo.mazeVals.startValue;
        }
    }
}
