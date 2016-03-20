﻿using System;
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
        public Node left { get; set; }
        public Node right { get; set; }
        public Node up { get; set; }
        public Node down { get; set; }
        public Location location { get; set; }
        public char value { get; set; }
        public char specialVal { get; set; }
        public int lengthFromStart { get; set; }
    }
}
