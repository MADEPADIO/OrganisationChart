using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCanvas
{
    public class NodePositionsManager
    {
        public List<NodePositions> StoreNodePositions { get; private set; }

        public NodePositionsManager()
        {
            StoreNodePositions = new List<NodePositions>();
        }

        // You can add methods here to manipulate the list if needed
        public void AddNodePosition(NodePositions nodePosition)
        {
            StoreNodePositions.Add(nodePosition);
        }
    }
}
