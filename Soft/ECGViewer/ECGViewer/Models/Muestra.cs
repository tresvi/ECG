using System.Collections.Generic;
using System;

namespace ECGViewer.Models
{
    public class Muestra
    {
        public const int NRO_CANALES = 12;
        public double Tiempo { get; set; }
        public double[] Canal { get; set; } = new double[NRO_CANALES];


        public static double GetTMuestreo(in List<Muestra> senal)
        {
            if (senal.Count <= 1) return 0;

            return senal[1].Tiempo - senal[0].Tiempo;
        }


        public static double GetFMuestreo(in List<Muestra> senal)
        {
            if (senal.Count <= 1) return 0;

            double tMuestreo = GetTMuestreo(senal);
            if (tMuestreo == 0) return 0;
            
            return 1 / tMuestreo;
        }


        public static double[] GetCanal(in List<Muestra> senal, int nroCanal)
        {
            double[] muestrasCanal = new double[senal.Count];
            for (int i = 0; i < senal.Count; i++)
                muestrasCanal[i] = senal[i].Canal[nroCanal];

            return muestrasCanal;
        }


        public static void SetCanal(ref List<Muestra> senal, int nroCanal, in double[] muestrasCanal)
        {
            if (senal.Count > muestrasCanal.Length)
                throw new ArgumentException("El tamaño de la la lista de muestras debe ser menor o igual al del array de valores");

            for (int i = 0; i < senal.Count; i++)
                senal[i].Canal[nroCanal] = muestrasCanal[i];
        }

    }
}
