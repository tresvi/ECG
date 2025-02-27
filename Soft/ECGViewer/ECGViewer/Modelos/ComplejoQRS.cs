
namespace ECGViewer.Modelos
{
    public class ComplejoQRS
    {
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }

        public ComplejoQRS(int q, int r, int s)
        {
            Q = q;
            R = r;
            S = s;
        }
    }
}
