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

        public void Insert(int data, AvlNode<int> node)
        {
            var currentNode = node;
            AvlNode<int> parent = null;
            while (currentNode != null)
            {
                parent = currentNode;
                if (data < currentNode.Data)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if(data > currentNode.Data)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return;
                }
            }

            var insertNode = new AvlNode<int>(data);
            if (insertNode.Data < parent.Data)
            {
                parent.LeftChild = insertNode;
            }
            else
            {
                parent.RightChild = insertNode;
            }

            insertNode.Parent = parent;
            insertNode.BlanceValue = default(int);

            currentNode = insertNode;
            parent = insertNode.Parent;

            while (parent != null)
            {
                if(currentNode == parent.LeftChild)
                {
                    parent.BlanceValue++;
                }
                else
                {
                    parent.BlanceValue--;
                }
                //如果parent 的Blancevalue 为0, 不需平衡，直接return
                if (parent.BlanceValue == 0)
                {
                    return;
                }
                else if (parent.BlanceValue == -1 || parent.BlanceValue == 1)
                {
                    currentNode = parent;
                    parent = parent.Parent;
                    continue;
                }
                else if (parent.BlanceValue == 2)
                {
                    //左左型
                    if (insertNode.Data < currentNode.LeftChild.Data)
                    {
                        //TODO: 右旋
                    }
                    //左右型
                    else
                    {
                        //TODO: 先左旋再右旋
                    }
                    break;
                }
                else if (parent.BlanceValue == -2)
                {
                    //右右型
                    if (insertNode.Data > currentNode.LeftChild.Data)
                    {
                        //TODO: 左旋
                    }
                    //右左型
                    else
                    {
                        //TODO: 先右旋再左旋
                    }
                    break;
                }
            }
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
        public AvlNode<T> Parent { get; set; }
        public int BlanceValue { get; set; }

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
