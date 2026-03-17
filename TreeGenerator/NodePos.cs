using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator
{
    public class NodePos
    {
        public NodePos()
        {
            //throw new System.NotImplementedException();
        }
        private string _NodeID;

        public string NodeID
        {
            get { return _NodeID; }
            set { _NodeID = value; }
        }
        private System.Drawing.RectangleF _NodePosition;

        public System.Drawing.RectangleF NodePosition
        {
            get { return _NodePosition; }
            set { _NodePosition = value; }
        }


    }
}
