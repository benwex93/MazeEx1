using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class MultiplayerDataClass
    {
        public string Name { get; set; }
        public string MazeName { get; set; }
        public MazeDataClass You { get; set; }
        public MazeDataClass Other { get; set; }
        public MultiplayerDataClass(string name, string mazeName, MazeDataClass you, MazeDataClass other)
        {
            this.Name = name;
            this.MazeName = mazeName;
            this.You = you;
            this.Other = other;
        }
        public override string ToString()
        {
            return (Name + "\n" + MazeName + "\n" + You + "\n" + Other);
        }
    }
}
