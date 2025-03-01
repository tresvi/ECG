using System.Collections.Generic;
using System;

namespace ECGViewer.Modelos
{
    public class Muestra
    {
        public const int NRO_CANALES = 12;
        public double Tiempo { get; set; }
        public double[] Canal { get; set; } = new double[NRO_CANALES];


        public static double[] GetCanal(in List<Muestra> senal, int nroCanal)
        {
            double[] muestrasCanal = new double[senal.Count];
            for (int i = 0; i < senal.Count; i++)
                muestrasCanal[i] = senal[i].Canal[nroCanal];

            return muestrasCanal;
        }


        public static void SetCanal(ref List<Muestra> senal, int nroCanal, in double[] muestrasCanal)
        {
            if (senal.Count != muestrasCanal.Length)
                throw new ArgumentException("El tamaño de la la lista de muestras y del array de valores deben coincidir.");

            for (int i = 0; i < senal.Count; i++)
                senal[i].Canal[nroCanal] = muestrasCanal[i];
        }

    }
}
