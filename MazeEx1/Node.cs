using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Node
    {
        public Location location;
        public Node left, right, up, down;
        char value;
        public Node(int i, int j, char value)
        {
            location = new Location(i,j);
            this.value = value;
        }
        public Location getLocation()
        {
            return location;
        }
        public int getRow()
        {
            return location.GetRow();
        }
        public int getCol()
        {
            return location.GetCol();
        }
        public char GetValue()
        {
            return value;
        }
        public void setValue(char value)
        {
            this.value = value;
        }
    }
}
