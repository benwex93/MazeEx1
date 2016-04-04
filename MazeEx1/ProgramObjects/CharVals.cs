using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEx1
{
    class CharVals
    {
        public char startValue { get; set; }
        public char endValue { get; set; }
        public char solValue { get; set; }
        public char pathValue { get; set; }
        public char wallValue { get; set; }
        public CharVals(char startValue, char endValue, char solValue, char pathValue, char wallValue)
        {
            this.startValue = startValue;
            this.endValue = endValue;
            this.solValue = solValue;
            this.pathValue = pathValue;
            this.wallValue = wallValue;
        }
    }
}
