using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECGViewer.Utiles
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


        public static void ElevarAlCuadrado(ref double[] senal)
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


        public static List<Muestra> CalcularDerivada(List<Muestra> muestras, int nroCanal, double h)
        {
            List<Muestra> derivada = new List<Muestra>();

            for (int i = 0; i < muestras.Count - 1; i++)
            {
                Muestra derivadaAprox = new Muestra();
                derivadaAprox.Canal[nroCanal] = (muestras[i + 1].Canal[nroCanal] - muestras[i].Canal[nroCanal]) / h;
                derivadaAprox.Tiempo = muestras[i].Tiempo;
                derivada.Add(derivadaAprox);
            }

            return derivada;
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


        public static void SumarRuidoAleatorio(ref List<Muestra> senal, int nroCanal, double minimo, double maximo)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < senal.Count; i++)
            {
                double ruido = random.NextDouble() * (maximo - minimo) + minimo;
                senal[i].Canal[nroCanal] += ruido;
            }
        }


        /// <summary>
        /// Obtiene Macimos y Minimos de la señal
        /// </summary>
        /// <param name="senal"></param>
        /// <returns></returns>
        public static int[] GetExtremosLocales(double[] senal)
        {
            List<int> extremos = new List<int>();
            for (int i = 1; i < senal.Length - 1; i++)
            {
                if ((senal[i] > senal[i - 1] && senal[i] > senal[i + 1]) || // Máximo local
                    (senal[i] < senal[i - 1] && senal[i] < senal[i + 1]))   // Mínimo local
                {
                    extremos.Add(i);
                }
            }
            return extremos.ToArray();
        }


        public static void DesbalancearMesetas(ref double[] senal)
        {
            const double COEF_DESBALANCEO = 0.01;

            for (int i = 1; i < senal.Length - 1; i++)
            {
                if (i < senal.Length - 2)
                {
                    if (senal[i] == senal[i+1])
                    { 
                        double promedio = (senal[i + 1] + senal[i + 2]) / 2;
                        if (promedio != senal[i+1]) 
                            senal[i + 1] = promedio;
                        else
                            senal[i + 1] += senal[i + 1] * COEF_DESBALANCEO;
                    }
                }
            }
        }


        public static int IndiceMasCercano(int punto, int[] indicesExtremos)
        {
            if (indicesExtremos.Length == 0)
                throw new ArgumentException("El array de extremos no puede estar vacío.");

            return indicesExtremos.OrderBy(indice => Math.Abs(indice - punto)).First();
        }


        public static int BuscarProximoPico(double[] array, int indice)
        {
            if (array == null || array.Length == 0 || indice < 0 || indice >= array.Length - 1)
                return -1;

            for (int i = indice + 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1]) return i;
            }

            return -1;
        }


        public static int BuscarProximoValle(double[] array, int indice)
        {
            if (array == null || array.Length == 0 || indice < 0 || indice >= array.Length - 1)
                return -1;

            for (int i = indice + 1; i < array.Length - 1; i++)
            {
                if (array[i] < array[i - 1] && array[i] < array[i + 1]) return i;
            }

            return -1;
        }


        public static int BuscarPicoPrevio(double[] array, int indice)
        {
            if (array == null || array.Length == 0 || indice <= 0 || indice >= array.Length)
                return -1;

            for (int i = indice - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1]) return i;
            }

            return -1;
        }


        public static int BuscarVallePrevio(double[] array, int indice)
        {
            if (array == null || array.Length == 0 || indice <= 0 || indice >= array.Length)
                return -1;

            for (int i = indice - 1; i > 0; i--)
            {
                if (array[i] < array[i - 1] && array[i] < array[i + 1])
                    return i;
            }

            return -1;
        }


        public static int BuscarValorMaximo(double[] datos, int inicio, int fin)
        {
            if (datos == null || datos.Length == 0)
                throw new ArgumentException("El array no puede estar vacío.");

            if (inicio < 0 || fin >= datos.Length || inicio > fin)
                throw new ArgumentOutOfRangeException("Los índices están fuera de rango o son inválidos.");

            int indiceMaximo = inicio;
            double maximo = datos[inicio];

            for (int i = inicio + 1; i <= fin; i++)
            {
                if (datos[i] > maximo)
                {
                    maximo = datos[i];
                    indiceMaximo = i;
                }
            }

            return indiceMaximo;
        }


        public static int BuscarValorMinimo(double[] datos, int inicio, int fin)
        {
            if (datos == null || datos.Length == 0)
                throw new ArgumentException("El array no puede estar vacío.");

            if (inicio < 0 || fin >= datos.Length || inicio > fin)
                throw new ArgumentOutOfRangeException("Los índices están fuera de rango o son inválidos.");

            int indiceMinimo = inicio;
            double minimo = datos[inicio];

            for (int i = inicio + 1; i <= fin; i++)
            {
                if (datos[i] < minimo)
                {
                    minimo = datos[i];
                    indiceMinimo = i;
                }
            }

            return indiceMinimo;
        }


        public static int EncontrarPicoMaximoLocal(double[] datos, int inicio, int fin)
        {
            if (datos == null || datos.Length == 0)
                throw new ArgumentException("El array no puede estar vacío.");

            if (inicio < 0 || fin >= datos.Length || inicio > fin)
                throw new ArgumentOutOfRangeException("Los índices están fuera de rango o son inválidos.");

            int indiceMaximo = -1;
            double maximo = double.MinValue;

            for (int i = inicio; i <= fin; i++)
            {
                bool esPico =
                    (i == 0 || datos[i] > datos[i - 1]) &&  // Mayor que el anterior (o primer elemento)
                    (i == datos.Length - 1 || datos[i] > datos[i + 1]); // Mayor que el siguiente (o último elemento)

                if (esPico && datos[i] > maximo)
                {
                    maximo = datos[i];
                    indiceMaximo = i;
                }
            }

            return indiceMaximo; // -1 si no hay picos
        }


        public static int EncontrarValleMinimoLocal(double[] datos, int inicio, int fin)
        {
            if (datos == null || datos.Length == 0)
                throw new ArgumentException("El array no puede estar vacío.");

            if (inicio < 0 || fin >= datos.Length || inicio > fin)
                throw new ArgumentOutOfRangeException("Los índices están fuera de rango o son inválidos.");

            int indiceMinimo = -1;
            double minimo = double.MaxValue;

            for (int i = inicio; i <= fin; i++)
            {
                bool esPico =
                    (i == 0 || datos[i] < datos[i - 1]) &&  // Menor que el anterior (o primer elemento)
                    (i == datos.Length - 1 || datos[i] < datos[i + 1]); // Menor que el siguiente (o último elemento)

                if (esPico && datos[i] < minimo)
                {
                    minimo = datos[i];
                    indiceMinimo = i;
                }
            }

            return indiceMinimo; // -1 si no hay picos
        }

        /// <summary>
        /// Variabilidad de la derivada. Cuanto mas rugosa, mayor es la metrica
        /// Mide qué tan rápido cambia la señal, útil para ver qué tan "rugosa" es.
        /// Se basa en la diferencia absoluta entre valores consecutivos:
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double VariabilidadDiferencias(double[] datos)
        {
            if (datos == null || datos.Length < 2) throw new ArgumentException("El array debe tener al menos 2 elementos.");

            double suma = 0;
            for (int i = 0; i < datos.Length - 1; i++)
                suma += Math.Abs(datos[i + 1] - datos[i]);

            return suma / (datos.Length - 1);
        }

        ///Otra medida de Rugosidad:
        ///Es mas sensible a los cambios bruscos por el hecho de estar elevada al cuadrado. <summary>
        /// Otra medida de Rugosidad://A efectos practicos de los ECG, el valor que da es aprox. el doble de 
        /// la VariabilidadDeDiferencias en todas las iteraciones.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double RMSDerivada(double[] datos)
        {
            if (datos == null || datos.Length < 2) throw new ArgumentException("El array debe tener al menos 2 elementos.");

            double sumaCuadrados = 0;
            for (int i = 0; i < datos.Length - 1; i++)
            {
                double derivada = datos[i + 1] - datos[i];
                sumaCuadrados += derivada * derivada;
            }

            return Math.Sqrt(sumaCuadrados / (datos.Length - 1));
        }



    }
}

