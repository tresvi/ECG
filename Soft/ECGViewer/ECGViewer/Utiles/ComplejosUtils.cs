using ECGViewer.Modelos;
using System.Collections.Generic;

namespace ECGViewer.Utiles
{
    internal class ComplejosUtils
    {
        private const double TIEMPO_GUARDA_QR_RS_SEC = 0.150; //Tiempo de guarda que no debe ser superado entre complejos QR. Ayuda a depurar la detección.

        /// <summary>
        /// Detecta la terna de complejos QRS buscando un pico que este rodeado a su izq. y der. por otros picos 
        /// menores que el.
        /// </summary>
        /// <param name="senal"></param>
        /// <param name="tMuestreo"></param>
        /// <param name="validarTiempos"></param>
        /// <returns></returns>
        public static List<ComplejoPQRST> GetComplejosQRS(in double[] senal, double tMuestreo, bool validarTiempos)
        {
            List<int> picos = SignalUtils.DetectarPicos(senal);
            List<ComplejoPQRST> complejosDetectados = new List<ComplejoPQRST>();

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
                            complejosDetectados.Add(new ComplejoPQRST(indexPicoAnterior, indexPicoActual, indexPicoSiguiente));
                    }
                    else
                        complejosDetectados.Add(new ComplejoPQRST(indexPicoAnterior, indexPicoActual, indexPicoSiguiente));
                }
            }

            return complejosDetectados;
        }
    }
}
