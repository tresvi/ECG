﻿using ECGViewer.Properties;

namespace ECGViewer.Modelos
{
    internal class Configuracion
    {
        public const int MUESTRAS_POR_GRAFICO_DFLT = 4000;

        public string PuertoCOM { get { return Settings.Default.PuertoCOM; } }
        public int BaudRate { get { return Settings.Default.BaudRate; } }
        public decimal TiempoMuestreo { get { return Settings.Default.TMuestreo <= 0 ? 1 : Settings.Default.TMuestreo; } }
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
                return muestrasPorGrafico <= 1000 ? MUESTRAS_POR_GRAFICO_DFLT : muestrasPorGrafico; 
            } 
        }
        public decimal Span { get { return (CalibracionValorYMax - CalibracionValorYMin) / (1023 - 0); } }
        public decimal Zero { get { return CalibracionValorYMin; } }
    }
}