using ClosedXML.Excel;
using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
            List<Muestra> dataList = new List<Muestra>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException("El archivo CSV no se encontró.", filePath);

            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(',');
                
                if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double value1) &&
                    double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double value2))
                {
                    Muestra muestra = new Muestra();
                    muestra.Tiempo = value1;
                    muestra.Canal[0] = value2;
                    dataList.Add(muestra);
                }
                else
                {
                    //TODO: Decidir si se van a tolerar filas mal formadas en los archivos
                    //throw new Exception($"No se pudieron convertir los valores: {line}");
                }
            }

            return dataList;
        }


        public static List<Muestra> LoadXlsxData(string filePath)
        {
            List<Muestra> dataList = new List<Muestra>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException("El archivo XLSX no se encontró.", filePath);

            using (var workbook = new XLWorkbook(filePath))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);
                int row = 2;
                double tiempo, lectura;

                while (true)
                {
                    string celda1 = worksheet.Cell(row, 1).GetValue<string>();
                    string celda2 = worksheet.Cell(row, 2).GetValue<string>();

                    if (string.IsNullOrWhiteSpace(celda1) || string.IsNullOrWhiteSpace(celda2))
                        break;

                    if (!double.TryParse(celda1, out tiempo) || !double.TryParse(celda2, out lectura))
                        throw new Exception($"Error al leer los datos {celda1} / {celda2}");

                    Muestra muestra = new Muestra();
                    muestra.Tiempo = tiempo;
                    muestra.Canal[0] = lectura;
                    dataList.Add(muestra);
                    row++;
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


        public static void ResetearTiempo(ref List<Muestra> senal)
        {
            if (senal.Count == 1)
            {
                senal[0].Tiempo = 0;
                return;
            }

            double tiempoMuestreo = senal[1].Tiempo - senal[0].Tiempo;
            tiempoMuestreo = Math.Round(tiempoMuestreo, 5);
            int contador = 0;

            foreach (Muestra muestra in senal)
            {
                muestra.Tiempo = tiempoMuestreo * contador++;
            }
        }


        public static (double zero, double span) GetSpan(int x0, int x1, double y0, double y1)
        {
            double m = (y0 - y1) / (x0 - x1);
            return (y0, m);
        }

    }
}
