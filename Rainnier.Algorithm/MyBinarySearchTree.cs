using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    public class MyBinarySearchTree
    {
        Node root;

        public Node Root { get => root; }

        public MyBinarySearchTree(Node rootNode)
        {
            root = rootNode;
        }

        #region 基本方法
        public bool IsEmpty()
        {
            return this.root == null;
        }

        public Node FindMax()
        {
            Node maxNode = this.root;

            while(maxNode.RightChild != null)
            {
                maxNode = maxNode.RightChild;
            }

            return maxNode;
        }

        public (Node,Node) FindNode(int key)
        {
            if (root.Data == key)
            {
                return (root, null);
            }

            Node current = root;
            Node parent = null;

            while (current!=null && current.Data != key)
            {
                if (current.Data < key)
                {
                    parent = current;
                    current = current.RightChild;
                }
                else
                {
                    parent = current;
                    current = current.LeftChild;
                }
            }

            if(current==null)
            {
                return (null, null);
            }
            else
            {
                return (current, parent);
            }

            
        }

        public void Insert(int data)
        {
            var currentNode = this.root;
            Node parentNode = null;

            while (currentNode != null)
            {
                parentNode = currentNode;
                if (currentNode.Data < data)
                {
                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Data > data)
                {
                    currentNode = currentNode.LeftChild ;
                }
                else
                {
                    return;
                }
            }

            var insertNode = new Node(data);
            if (parentNode.Data < data)
            {
                parentNode.RightChild = insertNode;
            }
            if (parentNode.Data > data)
            {
                parentNode.LeftChild = insertNode;
            }
        }

        public void Remove(int data)
        {
            throw new NotImplementedException();
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
        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Data.ToString());
                PreOrder(node.LeftChild);
                PreOrder(node.RightChild);
            }
        }

        public void MidOrder(Node node)
        {
            if (node != null)
            {
                MidOrder(node.LeftChild);
                Console.WriteLine(node.Data.ToString());
                MidOrder(node.RightChild);
            }
        }

        public void PostOrder(Node node)
        {
            if (node != null)
            {
                MidOrder(node.LeftChild);
                MidOrder(node.RightChild);
                Console.WriteLine(node.Data.ToString());
            }
        }

        #endregion

        #region 非递归遍历算法

        public void NoRecursionPreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<Node>();
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

        public void NoRecursionMidOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<Node>();

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

        public void NoRecursionPostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            var stackOut = new Stack<Node>();
            var stackIn = new Stack<Node>();

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

        public void LevelOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            var queue = new Queue<Node>();

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
        //以下的LCA算法都有Bug， 如果P或Q 不存在在这个树当中，则不能正确判断LCA
        //非搜索树的通用算法
        public Node LowestCommonAncestor(Node root, int p, int q)
        {
            if (root == null || p == root.Data || q == root.Data)
            {
                return root;

            }

            var left = LowestCommonAncestor(root.LeftChild, p, q);
            var right = LowestCommonAncestor(root.RightChild, p, q);
            if (left != null && right != null)
            {
                return root;
            }
            return left == null ? right : left;
        }

        //针对搜索树的优化算法
        public Node LowestCommonAncestorForBST(Node root, int p, int q)
        {

            if (p > root.Data && q > root.Data)
            {
                root = LowestCommonAncestorForBST(root.RightChild, p, q);
            }

            if (p < root.Data && q < root.Data)
            {
                root = LowestCommonAncestorForBST(root.LeftChild, p, q);
            }

            return root;
        }

        //针对搜索树的优化算法(非递归算法)
        public Node LCAForBSTNoRecursive(Node root, int p, int q)
        {

            while ((p - root.Data) * (q - root.Data) > 0)
            {
                if (p > root.Data && q > root.Data)
                {
                    root = root.RightChild;
                }
                else
                {
                    root = root.LeftChild;
                }
            }

            return root;
        }

        //public int getLongestSumPath(Node root, int sum)
        //{
        //    Dictionary<int, int> sumMap = new Dictionary<int, int>();

            

        //}

        //public int RescuriveGetLongest(Node root, int sum, Dictionary<int,int> sumMap, int level)
        //{
        //    if (root == null)
        //    {
        //        return 
        //    }
        //}

        #endregion
    }
    public class Node
    {
        public int Data { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        public Node(int data, Node left, Node right)
        {
            Data = data;
            LeftChild = left;
            RightChild = right;
        }
    }

    public class NodeCombo
    {
        public Node Parent { get; set; }
        public Node Current { get; set; }
    }
}
