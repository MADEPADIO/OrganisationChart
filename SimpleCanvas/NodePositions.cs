using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCanvas
{
    public class NodePositions
    {
        public string ID {get; set;}
        public double Top { get; set;}
        public double Left { get; set;}

        public List<NodePositions> storeNodePositions = new List<NodePositions>();
    }

}
