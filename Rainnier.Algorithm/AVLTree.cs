using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    public class AVLTree
    {
        AvlNode<int> root;

        public AvlNode<int> Root { get => root; }

        public AVLTree(AvlNode<int> rootNode)
        {
            root = rootNode;
        }

        #region 基本方法
        public bool IsEmpty()
        {
            return this.root == null;
        }

        public bool IsLeafNode(AvlNode<int> p)
        {
            if (p == null)
            {
                return false;
            }

            return p.LeftChild == null && p.RightChild == null;
        }

        public int GetDepth(AvlNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = GetDepth(node.LeftChild);
            int right = GetDepth(node.RightChild);
            return left >= right ? left + 1 : right + 1;
        }

        public AvlNode<int> FindMax()
        {
            AvlNode<int> maxNode = this.root;

            while (maxNode.RightChild != null)
            {
                maxNode = maxNode.RightChild;
            }

            return maxNode;
        }

        public (AvlNode<int>, AvlNode<int>) FindNode(int key)
        {
            if (root.Data == key)
            {
                return (root, null);
            }

            AvlNode<int> current = root;
            AvlNode<int> parent = null;

            while (current != null && current.Data != key)
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

            if (current == null)
            {
                return (null, null);
            }
            else
            {
                return (current, parent);
            }
        }
        #endregion 基本方法

        public AvlNode<int> Insert(int data, AvlNode<int> node)
        {
            if (node == null)
            {
                node = new AvlNode<int>(data);
                node.LeftChild = null;
                node.RightChild = null;
            }
            else if (data < node.Data)
            {
                node.LeftChild = Insert(data, node.LeftChild);
            }

            return node;
        }

        #region 旋转操作
        private void leftRotate(AvlNode<int> avlNode)
        {

        }
        #endregion
    }

    public class AvlNode<T>
    {
        public T Data { get; set; }
        public AvlNode<T> LeftChild { get; set; }
        public AvlNode<T> RightChild { get; set; }

        public int Height { get; set; }

        public AvlNode(T data)
        {
            Data = data;
        }

        public AvlNode(T data, AvlNode<T> left, AvlNode<T> right)
        {
            Data = data;
            LeftChild = left;
            RightChild = right;
        }
    }
}
