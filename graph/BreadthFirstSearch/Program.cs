using System;

namespace BreadthFirstSearch
{
    class Program
    {
        public static void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(8,10), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            Console.WriteLine("Breadth first search");
            Console.WriteLine(string.Join(", ", algorithms.BFS(graph, 1)));

            Console.WriteLine("Breadth first search - find shortest path");
            Console.WriteLine("Shortest path from 1 to 10: "  +
                                string.Join(", ", algorithms.FindShortestPath(graph, 1, 10)));

            Console.ReadLine();


        }
    }
}
