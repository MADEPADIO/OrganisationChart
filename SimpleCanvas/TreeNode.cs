using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCanvas
{
    public class TreeNode
    {
        public string ID {get; set;}
        public List<string> ChildrenIDs {get; set;} = new List<string>();
        
        //public TreeNode ()
        //{ ChildrenIDs = new List<TreeNode>(); }

        //// Method to add a child node with ID and a list of children
        //public void AddChildNode(string childID, List<TreeNode> childrenNodes)
        //{
        //    TreeNode childNode = new TreeNode { ID = childID, ChildrenIDs = childrenNodes };
        //    ChildrenIDs.Add(childNode);
        //}
    }
}
