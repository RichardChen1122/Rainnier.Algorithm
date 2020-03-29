using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    class AnyTree
    {
        public void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Data);
                if (root.ChildNodes != null && root.ChildNodes.Count > 0)
                {
                    foreach(var node in root.ChildNodes)
                    {
                        PreOrder(node);
                    }
                }
            }
        }

        public TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            Stack<TreeNode> stackP = FindNodePath(root, p);
            Stack<TreeNode> stackQ = FindNodePath(root, q);

            TreeNode ret = null;

            if (stackP == null || stackQ == null)
            {
                Console.WriteLine("Please check your parameter");
            }

            var stackP2 = new Stack<TreeNode>();
            var stackQ2 = new Stack<TreeNode>();
            while (stackP.Count > 0)
            {
                stackP2.Push(stackP.Pop());
            }
            while (stackQ.Count > 0)
            {
                stackQ2.Push(stackQ.Pop());
            }

            while (stackP2.Count>0 && stackQ2.Count > 0)
            {
                var stackPTop = stackP2.Pop();
                var stackQTop = stackQ2.Pop();
                if (stackPTop == stackQTop)
                {
                    ret = stackPTop;
                }
            }

            return ret;
        }

        public Stack<TreeNode> FindNodePath(TreeNode root, TreeNode target)
        {
            var stackIn = new Stack<TreeNode>();
            var stackOut = new Stack<TreeNode>();

            if (root == null)
            {
                return null;
            }

            stackIn.Push(root);

            while (stackIn.Count > 0)
            {
                var stackInTop = stackIn.Pop();
                if(stackInTop.ChildNodes!=null && stackInTop.ChildNodes.Count > 0)
                {
                    foreach(var child in stackInTop.ChildNodes)
                    {
                        stackIn.Push(child);
                    }
                }

                if (stackOut.Count > 0)
                {
                    var stackOutTop = stackOut.Peek();

                    while (stackOut.Count > 0 && !(stackOutTop.ChildNodes!=null && stackOutTop.ChildNodes.Contains(stackInTop)))
                    {
                        stackOut.Pop();
                        stackOutTop = stackOut.Peek();
                    }
                }

                stackOut.Push(stackInTop);


                if (stackInTop == target)
                {
                    return stackOut;
                }
            }
            return null;
        }
    }
}
