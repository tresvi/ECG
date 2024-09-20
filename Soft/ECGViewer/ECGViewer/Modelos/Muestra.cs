namespace ECGViewer.Modelos
{
    public class Muestra
    {
        public const int NRO_CANALES = 12;
        public double Tiempo { get; set; }
        public double[] Canal { get; set; } = new double[NRO_CANALES];
    }
}
