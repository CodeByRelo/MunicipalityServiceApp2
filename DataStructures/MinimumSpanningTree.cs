
using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class MinimumSpanningTree
    {
        public List<GraphEdge> Kruskal(Graph graph)
        {
            List<GraphEdge> result = new List<GraphEdge>();

            if (graph == null || graph.VertexCount == 0)
                return result;

            Dictionary<string, string> parent =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int> rank =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (string vertex in graph.GetVertices())
            {
                parent[vertex] = vertex;
                rank[vertex] = 0;
            }

            List<GraphEdge> edges = graph.GetAllEdges()
                .OrderBy(edge => edge.Weight)
                .ToList();

            foreach (GraphEdge edge in edges)
            {
                string rootSource = Find(parent, edge.Source);
                string rootDestination = Find(parent, edge.Destination);

                if (rootSource.Equals(
                    rootDestination,
                    StringComparison.OrdinalIgnoreCase))
                    continue;

                result.Add(edge);

                Union(parent, rank, rootSource, rootDestination);

                if (result.Count == graph.VertexCount - 1)
                    break;
            }

            return result;
        }

        private string Find(
            Dictionary<string, string> parent,
            string vertex)
        {
            if (!parent[vertex].Equals(
                vertex,
                StringComparison.OrdinalIgnoreCase))
            {
                parent[vertex] = Find(parent, parent[vertex]);
            }

            return parent[vertex];
        }

        private void Union(
            Dictionary<string, string> parent,
            Dictionary<string, int> rank,
            string first,
            string second)
        {
            string rootFirst = Find(parent, first);
            string rootSecond = Find(parent, second);

            if (rootFirst.Equals(
                rootSecond,
                StringComparison.OrdinalIgnoreCase))
                return;

            if (rank[rootFirst] < rank[rootSecond])
            {
                parent[rootFirst] = rootSecond;
            }
            else if (rank[rootFirst] > rank[rootSecond])
            {
                parent[rootSecond] = rootFirst;
            }
            else
            {
                parent[rootSecond] = rootFirst;
                rank[rootFirst]++;
            }
        }

        public double GetTotalWeight(List<GraphEdge> edges)
        {
            if (edges == null)
                return 0;

            return edges.Sum(edge => edge.Weight);
        }
    }
}
