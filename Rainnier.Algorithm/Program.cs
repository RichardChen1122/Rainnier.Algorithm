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
            var rootNode = new Node<int>(1);
            var testTree = new MyBinaryTree<int>(rootNode);
            var node2 = testTree.InsertLeft(rootNode, 2);
            var node3 = testTree.InsertRight(rootNode, 3);
            var node4 = testTree.InsertLeft(node2, 4);
            var node5 = testTree.InsertRight(node2, 5);
            var node7 = testTree.InsertLeft(node5, 7);
            var node6 = testTree.InsertRight(node3, 6);

            //Console.Write(testTree.GetDepth(rootNode));
            var rootNode2 = new Node(50);
            var testSearchTree = new MyBinarySearchTree(rootNode2);

            testSearchTree.Insert(30);
            testSearchTree.Insert(70);
            testSearchTree.Insert(11);
            testSearchTree.Insert(41);
            testSearchTree.Insert(51);
            testSearchTree.Insert(71);
            testSearchTree.Insert(35);
            testSearchTree.Insert(46);
            testSearchTree.Insert(52);
            testSearchTree.Insert(81);
            testSearchTree.Insert(77);

            var test = testSearchTree.FindMax();
            Console.Write(test.Data);
            Console.ReadKey();
        }
    }
}
