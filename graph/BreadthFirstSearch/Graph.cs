using System;
using System.Collections.Generic;
using System.Text;

namespace BreadthFirstSearch
{
    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        /// <summary>
        /// AdjacencyList is a representation of graph, where key is node and value is array of connected nodes
        /// </summary>
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        /// <summary>
        /// Add new edge that connects two vertices
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }
}
