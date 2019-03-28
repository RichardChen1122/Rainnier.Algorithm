using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphDemo = new MyAdjacencyGraph<int>(10);

            graphDemo.AddVertex(1);
            graphDemo.AddVertex(2);
            graphDemo.AddVertex(3);
            graphDemo.AddVertex(4);
            graphDemo.AddVertex(5);
            graphDemo.AddVertex(6);
            graphDemo.AddVertex(7);
            graphDemo.AddVertex(8);

            graphDemo.AddEdge(1, 2);
            graphDemo.AddEdge(1,3);
            graphDemo.AddEdge(1,4);
            graphDemo.AddEdge(1,7);
            graphDemo.AddEdge(2,5);
            graphDemo.AddEdge(2,8);
            graphDemo.AddEdge(3,5);
            graphDemo.AddEdge(3,6);
            graphDemo.AddEdge(3,7);
            graphDemo.AddEdge(3,8);
            graphDemo.AddEdge(4,6);
            graphDemo.AddEdge(5,7);

            //graphDemo.GetGraphInfo();
            //graphDemo.FindDFS();
            graphDemo.FindBFS();
            Console.ReadKey();
        }
    }
}
