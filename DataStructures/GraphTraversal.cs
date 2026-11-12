
using System.Collections.Generic;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class GraphTraversal
    {
        public List<string> BreadthFirstSearch(
            Graph graph,
            string startLocation)
        {
            List<string> visitedOrder = new List<string>();

            if (graph == null ||
                !graph.HasVertex(startLocation))
                return visitedOrder;

            Queue<string> queue = new Queue<string>();
            HashSet<string> visited =
                new HashSet<string>(
                    System.StringComparer.OrdinalIgnoreCase);

            queue.Enqueue(startLocation);
            visited.Add(startLocation);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                visitedOrder.Add(current);

                foreach (GraphEdge edge in
                         graph.GetNeighbours(current))
                {
                    string neighbour = edge.Destination;

                    if (visited.Add(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return visitedOrder;
        }

        public List<string> DepthFirstSearch(
            Graph graph,
            string startLocation)
        {
            List<string> visitedOrder = new List<string>();

            if (graph == null ||
                !graph.HasVertex(startLocation))
                return visitedOrder;

            Stack<string> stack = new Stack<string>();
            HashSet<string> visited =
                new HashSet<string>(
                    System.StringComparer.OrdinalIgnoreCase);

            stack.Push(startLocation);

            while (stack.Count > 0)
            {
                string current = stack.Pop();

                if (!visited.Add(current))
                    continue;

                visitedOrder.Add(current);

                List<GraphEdge> neighbours =
                    graph.GetNeighbours(current);

                for (int i = neighbours.Count - 1; i >= 0; i--)
                {
                    if (!visited.Contains(
                        neighbours[i].Destination))
                    {
                        stack.Push(neighbours[i].Destination);
                    }
                }
            }

            return visitedOrder;
        }
    }
}
