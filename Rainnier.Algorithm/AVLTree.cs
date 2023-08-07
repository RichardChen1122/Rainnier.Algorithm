using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    //平衡二叉搜索树
    public class AVLTree
    {
        AvlNode<int> root;

        public AvlNode<int> Root {
            get => root;
            set
            {
                root = value;
            }
        }

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

        public void Insert(int data)
        {
            var currentNode = Root;
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
                    if (insertNode.Data < currentNode.Data)
                    {
                        //TODO: 右旋
                        rightRotate(parent);
                    }
                    //左右型
                    else
                    {
                        //TODO: 先左旋再右旋
                        leftRightRotate(parent);
                    }
                    break;
                }
                else if (parent.BlanceValue == -2)
                {
                    //右右型
                    if (insertNode.Data > currentNode.Data)
                    {
                        //TODO: 左旋
                        leftRotate(parent);
                    }
                    //右左型
                    else
                    {
                        //TODO: 先右旋再左旋
                        rightLeftRotate(parent);
                    }
                    break;
                }
            }
        }

        #region 旋转操作
        private void leftRotate(AvlNode<int> avlNode)
        {
            var parent = avlNode;
            var grandParent = avlNode.Parent;
            var subR = parent.RightChild;

            var subRL = subR.LeftChild;
            parent.RightChild = subRL;
            parent.Parent = subR;
            subR.LeftChild = parent;

            if (subRL != null)
            {
                subRL.Parent = parent;
                parent.BlanceValue++;
            }
            else
            {
                parent.BlanceValue = parent.BlanceValue + 2;
            }

            if (grandParent == null)
            {
                subR.Parent = null;
                Root = subR;
            }
            else
            {
                if (parent.Data < grandParent.Data)
                {
                    grandParent.LeftChild = subR;
                }
                else
                {
                    grandParent.RightChild = subR;
                }
                subR.Parent = grandParent;
            }
            subR.BlanceValue ++;
            avlNode = subR;
        }

        private void rightRotate(AvlNode<int> avlNode)
        {
            var parent = avlNode;
            var grandParent = avlNode.Parent;
            var subL = parent.LeftChild;

            var subLR = subL.RightChild;
            parent.LeftChild = subLR;
            parent.Parent = subL;
            subL.RightChild = parent;

            if (subLR != null)
            {
                subLR.Parent = parent;
                parent.BlanceValue--;
            }
            else
            {
                parent.BlanceValue = parent.BlanceValue - 2;
            }

            if (grandParent == null)
            {
                subL.Parent = null;
                Root = subL;
            }
            else
            {
                if (parent.Data < grandParent.Data)
                {
                    grandParent.LeftChild = subL;
                }
                else
                {
                    grandParent.RightChild = subL;
                }
                subL.Parent = grandParent;
            }

            subL.BlanceValue--;
            avlNode = subL;
        }

        private void leftRightRotate(AvlNode<int> avlNode)
        {
            leftRotate(avlNode.LeftChild);

            rightRotate(avlNode);
        }

        private void rightLeftRotate(AvlNode<int> avlNode)
        {
            rightRotate(avlNode.RightChild);
            leftRotate(avlNode);
        }
        #endregion

        public void MidOrder(AvlNode<int> node)
        {
            if (node != null)
            {
                MidOrder(node.LeftChild);
                Console.WriteLine(node.Data.ToString());
                MidOrder(node.RightChild);
            }
        }

        public void LevelOrder(AvlNode<int> node)
        {
            if (node == null)
            {
                return;
            }

            var queue = new Queue<AvlNode<int>>();

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
