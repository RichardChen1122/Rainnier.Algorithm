using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    class Test
    {
        public string A { get; set; }
    }

    struct TestStruct
    {
        public Test kk;

        public string Method()
        {
            return "e";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 2147483647;
            int k = a+1;

            TestStruct tt;

            tt.kk = new Test();


            //Console.WriteLine(tt.Method());
            //AnyTreeTest();
            BinaryTreeTest();
            //build test tree


            Console.ReadKey();
        }
        static void BinaryTreeTest()
        {
            var stack = new Stack<Node<int>>();

            var rootNode = new Node<int>(10);
            var rootNode2 = new Node<int>(1);

            var testTree = new MyBinaryTree<int>(rootNode);
            //testTree.InsertLeft(rootNode, 1);
            var node2 = testTree.InsertLeft(rootNode, 5);
            var node21 = testTree.InsertLeft(node2, 1);
            var node22 = testTree.InsertRight(node2, 8);
            var node221 = testTree.InsertLeft(node22, 6);
            var node222 = testTree.InsertRight(node22, 9);
            //var node2222 = testTree.InsertRight(node222, 100);
            var node3 = testTree.InsertRight(rootNode, 12);
            var node5 = testTree.InsertLeft(node3, 11);
            var node6 = testTree.InsertRight(node3, 13);
            // var node62 = testTree.InsertRight(node6, 15);
            //var node62 = testTree.InsertRight(node6, 0);
            //var node622 = testTree.InsertRight(node62, 23);

            testTree.MorrisTraverse(rootNode);
          
            var str = testTree.LevelOrderSeriliazeBinaryTree(rootNode);
            int[] preOrder = new int[9] { 10, 5, 1, 8, 6, 9, 12, 11, 13 };
            int[] midOrder = new int[9] { 1, 5, 6, 8, 9, 10, 11, 12, 13 };
            int[] postOrder = new int[9] { 1, 6, 9, 8, 5, 11, 13, 12, 10 };

            var restu = testTree.GenerateBinaryTree2(preOrder, postOrder);

            var nodeDeserial = testTree.LevelOrderDeserializeTree("[10,9,8]");
            var maxDistance = testTree.MaxDistanceBetweenNodes(rootNode);
            var reeeeee = testTree.FindNextNode(rootNode, node222);
            var isBalance = testTree.IsBalance(rootNode);
            var pur = testTree.FindMaxChildSearchTree(rootNode);
            Console.WriteLine(pur.Data);
            Console.WriteLine(testTree.FindMaxSumLengthRecursion(rootNode, -12));
            //Console.WriteLine(testTree.NodeSearch(rootNode, stack, node5));
            //Console.WriteLine(testTree.LSTNoRecursion(rootNode, node3, node62).Data);


            Console.WriteLine(MyBinaryTree<int>.count);

            Console.WriteLine(testTree.IsValidBST(rootNode));
            testTree.MidOrder(rootNode);
            //Console.WriteLine(testTree.LowestCommonAncestor(rootNode, node5, node62));
            //Console.Write(testTree.GetDepth(rootNode));
            //var rootNode2 = new Node(50);
            //var testSearchTree = new MyBinarySearchTree(rootNode2);


            //testSearchTree.Insert(30);
            //testSearchTree.Insert(70);
            //testSearchTree.Insert(11);
            //testSearchTree.Insert(41);
            //testSearchTree.Insert(51);
            //testSearchTree.Insert(71);
            //testSearchTree.Insert(35);
            //testSearchTree.Insert(46);
            //testSearchTree.Insert(52);
            //testSearchTree.Insert(81);
            //testSearchTree.Insert(77);

            //var test = testSearchTree.LCAForBSTNoRecursive(rootNode2, 54, 78);
            //Console.Write(test.Data);

            //var root3 = new AvlNode<int>(3);
            //var avlTree = new AVLTree(root3);
            //avlTree.Insert(2);
            //avlTree.Insert(1);
            //avlTree.Insert(4);
            //avlTree.Insert(5);
            //avlTree.Insert(6);

            //avlTree.Insert(7);
            //avlTree.Insert(10);
            //avlTree.Insert(9);
            //avlTree.Insert(8);

            //avlTree.LevelOrder(avlTree.Root);

        }

        static void AnyTreeTest()
        {
            TreeNode root = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node2.ChildNodes = new List<TreeNode>();
            node2.ChildNodes.Add(node5);
            node2.ChildNodes.Add(node6);

            root.ChildNodes = new List<TreeNode>();
            root.ChildNodes.Add(node2);
            root.ChildNodes.Add(node3);
            root.ChildNodes.Add(node4);

            var tree = new AnyTree();
            tree.PreOrder(root);
            var lca = tree.LCA(root, node5, node6);
        }
    }
}
