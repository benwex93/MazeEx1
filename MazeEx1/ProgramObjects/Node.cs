using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Node
    {
        public Node(int col, int row, char val, int lenFromStart)
        {
            this.location = new Location(col, row);
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
            this.weight = Math.Abs(this.location.col - start.location.col) + Math.Abs(this.location.row - start.location.row);
        }
        public Node Clone()
        {
            Node nodeClone = new Node(this.location.col, this.location.row, this.value, this.lengthFromStart);
            nodeClone.weight = this.weight;
            nodeClone.specialVal = this.specialVal;
            return nodeClone;
        }
    }
}
