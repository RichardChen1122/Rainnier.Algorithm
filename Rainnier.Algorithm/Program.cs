using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //build test tree

            var rootNode = new Node<int>(10);
            var rootNode2 = new Node<int>(1);

            var testTree = new MyBinaryTree<int>(rootNode2);
            testTree.InsertLeft(rootNode2, 1);
            //var node2 = testTree.InsertLeft(rootNode, 5);
            //var node3 = testTree.InsertRight(rootNode, 15);
            //var node5 = testTree.InsertLeft(node3, 6);
            //var node6 = testTree.InsertRight(node3, 20);
            Console.WriteLine(MyBinaryTree<int>.count);

            Console.WriteLine(testTree.IsValidBST3(rootNode2));
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


            Console.ReadKey();
        }
    }
}
