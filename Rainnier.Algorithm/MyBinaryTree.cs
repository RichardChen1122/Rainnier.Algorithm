using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    public class MyBinaryTree<T>
    {
        public static int count = 0;
        Node<T> root;

        public Node<T> Root { get => root; }

        public MyBinaryTree(Node<T> rootNode)
        {
            root = rootNode;
        }

        #region 基本方法
        public bool IsEmpty()
        {
            return this.root == null;
        }

        public Node<T> InsertLeft(Node<T> p, T data)
        {
            var tempNode = new Node<T>(data);
            if (p != null && p.LeftChild != null)
            {
                tempNode.LeftChild = p.LeftChild;
            }

            p.LeftChild = tempNode;

            return tempNode;
        }

        public Node<T> InsertRight(Node<T> p, T data)
        {
            var tempNode = new Node<T>(data);
            if (p != null && p.RightChild != null)
            {
                tempNode.RightChild = p.RightChild;
            }

            p.RightChild = tempNode;

            return tempNode;
        }

        public Node RemoveLeftTree(Node p)
        {
            if (p == null || p.LeftChild == null)
            {
                return null;
            }

            var temp = p.LeftChild;
            p.LeftChild = null;

            return temp;
        }

        public Node RemoveRightTree(Node p)
        {
            if (p == null || p.RightChild == null)
            {
                return null;
            }

            var temp = p.RightChild;
            p.RightChild = null;

            return temp;
        }

        public int GetDepth(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = GetDepth(node.LeftChild);
            int right = GetDepth(node.RightChild);
            return left >= right ? left + 1 : right + 1;
        }

        public bool IsLeafNode(Node p)
        {
            if (p == null)
            {
                return false;
            }

            return p.LeftChild == null && p.RightChild == null;
        }

        #endregion

        #region 递归遍历算法
        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Data.ToString());
                PreOrder(node.LeftChild);
                PreOrder(node.RightChild);
            }
        }

        public void MidOrder(Node<T> node)
        {
            
            if (node != null)
            {
                count++;
                MidOrder(node.LeftChild);
                Console.WriteLine(node.Data.ToString());
                MidOrder(node.RightChild);
            }
        }

        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                PostOrder(node.LeftChild);
                PostOrder(node.RightChild);
                Console.WriteLine(node.Data.ToString());
            }
        }

        #endregion

        #region 非递归遍历算法

        public void NoRecursionPreOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<Node<T>>();
            stack.Push(node);

            while (node != null && stack.Count > 0)
            {
                //遍历栈顶节点的元素
                var temp = stack.Pop();
                Console.WriteLine(temp.Data);

                //先压入右节点
                if (temp.RightChild != null)
                {
                    stack.Push(temp.RightChild);
                }
                //后压入左侧节点
                if (temp.LeftChild != null)
                {
                    stack.Push(temp.LeftChild);
                }
            }
        }

        public void NoRecursionMidOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<Node<T>>();

            var currentNode = root;
            while (currentNode != null)
            {
                //顺序压入左元素
                stack.Push(currentNode);
                currentNode = currentNode.LeftChild;
                while (currentNode == null && stack.Count > 0)
                {

                    var peekNode = stack.Pop();
                    Console.WriteLine(peekNode.Data);
                    currentNode = peekNode.RightChild;
                }
            }
        }

        public void NoRecursionPostOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            var stackOut = new Stack<Node<T>>();
            var stackIn = new Stack<Node<T>>();

            stackOut.Push(node);

            while (stackOut.Count > 0)
            {
                var tempNode = stackOut.Pop();
                stackIn.Push(tempNode);
                if (tempNode.LeftChild != null)
                {
                    stackOut.Push(tempNode.LeftChild);
                }
                if (tempNode.RightChild != null)
                {
                    stackOut.Push(tempNode.RightChild);
                }
            }

            while (stackIn.Count > 0)
            {
                Console.WriteLine(stackIn.Pop().Data);
            }
        }

        public void LevelOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            var queue = new Queue<Node<T>>();

            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var first = queue.Dequeue();
                Console.WriteLine(first.Data);
                if (first.LeftChild != null)
                {
                    queue.Enqueue(first.LeftChild);
                }
                if (first.RightChild != null)
                {
                    queue.Enqueue(first.RightChild);
                }
            }
        }
        #endregion

        #region 其他算法问题
        public Node<T> LowestCommonAncestor(Node<T> root, Node<T> p, Node<T> q)
        {
            if (root == null || p == root || q == root)
            {
                return root;

            }

            var left = LowestCommonAncestor(root.LeftChild, p, q);
            var right = LowestCommonAncestor(root.RightChild, p, q);
            if(left!=null && right != null)
            {
                return root;
            }
            return left == null ? right : left;
        }
    

        #endregion
    }
}
