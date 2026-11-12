
namespace MunicipalityServiceApp2.Models
{
    public class GraphEdge
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Weight { get; set; }

        public GraphEdge(
            string source,
            string destination,
            double weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public override string ToString()
        {
            return Source + " - " +
                   Destination + " (" +
                   Weight + ")";
        }
    }
}
