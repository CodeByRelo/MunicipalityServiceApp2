
using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class Graph
    {
        private readonly Dictionary<string, List<GraphEdge>> adjacencyList =
            new Dictionary<string, List<GraphEdge>>(
                StringComparer.OrdinalIgnoreCase);

        public int VertexCount
        {
            get { return adjacencyList.Count; }
        }

        public void AddVertex(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return;

            location = location.Trim();

            if (!adjacencyList.ContainsKey(location))
                adjacencyList[location] = new List<GraphEdge>();
        }

        public void AddEdge(
            string source,
            string destination,
            double weight)
        {
            if (string.IsNullOrWhiteSpace(source) ||
                string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException(
                    "Both locations are required.");

            if (weight < 0)
                throw new ArgumentOutOfRangeException(
                    "weight",
                    "Edge weight cannot be negative.");

            source = source.Trim();
            destination = destination.Trim();

            AddVertex(source);
            AddVertex(destination);

            if (source.Equals(
                destination,
                StringComparison.OrdinalIgnoreCase))
                return;

            if (HasEdge(source, destination))
                return;

            adjacencyList[source].Add(
                new GraphEdge(source, destination, weight));

            adjacencyList[destination].Add(
                new GraphEdge(destination, source, weight));
        }

        public bool HasVertex(string location)
        {
            return !string.IsNullOrWhiteSpace(location) &&
                   adjacencyList.ContainsKey(location.Trim());
        }

        public bool HasEdge(string source, string destination)
        {
            if (!HasVertex(source) || !HasVertex(destination))
                return false;

            return adjacencyList[source.Trim()].Any(
                edge => edge.Destination.Equals(
                    destination.Trim(),
                    StringComparison.OrdinalIgnoreCase));
        }

        public List<string> GetVertices()
        {
            return adjacencyList.Keys
                .OrderBy(x => x)
                .ToList();
        }

        public List<GraphEdge> GetNeighbours(string location)
        {
            if (!HasVertex(location))
                return new List<GraphEdge>();

            return adjacencyList[location.Trim()].ToList();
        }

        public List<GraphEdge> GetAllEdges()
        {
            List<GraphEdge> edges = new List<GraphEdge>();

            foreach (KeyValuePair<string, List<GraphEdge>> entry
                     in adjacencyList)
            {
                foreach (GraphEdge edge in entry.Value)
                {
                    if (string.Compare(
                        edge.Source,
                        edge.Destination,
                        StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        edges.Add(edge);
                    }
                }
            }

            return edges;
        }
    }
}
