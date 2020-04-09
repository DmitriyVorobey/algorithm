using System.Collections.Generic;

namespace BreadthFirstSearch
{
    public class Algorithms
    {
        public HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            // Visited nodes
            var visited = new HashSet<T>();

            // Return 0 nodes visited if AdjacencyList doesn`t contain start node
            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();

            // Start processing graph from the start
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                // Prevent cycling
                if (visited.Contains(vertex))
                    continue;

                // Visit vertex
                visited.Add(vertex);

                // Add all not visited neighbor to the processing queue
                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        public IEnumerable<T> FindShortestPath<T>(Graph<T> graph, T start, T destination)
        {
            // Dictionary that represents how we can particular node.
            // E.g. previous[2] = 1 means that we get node '2' through the node 1 
            var previous = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(start);


            // BFS cycle
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (previous.ContainsKey(neighbor))
                        continue;

                    previous[neighbor] = vertex;
                    queue.Enqueue(neighbor);
                }
            }

            var path = new Stack<T>();

            var current = destination;
            while (!current.Equals(start))
            {
                path.Push(current);
                current = previous[current];
            };

            path.Push(start);

            return path;
        }
    }
}
