using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MazeEx1
{
    class SolutionDataClass
    {
        public string Name { get; set; }
        public string Maze { get; set; }
        public NodeDataClass Start { get; set; }
        public NodeDataClass End { get; set; }
        public SolutionDataClass(string name, string mazeString, NodeDataClass start, NodeDataClass end)
        {
            this.Name = name;
            this.Maze = mazeString;
            this.Start = start;
            this.End = end;
        }
        public override string ToString()
        {
            return (Name + "\n" + Start.Row + "\n" + Start.Col + "\n" + End.Row + "\n" + End.Col + "\n" + Maze);
        }
    }
}
