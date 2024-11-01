using ECGViewer.Properties;

namespace ECGViewer.Modelos
{
    internal class Configuracion
    {
        public const int MUESTRAS_POR_GRAFICO_MIN = 3000;

        public string PuertoCOM { get { return Settings.Default.PuertoCOM; } }
        public int BaudRate { get { return Settings.Default.BaudRate; } }
        public decimal TiempoMuestreo { get { return Settings.Default.TMuestreo <= 0 ? 1 : Settings.Default.TMuestreo; } }
        public int CalibracionBitsMin { get { return Settings.Default.CalibValorBitsMin; } }
        public int CalibracionBitsMax { get { return Settings.Default.CalibValorBitsMax; } }
        public decimal CalibracionValorYMin { get { return Settings.Default.CalibValorYMin; } }
        public decimal CalibracionValorYMax 
        { 
            get 
            {
                decimal CalibYMax = Settings.Default.CalibValorYMax;
                if (CalibYMax == CalibracionValorYMin) CalibYMax += 1;
                return CalibYMax;
            }
        }
        public string Unidad { get { return Settings.Default.Unidad; } }
        public int MuestrasPorGrafico 
        { 
            get 
            {
                int muestrasPorGrafico = Settings.Default.MuestrasPorGrafico;
                return muestrasPorGrafico <= 1000 ? MUESTRAS_POR_GRAFICO_MIN : muestrasPorGrafico; 
            }
        }
        public decimal Pendiente { get { return (CalibracionValorYMax - CalibracionValorYMin) / (CalibracionBitsMax - CalibracionBitsMin); } }
        public bool UsarValoresCrudosADC { get { return Settings.Default.UsarValoresCrudosADC; } }
    }
}