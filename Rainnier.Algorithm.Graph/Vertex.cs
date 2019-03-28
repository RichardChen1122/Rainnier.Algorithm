using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Graph
{
    internal class MyAdjacencyGraph<T>
    {
        public List<Vertex<T>> vertexList;

        public MyAdjacencyGraph(int size)
        {
            vertexList = new List<Vertex<T>>(size);
        }

        public void AddVertex(T data)
        {
            if (contains(data))
            {
                throw new ArgumentException("Already have this value.");
            }

            var newVertex = new Vertex<T>(data);

            vertexList.Add(newVertex);
        }

        public void AddEdge(T from, T to)
        {
            var vertexFrom = Find(from);
            var vertexTo = Find(to);
            if (vertexFrom == null)
            {
                throw new ArgumentException("not find in list");
            }
            if (vertexTo == null)
            {
                throw new ArgumentException("not find in list");
            }

            AddDirectedEdge(vertexFrom, vertexTo);
            AddDirectedEdge(vertexTo, vertexFrom);
        }

        public void GetGraphInfo(bool isDirectedGraph = false)
        {
            var sb = new StringBuilder();
            foreach(var item in vertexList)
            {
                sb.Append($"{item.Data.ToString()}:");
                var edge = item.firstAdjacency;
                while (edge != null)
                {
                    sb.Append($"{edge.Element.Data},");
                    edge = edge.Next;  
                }

                sb.Append(Environment.NewLine);

                
            }
            Console.Write(sb);
        }

        public void AddDirectedEdge(Vertex<T> from, Vertex<T> to)
        {
            if(from.firstAdjacency == null)
            {
                from.firstAdjacency = new Node<T>(to);
            }
            else
            {
                var current = from.firstAdjacency;
                while (current.Next != null)
                {
                    if (current.Element.Equals(to))
                    {
                        throw new Exception("Already exsit edge between this tow Vertex.");
                    }
                    current = current.Next;
                }

                current.Next = new Node<T>(to);
            }
        }

        public void AddDirectedEdge(T from, T to)
        {
            Vertex<T> fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException("头顶点不存在！");
            }

            Vertex<T> toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException("尾顶点不存在！");
            }

            AddDirectedEdge(fromVertex, toVertex);
        }

        public Vertex<T> Find(T data)
        {
            foreach (var item in vertexList)
            {
                if (item.Data.Equals(data))
                {
                    return item;
                }
            }

            return null;
        }

        public void InitVisit()
        {
            foreach(var item in vertexList)
            {
                item.IsVisited = false;
            }
        }
        //深度优先遍历无向图
        public void FindDFS()
        {
            InitVisit();
            DFS(vertexList[0]);
        }

        public void DFS(Vertex<T> vertex)
        {
            Console.Write(vertex.Data.ToString());
            vertex.IsVisited = true;

            var node = vertex.firstAdjacency;

            while(node != null)
            {
                if (node.Element.IsVisited == false)
                {
                    DFS(node.Element);
                }
                node = node.Next;
            }
        }

        //广度优先遍历无向图
        public void FindBFS()
        {
            InitVisit();
            BFS(vertexList[0]);
        }

        public void BFS(Vertex<T> vertex)
        {
            var queue = new Queue<Vertex<T>>();
            queue.Enqueue(vertex);
            vertex.IsVisited = true;

            while (queue.Count > 0)
            {
                Vertex<T> current = queue.Dequeue();       
                Console.Write(current.Data.ToString());

                var edge = current.firstAdjacency;
                while (edge != null)
                {
                    if (edge.Element.IsVisited == false)
                    {
                        queue.Enqueue(edge.Element);
                        edge.Element.IsVisited = true;
                    }
                    edge = edge.Next;
                }
            }
        }

        private bool contains(T data)
        {
            bool contains = false;
            foreach(var item in vertexList)
            {
                if (item.Data.Equals(data))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }
    }

    

    internal class Vertex<T>
    {
        public T Data { get; set; }

        public Node<T> firstAdjacency { get; set; }

        public bool IsVisited { get; set; }

        public Vertex(T data)
        {
            Data = data;
        }

    }

    internal class Node<T>
    {
        public Vertex<T> Element { get; set; }
        public Node<T> Next { get; set; }

        public Node(Vertex<T> vertex)
        {
            Element = vertex;
        }

    }
}
