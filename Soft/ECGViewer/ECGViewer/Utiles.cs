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


        public static List<Muestra> LoadCsvData(string filePath, out string unidad)
        {
            List<Muestra> dataList = new List<Muestra>();
            unidad = "";

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
                    parts = line.Split(',');
                    if (parts.Length < 2) continue;
                    if (parts[0].ToUpper() == "TIEMPO") unidad = parts[1];
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
                int row = 0;
                double tiempo, lectura;

                while (true)
                {
                    row++;
                    string celda1 = worksheet.Cell(row, 1).GetValue<string>();
                    string celda2 = worksheet.Cell(row, 2).GetValue<string>();

                    if (string.IsNullOrWhiteSpace(celda1) || string.IsNullOrWhiteSpace(celda2))
                        break;

                    if (!double.TryParse(celda1, out tiempo) || !double.TryParse(celda2, out lectura))
                    {
                        if (row == 1)
                            continue;
                        else
                            throw new Exception($"Error al leer los datos {celda1} / {celda2}");
                    }    
                    
                    Muestra muestra = new Muestra();
                    muestra.Tiempo = tiempo;
                    muestra.Canal[0] = lectura;
                    dataList.Add(muestra);
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


        public static double MapValues(int valor, int x0, int x, double y0, double y)
        {
            double m = (y - y0) / (x - x0);
            return m*(valor-x0) + y0;
        }


        public static double GetZero(double x0, double x, double y0, double y)
        {
            double m = (y - y0) / (x - x0);
            double zero = -1*(m * x0) + y0;
            return zero;
        }


        public static double GetSpan(double x0, double x, double y0, double y)
        {
            double m = (y - y0) / (x - x0);
            return  m;
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


        public static (double minimo, double maximo) GetMinimoMaximo(in List<Muestra> senal)
        {
            if (senal.Count == 0) return (0, 0);

            double minimo = senal[0].Canal[0];
            double maximo = senal[0].Canal[0];

            foreach (Muestra muestra in senal)
            {
                if (muestra.Canal[0] > maximo) maximo = muestra.Canal[0];
                if (muestra.Canal[0] < minimo) minimo = muestra.Canal[0];
            }

            return (minimo, maximo);
        }


        private static (double zero, double span) GetZeroSpan(ref List<Muestra> senal)
        {
            if (senal.Count == 0) return (0, 0);

            double minimo = senal[0].Canal[0];
            double maximo = senal[0].Canal[0];

            foreach (Muestra muestra in senal)
            {
                if (muestra.Canal[0] > maximo) maximo = muestra.Canal[0];
                if (muestra.Canal[0] < minimo) minimo = muestra.Canal[0];
            }

            return (minimo, maximo);
        }
    }
}
