
namespace ECGCommon.Modelos
{
    public class ComplejoPQRST
    {
        public int P { get; set; }
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
        public int T { get; set; }
        public bool RPositivo { get; set; }

        public ComplejoPQRST() {}

        public ComplejoPQRST(int q, int r, int s)
        {
            Q = q;
            R = r;
            S = s;
        }

        public ComplejoPQRST(int p, int q, int r, int s, int t)
        {
            P = p;
            Q = q;
            R = r;
            S = s;
            T = t;
        }
    }
}
