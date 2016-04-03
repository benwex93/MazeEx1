using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Node
    {
        public Node(int i, int j, char val, int lenFromStart)
        {
            this.location = new Location(i,j);
            this.value = val;
            this.lengthFromStart = lenFromStart;
        }
        public Location location { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node up { get; set; }
        public Node down { get; set; }
        public Node prevNode { get; set; }

        public int weight { get; set; }
        public char value { get; set; }
        //used for assigning start and end nodes and also for creating the branching off of the main path when creating the random maze
        public char specialVal { get; set; }
        //used for calculating end so that it is far away from start
        public int lengthFromStart { get; set; }
        public void setWeight(Node start)
        {
            this.weight = Math.Abs(this.location.i - start.location.i) + Math.Abs(this.location.j - start.location.j);
        }
    }
}
