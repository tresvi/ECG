using ECGViewer.Modelos;
using System;
using System.Collections.Generic;

namespace ECGViewer.Utiles
{
    internal class Filtros
    {

        //Lineal, Invariante. Puede retrasar la señal. Reduce mas los picos altos que los bajos.
        public static double[] MediaMovil(double[] senal, int tamanoVentana)
        {
            if (tamanoVentana < 1 || tamanoVentana > senal.Length)
                throw new ArgumentException("El tamaño de la ventana debe ser mayor que 0 y menor o igual a la cantidad de muestras.");

            double[] senalFiltrada = new double[senal.Length];
            int mitadVentana = tamanoVentana / 2;

            for (int i = 0; i < senal.Length; i++)
            {
                // Definir los límites de la ventana
                int inicio = Math.Max(0, i - mitadVentana);
                int fin = Math.Min(senal.Length - 1, i + mitadVentana);

                // Calcular la media de los valores dentro de la ventana
                double promedio = 0;
                int elementos = 0;
                for (int j = inicio; j <= fin; j++)
                {
                    promedio += senal[j];
                    elementos++;
                }
                senalFiltrada[i] = promedio / elementos;
            }

            return senalFiltrada;
        }


        public static double[] Mediana(double[] senal, int tamanoVentana)
        {
            if (tamanoVentana < 1 || tamanoVentana > senal.Length || tamanoVentana % 2 == 0)
                throw new ArgumentException("El tamaño de la ventana debe ser impar y menor o igual a la cantidad de muestras.");

            double[] senalFiltrada = new double[senal.Length];
            int mitadVentana = tamanoVentana / 2;

            for (int i = 0; i < senal.Length; i++)
            {
                // Definir los límites de la ventana
                int inicio = Math.Max(0, i - mitadVentana);
                int fin = Math.Min(senal.Length - 1, i + mitadVentana);

                // Extraer los valores dentro de la ventana
                double[] ventana = new double[fin - inicio + 1];
                Array.Copy(senal, inicio, ventana, 0, ventana.Length);

                // Ordenar la ventana y tomar la mediana (elemento central)
                Array.Sort(ventana);
                senalFiltrada[i] = ventana[ventana.Length / 2];
            }

            return senalFiltrada;
        }


        public static void RecortePorValorBajo(ref List<Muestra> senal, int nroCanal, double umbral)
        {
            for (int i = 0; i < senal.Count; i++)
            {
                if (senal[i].Canal[nroCanal] < umbral)
                    senal[i].Canal[nroCanal] = 0;
            }
        }


        public static void RecortePorValorBajo(ref double[] senal, double umbral)
        {
            for (int i = 0; i < senal.Length; i++)
            {
                if (senal[i] < umbral) senal[i] = 0;
            }
        }

    }
}
