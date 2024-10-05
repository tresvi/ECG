using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ECGViewer
{
    static internal class Utiles
    {

        static internal double[] ClonarVectorParaFFT(in List<Muestra> senalOriginal)
        {
            long tamanoVector = 0; int exponente = 0;

            while (senalOriginal.Count > tamanoVector)
            {
                tamanoVector = 2 << exponente++;
            }

            double[] senal = new double[tamanoVector];
            for (int i = 0; i < senalOriginal.Count; i++)
            {
                senal[i] = senalOriginal[i].Canal[0];
            }

            return senal;
        }


        public static List<Muestra> LoadCsvData(string filePath)
        {
            var dataList = new List<Muestra>();

            // Verifica si el archivo existe
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo CSV no se encontró.", filePath);
            }

            // Lee el archivo línea por línea
            foreach (var line in File.ReadLines(filePath))
            {
                // Divide la línea en partes usando la coma como delimitador
                var parts = line.Split('\t');

                if (parts.Length >= 2)
                {
                    // Convierte las partes a float y añade a la lista
                    if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double value1) &&
                        double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double value2))
                    {
                        Muestra muestra = new Muestra();
                        muestra.Tiempo = value1;
                        muestra.Canal[0] = -1 * value2;
                        dataList.Add(muestra);
                    }
                    else
                    {
                        Console.WriteLine($"No se pudieron convertir los valores: {line}");
                    }
                }
                else
                {
                    Console.WriteLine($"Línea con formato incorrecto: {line}");
                }
            }

            return dataList;
        }


        public static List<Muestra> ClonarSenal(in List<Muestra> senalOriginal)
        {
            List <Muestra> senalCopia = new List<Muestra>();

            for (int i = 0; i < senalOriginal.Count; i++)
            {
                Muestra muestra = new Muestra();
                muestra.Tiempo = senalOriginal[i].Tiempo;
                Array.Copy(senalOriginal[i].Canal, muestra.Canal, Muestra.NRO_CANALES);
                senalCopia.Add(muestra);
            }

            return senalCopia;
        }


        public static (int, int) ObtenerIndicesInicialyFinal(in List<Muestra> senal, double tiempoIni, double tiempoFin)
        {
            bool indiceInicialEncontrado = false;
            bool indiceFinalEncontrado = false;
            int indiceInicial = 0;
            int indiceFinal = 0;

            for (int i = 0; i < senal.Count; i++)
            {
                if (!indiceInicialEncontrado && senal[i].Tiempo >= tiempoIni)
                { 
                    indiceInicialEncontrado = true;
                    indiceInicial = i;
                }

                if (!indiceFinalEncontrado && senal[i].Tiempo >= tiempoFin)
                {
                    indiceFinalEncontrado = true;
                    indiceFinal = i;
                    break;
                }
            }

            return (indiceInicial, indiceFinal);
        }

    }
}
