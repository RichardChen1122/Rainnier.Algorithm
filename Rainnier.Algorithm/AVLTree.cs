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

            if (subR.LeftChild == null)
            {
                parent.RightChild = null;
                subR.LeftChild = parent;
                parent.Parent = subR;
            }
            else
            {
                var subRL = subR.LeftChild;
                parent.RightChild = null;
                subR.LeftChild = parent;
                parent.Parent = subR;
                subRL.Parent = parent;
                parent.RightChild = subRL;
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
            }
            parent.BlanceValue = 0;
            subR.BlanceValue = 0;
            avlNode = subR;
        }

        private void rightRotate(AvlNode<int> avlNode)
        {
            var parent = avlNode;
            var grandParent = avlNode.Parent;
            var subL = parent.LeftChild;

            if (subL.RightChild == null)
            {
                parent.LeftChild = null;
                subL.RightChild = parent;
                parent.Parent = subL;
            }
            else
            {
                var subLR = subL.RightChild;
                parent.LeftChild = null;
                subL.RightChild = parent;
                parent.Parent = subL;
                parent.LeftChild = subLR;
                subLR.Parent = parent;
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
            }
            parent.BlanceValue = 0;
            subL.BlanceValue = 0;
            avlNode = subL;
        }

        private void leftRightRotate(AvlNode<int> avlNode)
        {
            var parent = avlNode;
            var subL = parent.LeftChild;
            var subLsubL = subL.LeftChild;

            var subLsubLR = subLsubL.RightChild;

            subL.LeftChild = subLsubLR;
            subLsubLR.Parent = subL;
            subLsubLR.LeftChild = subLsubL;
            subLsubL.Parent = subLsubLR;

            subLsubL.BlanceValue = 0;
            subLsubLR.BlanceValue = 1;

            rightRotate(parent);
        }

        private void rightLeftRotate(AvlNode<int> avlNode)
        {
            var parent = avlNode;
            var subR = parent.RightChild;
            if (subR.RightChild != null)
            {
                var subRsubR = subR.RightChild;
                var subRsubRL = subRsubR.LeftChild;

                subR.RightChild = subRsubRL;
                subRsubRL.Parent = subR;
                subRsubRL.RightChild = subRsubR;
                subRsubR.Parent = subRsubRL;

                subRsubR.BlanceValue = 0;
                subRsubRL.BlanceValue = -1;
            }
            else
            {
                var subRL = subR.LeftChild;
                parent.RightChild = subRL;
                subRL.Parent = parent;
                subRL.RightChild = subR;
                subR.Parent = subRL;
            }

            leftRotate(parent);
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
