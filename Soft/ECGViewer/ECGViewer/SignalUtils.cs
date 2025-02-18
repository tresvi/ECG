using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECGViewer
{
    internal class SignalUtils
    {

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


        public static void ElevarAlCuadrado(ref List<Muestra> senal, int nroCanal)
        {
            for (int i = 0; i < senal.Count - 1; i++)
            {
                senal[i].Canal[nroCanal] *= senal[i].Canal[nroCanal];
            }
        }


        public static void ElevarAlCuadrado(double[] senal, int nroCanal)
        {
            for (int i = 0; i < senal.Length - 1; i++)
            {
                senal[i] *= senal[i];
            }
        }


        public static List<int> DetectarPicos(in double[] senal)
        {
            List<int> peakIndexes = new List<int>();

            for (int i = 1; i < senal.Length - 1; i++)
            {
                if (senal[i] > senal[i - 1] && senal[i] > senal[i + 1])
                {
                    peakIndexes.Add(i);
                }
            }

            return peakIndexes;
        }

        public static void RectificarMediaOnda(ref List<Muestra> senal, int nroCanal)
        {
            for (int i = 0; i < senal.Count - 1; i++)
            {
                if (senal[i].Canal[nroCanal] < 0) senal[i].Canal[nroCanal] = 0;
            }
        }


        public static void RectificarMediaOnda(ref double[] senal)
        {
            for (int i = 0; i < senal.Length - 1; i++)
                if (senal[i] < 0) senal[i] = 0;
        }


        public static void MultiplicarPorEscalar(ref List<Muestra> senal, int nroCanal, double escalar)
        {
            for (int i = 0; i < senal.Count - 1; i++)
            {
                senal[i].Canal[nroCanal] *= escalar;
            }
        }


        public static void MultiplicarPorEscalar(ref double[] senal, double escalar)
        {
            for (int i = 0; i < senal.Length - 1; i++)
                senal[i] *= escalar;
        }


        //Lineal, Invariante. Puede retrasar la señal. Reduce mas los picos altos que los bajos.
        public static double[] FiltroMediaMovil(double[] senal, int tamanoVentana)
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


        public static double[] FiltroMediana(double[] senal, int tamanoVentana)
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


        public static double GetValorMedio(in double[] senal)
        {
            double acumulador = 0;
            for (int i = 0; i < senal.Length; i++)
                acumulador += senal[i];

            return acumulador / senal.Length;
        }


        public static double CalcularPromedioPicos(double[] senal)
        {
            List<int> picos = DetectarPicos(senal);

            if (picos.Count == 0) return 0; // Evita división por cero si no hay picos

            double suma = picos.Sum(indice => senal[indice]); // Sumar valores de los picos
            return suma / picos.Count; // Promedio de los picos
        }


        public static void RecortePorValorBajo(ref List<Muestra> senal, int nroCanal, double umbral)
        {
            for (int i = 0; i < senal.Count; i++)
            {
                if (senal[i].Canal[nroCanal] < umbral)
                    senal[i].Canal[nroCanal] = 0;
            }
        }


        private const double TIEMPO_GUARDA_QR_RS_SEC = 0.150;
        public static List<ComplejoQRS> DetectarPicosEntreMenores(in double[] senal, double tMuestreo, bool validarTiempos)
        {
            List<int> picos = DetectarPicos(senal);
            List<ComplejoQRS> complejosDetectados = new List<ComplejoQRS>();

            for (int i = 1; i < picos.Count - 1; i++) // Para asegurar que haya picos antes y despues
            {
                int indexPicoActual = picos[i];
                int indexPicoAnterior = picos[i - 1];
                int indexPicoSiguiente = picos[i + 1];

                //El complejo R siempre estara encerrado entre untre un Q y un S de menor amplitud
                if (senal[indexPicoActual] > senal[indexPicoAnterior] && senal[indexPicoActual] > senal[indexPicoSiguiente])
                {
                    if (validarTiempos)
                    {
                        double tiempoQR = (indexPicoActual - indexPicoAnterior) * tMuestreo;
                        double tiempoRS = (indexPicoSiguiente - indexPicoActual) * tMuestreo;

                        if (tiempoQR < TIEMPO_GUARDA_QR_RS_SEC && tiempoRS < TIEMPO_GUARDA_QR_RS_SEC)
                            complejosDetectados.Add(new ComplejoQRS(indexPicoAnterior, indexPicoActual, indexPicoSiguiente));
                    }
                    else
                        complejosDetectados.Add(new ComplejoQRS(indexPicoAnterior, indexPicoActual, indexPicoSiguiente));
                }
            }

            return complejosDetectados;
        }


        public static void SumarRuidoAleatorio(ref List<Muestra> senal, int nroCanal, double minimo, double maximo)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < senal.Count; i++)
            {
                double ruido = random.NextDouble() * (maximo - minimo) + minimo;
                senal[i].Canal[nroCanal] += ruido;
            }
        }
    }
}

