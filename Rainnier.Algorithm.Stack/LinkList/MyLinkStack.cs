using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Stack.LinkList
{
    public class MyLinkStack<T>
    {
        private Node<T> header;
        private int index;

        public MyLinkStack(T data)
        {
            header = new Node<T>(data);
            index = 1;
        }

        public MyLinkStack()
        {
            header = null;
            index = 0;
        }

        public T Peek()
        {
            return header.Data;
        }

        public T Pop()
        {
            var temp = header;
            header = header.Next;
            index--;
            return temp.Data;
        }

        public void Push(T data)
        {
            var pushNode = new Node<T>(data);
            pushNode.Next = header;

            header = pushNode;
        }

        public bool IsEmpty()
        {
            return header == null;
        }

        public class Node<T>
        {
            public T Data { get; set; }

            public Node<T> Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }

    }
}
