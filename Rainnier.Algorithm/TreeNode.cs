using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    class TreeNode
    {
        public int Data { get; set; }

        public List<TreeNode> ChildNodes { get; set; }

        public TreeNode(int data)
        {
            Data = data;
        }

        public TreeNode(int data, List<TreeNode> childs)
        {
            Data = data;
            ChildNodes = childs;
        }
        
    }
}
