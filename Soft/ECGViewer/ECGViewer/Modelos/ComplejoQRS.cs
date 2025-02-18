
namespace ECGViewer.Modelos
{
    internal class ComplejoQRS
    {
        public double Q { get; set; }
        public double R { get; set; }
        public double S { get; set; }

        public ComplejoQRS(double q, double r, double s)
        {
            Q = q;
            R = r;
            S = s;
        }
    }
}
