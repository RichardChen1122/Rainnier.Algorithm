using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.LinkList
{
    public class MyLinkList<T>
    {
        public Node<T> Header { get; set; }

        public MyLinkList(T data)
        {
            Header = new Node<T>(data);
        }

        public MyLinkList(Node<T> node)
        {
            Header = node;
        }
        #region 

        public Node<T> GetTailNode()
        {
            Node<T> tail = Header;
            while (tail.Next != null)
            {
                tail = tail.Next;
            }

            return tail;
        }

        public void AppendAtTail(T data)
        {
            var tailNode = GetTailNode();

            var newNode = new Node<T>(data);
            tailNode.Next = newNode;
        }

        public void Output()
        {
            var current = Header;
            while (current != null)
            {
                
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void Output(Node<T> node)
        {
            var current = node;
            while (current != null)
            {

                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        #endregion
    }
}
