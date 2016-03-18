using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Node
    {
        public Node(int i, int j, char value)
        {
            this.location = new Location(i,j);
            this.value = value;
        }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node up { get; set; }
        public Node down { get; set; }
        public Location location { get; set; }
        public char value { get; set; }
    }
}
