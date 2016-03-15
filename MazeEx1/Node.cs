using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class Node
    {
        Location location;
        Node left, right, up, down;
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
        public void SetValue(char value)
        {
            this.value = value;
        }
        public void SetLeft(Node leftNode)
        {
            this.left = leftNode;
        }
        public void SetRight(Node rightNode)
        {
            this.right = rightNode;
        }
        public void SetUp(Node upNode)
        {
            this.up = upNode;
        }
        public void SetDown(Node downNode)
        {
            this.down = downNode;
        }
        public Node GetLeft()
        {
            return this.left;
        }
        public Node GetRight()
        {
            return this.right;
        }
        public Node GetUp()
        {
            return this.up;
        }
        public Node GetDown()
        {
            return this.down;
        }
    }
}
