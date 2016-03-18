using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    //turn into abstract class for methods that are identical for all solvers marking methods that are individually implemented as abstract
    //or default methods that might be overriden as virtual
    interface ISolution
    {
        void SolveMaze(Maze maze);

    }
}
