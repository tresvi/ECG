namespace ECGViewer.Modelos
{
    public class Muestra
    {
        public double Tiempo { get; set; }
        public double[] Canal { get; set; } = new double[12];
    }
}
