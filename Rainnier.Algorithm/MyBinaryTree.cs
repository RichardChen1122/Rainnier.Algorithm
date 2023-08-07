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
        //以下的LCA算法有Bug， 如果P或Q 不存在在这个树当中，则不能正确判断LCA
        public Node<T> LowestCommonAncestor(Node<T> root, Node<T> p, Node<T> q)
        {
            if (root == null || p == root || q == root)
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

        //使用非递归的方式,搜索到两个节点的路径，再对路径进行对比
        public Node<int> LSTNoRecursion(Node<int> root, Node<int> p, Node<int> q)
        {
            var stack1 = new Stack<Node<int>>();
            var stack2 = new Stack<Node<int>>();

            NodeSearch(root, stack1, p);
            NodeSearch(root, stack2, q);
            Node<int> result = null;

            while (stack1.Count > 0 && stack2.Count > 0)
            {
                var top1 = stack1.Pop();
                var top2 = stack2.Pop();
                if (top1 == top2)
                {
                    result = top1;
                }
            }

            return result;
        }

        //自己实现的递归方法检查是否是二分查找树
        //这个解法有明显bug，只判断了父节点是否大于左，小于右，而不是判断整个树
        public bool IsValidBSTMy(Node<int> root)
        {
            if (root == null) return true;

            var a = IsValidBSTMy(root.LeftChild);
            var b = IsValidBSTMy(root.RightChild);

            var left = false;
            var right = false;
            if (root.LeftChild == null || root.LeftChild.Data < root.Data)
                left = true;
            if (root.RightChild == null || root.RightChild.Data > root.Data)
                right = true;

            if (a && b && left && right)
            {
                return true;
            }

            return false;
        }



        public bool IsValidBST2(Node<int> root)
        {
            var current = root;
            int? previous = null;
            var tempStack = new Stack<Node<int>>();
            while (current != null)
            {
                tempStack.Push(current);
                current = current.LeftChild;
                while (current == null && tempStack.Count > 0)
                {
                    var top = tempStack.Pop();
                    if (previous != null && top.Data <= previous)
                    {
                        return false;
                    }
                    previous = top.Data;
                    current = top.RightChild;
                }
            }

            return true;
        }

        public bool IsValidBST3(Node<int> root)
        {
            int? previous = null;
            return midOrder(root, ref previous);

        }

        public bool midOrder(Node<int> root, ref int? previous)
        {
            bool result1 = true;
            bool result2 = true;
            if (root == null)
            {
                return true;
            }

            result1 = midOrder(root.LeftChild, ref previous);
            if (previous != null && root.Data <= previous)
            {
                return false;
            }
            previous = root.Data;
            result2 = midOrder(root.RightChild, ref previous);

            return result1 && result2;
        }

        public bool IsValidBST(Node<int> root)
        {
            return help2(root, int.MinValue, int.MaxValue);
        }


        private bool help2(Node<int> root, int lower, int higher)
        {
            if (root == null)
            {
                return true;
            }

            var a = help2(root.LeftChild, lower, root.Data);
            var b = help2(root.RightChild, root.Data, higher);
            if (root.Data >= higher || root.Data <= lower)
            {
                return false;
            }
            return a && b;
        }


        //和下面的MorrisTraverse2写法效果是一样的 (都是前序遍历)
        /*
         * 记作当前节点为cur。

            1. 如果cur无左孩子，cur向右移动（cur=cur.right）
            2. 如果cur有左孩子，找到cur左子树上最右的节点，记为mostright
                a.如果mostright的right指针指向空，让其指向cur，cur向左移动（cur=cur.left）
                b.如果mostright的right指针指向cur，让其指向空，cur向右移动（cur=cur.right）

            实现以上的原则，即实现了morris遍历。

        总结：
        默认都是优先往左走， 往右走需要满足的两种情况之一：
        1. cur 没有左孩子 （没有左子树）
        2. cur 的左子树的最右节点的右子树是当前节点（当前节点的左子树已被完全遍历过了）

        左子树的最右边的叶子节点的右节点用来存储当前的节点，当发现该节点为空时，就让它指向cur ， 然后往左走，
        等走啊走， 再走到这个最右边的这个节点的时候， 他就指向了之前存下来的那个节点， 就回溯上去了
         * 
         * 参考 https://zhuanlan.zhihu.com/p/101321696
         */
        public void MorrisTraverse(Node<int> current)
        {
            if (current == null)
            {
                return;
            }

            while (current != null)
            {
                if (current.LeftChild == null)
                {
                    Console.WriteLine(current.Data);
                    current = current.RightChild;
                }
                else
                {
                    var mostright = FindTheMostRightNode(current);

                    if (mostright.RightChild == null)
                    {
                        mostright.RightChild = current;

                        Console.WriteLine(current.Data);

                        current = current.LeftChild;
                    }
                    else
                    {
                        if (mostright.RightChild == current)
                        {
                            mostright.RightChild = null;
                            current = current.RightChild;
                        }
                    }
                }
            }
        }


        //和上面的写法效果是一样的
        public void MorrisTraverse2(Node<int> current)
        {
            if (current == null)
            {
                return;
            }

            Node<int> mostright = null;

            while (current != null)
            {
                mostright = current.LeftChild;
                if (mostright != null)
                {
                    while(mostright.RightChild != null&& mostright.RightChild != current)
                    {
                        mostright = mostright.RightChild;
                    }

                    if(mostright.RightChild == null)
                    {
                        mostright.RightChild= current;
                        Console.WriteLine(current.Data);
                        current = current.LeftChild;

                        continue;
                    }
                    else
                    {
                        mostright.RightChild = null;
                    }
                }
                else
                {
                    Console.WriteLine(current.Data);
                }
                current = current.RightChild;
            }
        }

        private Node<int> FindTheMostRightNode(Node<int> root)
        {
            var current = root.LeftChild;

            while (current.RightChild != null && current.RightChild != root)
            {
                current = current.RightChild;
            }

            return current;
        }


        #endregion

        #region 路径查找
        public bool NodeSearch(Node<int> root, Stack<Node<int>> stack, Node<int> searchNode)
        {
            if (root == null)
            {
                return false;
            }

            //#1放这里也可以

            var left = NodeSearch(root.LeftChild, stack, searchNode);
            var right = NodeSearch(root.RightChild, stack, searchNode);

            //这段代码#1放上面也可以--------------
            if (root == searchNode)
            {
                stack.Push(root);
                return true;
            }
            //-----------------------------------

            if (left || right)
            {
                stack.Push(root);
                return true;
            }
            return false;
        }
        public Node<int> NodeSearch2(Node<int> root, Stack<Node<int>> stack, Node<int> searchNode)
        {
            if (root == null)
            {
                return null;
            }

            //#1放这里也可以

            var left = NodeSearch2(root.LeftChild, stack, searchNode);
            var right = NodeSearch2(root.RightChild, stack, searchNode);

            //这段代码#1放上面也可以--------------
            if (root == searchNode)
            {
                stack.Push(root);
                return root;
            }
            //-----------------------------------

            if (left != null|| right!=null)
            {
                stack.Push(root);
                return root;
            }
            return null;
        }

        public void NodeSearchNoRecursion(Node<int> root, Stack<Node<int>> stack, Node<int> searchNode)
        {
            if (root == null || searchNode == null)
            {
                return;
            }

            var tempStack = new Stack<Node<int>>();
            tempStack.Push(root);

            while (tempStack.Count > 0)
            {
                var top = tempStack.Pop();
                if (top.LeftChild != null)
                {
                    tempStack.Push(top.LeftChild);
                }
                if (top.RightChild != null)
                {
                    tempStack.Push(top.RightChild);
                }

                while (stack.Count > 0 && stack.Peek().LeftChild != searchNode && stack.Peek().RightChild != searchNode)
                {
                    stack.Pop();
                }
                stack.Push(top);
            }

        }

        #endregion

        #region 经典算法题：在二叉树中找到累加和为指定值的最大路径长度
        //这个非递归的算法要一遍写出来没有bug
        //主要用到了非递归方法后续遍历+节点的路径搜索
        public int FindMaxSumLength(Node<int> root, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            Stack<Node<int>> stackIn = new Stack<Node<int>>();
            Stack<Node<int>> stackOut = new Stack<Node<int>>();
            int sum = 0;
            int maxLength = 0;

            map.Add(0, 0);
            stackIn.Push(root);

            while (stackIn.Count > 0)
            {
                var top = stackIn.Pop();

                if (top.LeftChild != null)
                {
                    stackIn.Push(top.LeftChild);
                }
                if (top.RightChild != null)
                {
                    stackIn.Push(top.RightChild);
                }
                while (stackOut.Count > 0 && stackOut.Peek().LeftChild != top && stackOut.Peek().RightChild != top)
                {
                    var stackOutTop = stackOut.Pop();
                    if (map.ContainsKey(sum))
                    {
                        map.Remove(sum);
                    }
                    sum = sum - stackOutTop.Data;
                }
                stackOut.Push(top);
                sum = sum + top.Data;
                if (!map.ContainsKey(sum))
                {
                    map.Add(sum, stackOut.Count);
                }

                if (map.TryGetValue(sum - target, out int val))
                {
                    maxLength = Math.Max(maxLength, stackOut.Count - val);
                }
            }
            return maxLength;
        }

        //递归方法
        public int FindMaxSumLengthRecursion(Node<int> root, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 0);
            return RecursionHelper(root, 1, 0, 0, target, map);
        }

        private int RecursionHelper(Node<int> root, int level, int preSum, int maxLen, int target, Dictionary<int, int> map)
        {
            if (root == null)
            {
                return maxLen;
            }

            int curSum = preSum + root.Data;

            if (map.TryGetValue(curSum - target, out int val))
            {
                maxLen = Math.Max(maxLen, level - val);
            }
            if (!map.ContainsKey(curSum))
            {
                map.Add(curSum, level);
            }

            var left = RecursionHelper(root.LeftChild, level + 1, curSum, maxLen, target, map);
            var right = RecursionHelper(root.RightChild, level + 1, curSum, maxLen, target, map);

            if (map.ContainsKey(curSum))
            {
                //这个判断很关键，第一次写的时候漏掉了，不能不管啥就删，必须是这层对应的值才能删
                if (level == map[curSum])
                {
                    map.Remove(curSum);
                }
            }

            return Math.Max(left, right);
        }
        #endregion

        #region 经典算法题：找到二叉树中的最大搜索二叉子树
        //自己写的，稍微有点傻，但是能用

        //这个过程中需要new 好多对象，额外的空间复杂度比较高，但是new 对象的个数不超过
        private struct ChildSearchTree
        {
            public Node<int> Root { get; set; }
            public int Size { get; set; }
            public int MaxNode { get; set; }
            public int MinNode { get; set; }
        }

        public Node<int> FindMaxChildSearchTree(Node<int> root)
        {
            var node = SearchHelp(root);

            return node.Root;
        }

        private ChildSearchTree SearchHelp(Node<int> root)
        {
            if (root == null)
            {
                return new ChildSearchTree()
                {
                    Root = null,
                    Size = 0,
                    MaxNode = int.MinValue
                };
            }
            var left = SearchHelp(root.LeftChild);
            var right = SearchHelp(root.RightChild);

            if (left.Root == root.LeftChild && right.Root == root.RightChild)
            {

                if (left.Root == null && right.Root == null)
                {
                    return new ChildSearchTree()
                    {
                        Root = root,
                        Size = left.Size + right.Size + 1,
                        MaxNode = root.Data,
                        MinNode = root.Data
                    };
                }
                else if (left.Root == null && right.Root != null)
                {
                    if (root.Data < right.MinNode)
                    {
                        return new ChildSearchTree()
                        {
                            Root = root,
                            Size = left.Size + right.Size + 1,
                            MaxNode = right.MaxNode,
                            MinNode = root.Data
                        };
                    }
                    else
                    {
                        return right;
                    }
                }
                else if (left.Root != null && right.Root == null)
                {
                    if (root.Data > left.MaxNode)
                    {
                        return new ChildSearchTree()
                        {
                            Root = root,
                            Size = left.Size + right.Size + 1,
                            MaxNode = root.Data,
                            MinNode = left.MinNode
                        };
                    }
                    else
                    {
                        return left;
                    }
                }
                else
                {
                    if (root.Data > left.MaxNode && root.Data < right.MinNode)
                    {
                        return new ChildSearchTree()
                        {
                            Root = root,
                            Size = left.Size + right.Size + 1,
                            MaxNode = right.MaxNode,
                            MinNode = left.MinNode
                        };
                    }
                    else
                    {
                        return left.Size > right.Size ? left : right;
                    }
                }
            }
            else
            {
                return left.Size > right.Size ? left : right;
            }
        }

        #endregion

        #region 经典算法题：判断一棵树是否是平衡二叉树
        public bool IsBalance(Node<int> root)
        {
            if (root == null)
            {
                return true;
            }
            return isBalanceHelp(root, 1).Item1;
        }

        private (bool, int) isBalanceHelp(Node<int> root, int level)
        {
            if (root == null)
            {
                return (true, level - 1);
            }
            var (left, leftlevel) = isBalanceHelp(root.LeftChild, level + 1);
            var (right, rightlevel) = isBalanceHelp(root.RightChild, level + 1);

            var leftheight = leftlevel - level;
            var rightheight = rightlevel - level;

            if (left && right && Math.Abs(leftheight - rightheight) <= 1)
            {
                return (true, leftlevel > rightlevel ? leftlevel : rightlevel);
            }

            return (false, leftlevel > rightlevel ? leftlevel : rightlevel);
        }

        public bool IsBalance2(Node<int> root)
        {
            bool ret = false;
            if (root == null)
            {
                return true;
            }
            isBalanceHelp2(root, ref ret);

            return ret;
        }

        private int isBalanceHelp2(Node<int> root, ref bool ret)
        {
            if (root == null)
            {
                return 0;
            }
            var left = isBalanceHelp2(root.LeftChild, ref ret);
            var right = isBalanceHelp2(root.RightChild, ref ret);

            if (Math.Abs(left - right) <= 1)
            {
                ret = true;
                return Math.Max(left, right) + 1;
            }
            else
            {
                ret = false;

                return Math.Max(left, right) + 1;
            }

        }
        #endregion

        #region 经典算法题：在二叉树中找到一个节点的后继节点
        //在二叉树的中序遍历中， node 的下一个节点就是后继节点
        public Node<int> FindNextNode(Node<int> root, Node<int> target)
        {
            var stack = new Stack<Node<int>>();
            Node<int> current = root;

            Node<int> result = null;

            while (current != null)
            {
                stack.Push(current);
                current = current.LeftChild;
                while (current == null && stack.Count > 0)
                {
                    if (result == target)
                    {
                        return stack.Peek();
                    }
                    result = stack.Pop();

                    current = result.RightChild;
                }
            }

            return null;
        }
        #endregion

        #region 经典算法题：二叉树中节点间的最大距离
        public int MaxDistanceBetweenNodes(Node<int> root)
        {
            int maxNum = int.MinValue;
            FindHelper(root, ref maxNum);

            return maxNum;
        }

        private int FindHelper(Node<int> root, ref int maxNum)
        {
            if (root == null)
            {
                maxNum = 0;
                return 0;
            }

            var leftLevel = FindHelper(root.LeftChild, ref maxNum);
            var rightLevel = FindHelper(root.RightChild, ref maxNum);

            maxNum = Math.Max(maxNum, leftLevel + rightLevel + 1);

            return leftLevel > rightLevel ? leftLevel + 1 : rightLevel + 1;
        }
        #endregion

        #region 经典算法题：二叉树是否是对称二叉树
        //这个算法是错的
        public bool IsSymmetric(Node<int> root)
        {
            Queue<Node<int>> queue = new Queue<Node<int>>();
            Stack<Node<int>> stack = new Stack<Node<int>>();

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item != null)
                {
                    queue.Enqueue(item.LeftChild);
                    queue.Enqueue(item.RightChild);
                }

                if (item == root)
                {
                    stack.Push(item);
                }
                else
                {
                    var stackTop = stack.Peek();
                    if (stackTop == null)
                    {
                        if (item == null)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(item);
                        }
                    }
                    else
                    {
                        if (item == null)
                        {
                            stack.Push(item);
                        }
                        else
                        {
                            if (item.Data == stackTop.Data)
                            {
                                stack.Pop();
                            }
                            else
                            {
                                stack.Push(item);
                            }
                        }
                    }
                }

            }
            if (stack.Count == 1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 经典算法题：序列化和反序列化二叉树
        StringBuilder stringBuilder = new StringBuilder("[");
        public string LevelOrderSeriliazeBinaryTree(Node<int> root)
        {
            StringBuilder stringBuilder2 = new StringBuilder("[");
            if (root == null)
            {
                return "[null]";
            }

            Queue<Node<int>> queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var top = queue.Dequeue();
                if (top != null)
                {
                    stringBuilder2.Append($"{top.Data},");
                    queue.Enqueue(top.LeftChild);
                    queue.Enqueue(top.RightChild);
                }
                else
                {
                    stringBuilder2.Append("null,");
                }

            }
            stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
            stringBuilder2.Append("]");
            return stringBuilder2.ToString();
        }

        public Node<int> LevelOrderDeserializeTree(string str)
        {
            str = str.Substring(1, str.Length - 2);
            string[] list = str.Split(',');
            Queue<Node<int>> queueIn = new Queue<Node<int>>();
            Queue<Node<int>> queueOut = new Queue<Node<int>>();
            foreach (var a in list)
            {
                if (a.Equals("null"))
                {
                    queueIn.Enqueue(null);
                }
                else
                {
                    queueIn.Enqueue(new Node<int>(int.Parse(a)));
                }

            }

            var root = queueIn.Dequeue();
            queueOut.Enqueue(root);

            if (queueIn.Count > 0)
            {
                while (queueIn.Count > 0)
                {
                    var head = queueOut.Dequeue();
                    if (head != null)
                    {
                        Node<int> left = null;
                        Node<int> right = null;
                        if (queueIn.Count > 0)
                        {
                            left = queueIn.Dequeue();
                        }
                        if (queueIn.Count > 0)
                        {
                            right = queueIn.Dequeue();
                        }
                        head.LeftChild = left;
                        head.RightChild = right;
                        queueOut.Enqueue(left);
                        queueOut.Enqueue(right);
                    }
                }
            }

            return root;
        }

        public string SeriliazeBinaryTree(Node<int> root)
        {
            seriliazeHelper(root);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        private void seriliazeHelper(Node<int> root)
        {
            if (root == null)
            {
                stringBuilder.Append("null,");
            }
            else
            {
                stringBuilder.Append($"{root.Data},");
                seriliazeHelper(root.LeftChild);
                seriliazeHelper(root.RightChild);
            }

        }

        public Node<int> DeserializeTree(string str)
        {
            str = str.Substring(1, str.Length - 2);
            string[] list = str.Split(',');
            int begin = 0;
            return deserializeHelper(list, ref begin);
        }

        private Node<int> deserializeHelper(string[] list, ref int begin)
        {
            if (begin >= list.Length)
            {
                return null;
            }
            if (list[begin].Equals("null"))
            {
                begin++;
                return null;
            }

            Node<int> node = new Node<int>(int.Parse(list[begin]));
            begin++;
            node.LeftChild = deserializeHelper(list, ref begin);
            node.RightChild = deserializeHelper(list, ref begin);

            return node;
        }
        #endregion

        #region 经典算法题：通过先序和中序数组生成后序数组
        public int[] GeneratePostOrderArray(int[] preOrder, int[] midOrder)
        {
            return generateHelper(preOrder, midOrder, 0, preOrder.Length - 1, 0, preOrder.Length - 1, preOrder.Length - 1);
        }

        private int[] generateHelper(int[] preOrder, int[] midOrder, int preBegin, int preEnd, int midBegin, int midEnd, int limit)
        {
            if (preBegin > limit)
            {
                return null;
            }
            if (preBegin == preEnd)
            {
                return new int[1] { preOrder[preBegin] };
            }
            var splitor = preOrder[preBegin];

            int midPosition = -1;
            for (int i = midBegin; i <= midEnd; i++)
            {
                if (midOrder[i] == splitor)
                {
                    midPosition = i;
                }
            }
            int offset = midPosition - midBegin;

            int[] left = generateHelper(preOrder, midOrder, preBegin + 1, preBegin + offset, midBegin, midPosition - 1, limit);
            int[] right = generateHelper(preOrder, midOrder, preBegin + offset + 1, preEnd, midPosition + 1, midEnd, limit);

            //以下是为了合并
            int a = 0;
            int b = 0;
            if (left != null)
            {
                a = left.Length;
            }
            if (right != null)
            {
                b = right.Length;
            }
            int[] ret = new int[a + b + 1];

            for (int i = 0; i < a; i++)
            {
                ret[i] = left[i];
            }

            for (int i = a; i < a + b; i++)
            {
                ret[i] = right[i - a];
            }

            ret[a + b] = splitor;

            return ret;

        }

        #endregion

        #region 经典算法题：通过先序和中序数组重构二叉树
        public Node<int> GenerateBinaryTree(int[] preOrder, int[] midOrder)
        {
            return generateTreeHepler(preOrder, midOrder, 0, preOrder.Length - 1, 0, preOrder.Length - 1, preOrder.Length - 1);
        }

        private Node<int> generateTreeHepler(int[] preOrder, int[] midOrder, int preStart, int preEnd, int midStart, int midEnd, int limit)
        {
            if (preStart > limit)
            {
                return null;
            }
            var root = new Node<int>(preOrder[preStart]);
            if (preEnd == preStart)
            {
                return root;
            }

            int splitPosition = -1;
            for (int i = midStart; i <= midEnd; i++)
            {
                if (midOrder[i] == preOrder[preStart])
                {
                    splitPosition = i;
                }
            }

            int offset = splitPosition - midStart;

            root.LeftChild = generateTreeHepler(preOrder, midOrder, preStart + 1, preStart + offset, midStart, splitPosition - 1, limit);
            root.RightChild = generateTreeHepler(preOrder, midOrder, preStart + offset + 1, preEnd, splitPosition + 1, midEnd, limit);


            return root;
        }
        #endregion

                                                                                                                                                            #region 经典算法题：通过先序和后序数组重构二叉树
        public Node<int> GenerateBinaryTree2(int[] preOrder, int[] postOrder)
        {
            return generateTreeHepler2(preOrder, postOrder, 0, preOrder.Length - 1, 0, postOrder.Length - 1, preOrder.Length - 1);
        }

        private Node<int> generateTreeHepler2(int[] preOrder, int[] postOrder, int preStart, int preEnd, int postStart, int postEnd, int limit)
        {
            if (preEnd > limit)
            {
                return null;
            }

            if (preStart == preEnd)
            {
                return new Node<int>(preOrder[preStart]);
            }



            var root = new Node<int>(preOrder[preStart]);

            var rootNext = preOrder[preStart + 1];

            int rootNextPosition = 0;
            for (int i = postStart; i <= postEnd; i++)
            {
                if (postOrder[i] == rootNext)
                {
                    rootNextPosition = i;
                }
            }

            int offset = rootNextPosition - postStart;

            root.LeftChild = generateTreeHepler2(preOrder, postOrder, preStart + 1, preStart + 1 + offset, postStart, postStart + offset, limit);
            root.RightChild = generateTreeHepler2(preOrder, postOrder, preStart + 2 + offset, preEnd, postStart + offset + 1, postEnd - 1, limit);

            return root;
        }
        #endregion
    }
}
