using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.LinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            var listA = new MyLinkList<int>(1);
            listA.AppendAtTail(4);
            listA.AppendAtTail(7);
            listA.AppendAtTail(22);
            listA.AppendAtTail(30);
            listA.AppendAtTail(31);


            var listB = new MyLinkList<int>(1);
            listB.AppendAtTail(3);
            listB.AppendAtTail(8);
            listB.AppendAtTail(11);
            listB.AppendAtTail(29);
            listB.AppendAtTail(30);

            //listA.Output();

            //var t = Merge(listA, listB);cc
            var t2 = MergeRecursive(listA.Header, listB.Header);
            listB.Output(t2);
            Console.ReadKey();

        }

        static MyLinkList<int> Merge(MyLinkList<int> a, MyLinkList<int> b)
        {
            var pointA = a.Header;
            var pointB = b.Header;
            Node<int> current = new Node<int>();
            Node<int> header = pointA.Data <= pointB.Data ? pointA : pointB;

            while(pointA !=null && pointB != null)
            {
                if (pointA.Data <= pointB.Data)
                {
                    current.Next = pointA;
                    pointA = pointA.Next;
                }
                else
                {
                    current.Next = pointB;
                    pointB = pointB.Next;
                }
                current = current.Next;
            }

            if (pointA != null)
            {
                current.Next = pointA;
            }
            if (pointB != null)
            {
                current.Next = pointB;
            }

            var newLinkList = new MyLinkList<int>(header);

            return newLinkList;
        }

        static Node<int> MergeRecursive(Node<int> pointA, Node<int> pointB)
        {
            if (pointA == null)
            {
                return pointB;
            }
            if(pointB == null)
            {
                return pointA;
            }
            Node<int> header = null;
            if (pointA.Data <= pointB.Data)
            {
                header = pointA;
                header.Next = MergeRecursive(pointA.Next, pointB);

            }
            else
            {
                header = pointB;
                header.Next = MergeRecursive(pointA, pointB.Next);
            }

            return header;
        }
    }
}
