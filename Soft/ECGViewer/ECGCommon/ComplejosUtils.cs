using ECGCommon.Modelos;
using FftSharp;
using System.Collections.Generic;

namespace ECGViewer.Utiles
{
    public class ComplejosUtils
    {
        private const double TIEMPO_GUARDA_QR_RS_SEC = 0.150; //Tiempo de guarda que no debe ser superado entre complejos QR. Ayuda a depurar la detección.


        /// <summary>
        /// Obtiene solo la lista de complejos QRS
        /// </summary>
        /// <returns></returns>
        public static List<ComplejoPQRST> GetComplejosQRS(in double[] senalCruda, double frecuenciaMuestreo )
        {
            const int F_CORTE_INF_FPBANDA = 1;
            const int F_CORTE_SUP_FPBANDA = 49;

            double[] senalAProcesar = Filter.BandPass(senalCruda, frecuenciaMuestreo, 12, 30);

            //No se utiliza rectificación porque la señal puede venir al reves
            SignalUtils.ElevarAlCuadrado(ref senalAProcesar);

            double valorMedioPicos = SignalUtils.CalcularPromedioPicos(senalAProcesar);
            Filtros.RecortePorValorBajo(ref senalAProcesar, valorMedioPicos);

            double tMuestreo = 1 / (double) frecuenciaMuestreo;
            List<ComplejoPQRST> complejosQRS = ComplejosUtils.GetComplejosQRSDesdeSenalTernaDePicos(senalAProcesar, tMuestreo, true);

            //TODO: Se podria tomar sin fitrar con el FPB, pero para señales muy malas, podria quedar muy mal.
            //por el momento se deja asi, aunque esto implique haer otra FFT mas.
            //Luego del filtrado y el procesamiento los picos pueden sufirr un cierto desfasaje.
            //Para corregirlo necesito la señal original con buena calidad.
            double[] senalOriginalFiltrada = Filter.BandPass(senalCruda, frecuenciaMuestreo, F_CORTE_INF_FPBANDA, F_CORTE_SUP_FPBANDA);
            SignalUtils.DesbalancearMesetas(ref senalOriginalFiltrada);
            int[] indicesDeExtremos = SignalUtils.GetExtremosLocales(senalOriginalFiltrada);

            //Para cada complejo me fijo cual es el Máximo/Mínimo mas cercano, y lo remplazo por el.
            //De esta forma se ajusta el desfasaje temporal
            foreach (ComplejoPQRST complejo in complejosQRS)
            {
                complejo.Q = SignalUtils.IndiceMasCercano(complejo.Q, indicesDeExtremos);
                complejo.R = SignalUtils.IndiceMasCercano(complejo.R, indicesDeExtremos);
                complejo.S = SignalUtils.IndiceMasCercano(complejo.S, indicesDeExtremos);
            }

            return complejosQRS;
        }


        /// <summary>
        /// Detecta los complejos T partiendo de la señal original y de las lista con los complejos QRS
        /// Luego los carga en la misma lista de complejos.
        /// </summary>
        /// <param name="senalCruda">Copia de la senal original</param>
        /// <param name="complejosQRS">Senal con complejos QRS ya cargados. En ella se completaran los T encontrados</param>
        public static void CargarComplejoT(double[] senalCruda, double frecuenciaMuestreo, ref List<ComplejoPQRST> complejosPQRST)
        {
            //Se filtra la señal, y luego se la suaviza
            //senalProcesada = Filter.BandPass(senal, _frecuenciaMuestreo, 1, 9.5);
            double[] senalAProcesar = Filter.BandPass(senalCruda, frecuenciaMuestreo, 1, 35);

            for (int i = 0; i < 10; i++)
                senalAProcesar = Filtros.MediaMovil(senalAProcesar, 3);

            //Desbalanceo las mesetas antes de buscar los picos
            SignalUtils.DesbalancearMesetas(ref senalAProcesar);;

            //Me paro en los complejos S y miro hacia el proximo complejo Q, en esta area tiene
            //que encontrarse el complejo T. Tomo esta area, analizo todos sus picos para quedarme
            //con el mayor. Este sera el complejo T.
            for (int i = 0; i < complejosPQRST.Count; i++)
            {
                if (i < complejosPQRST.Count - 1)
                {
                    complejosPQRST[i].T = SignalUtils.EncontrarPicoMaximoLocal(senalAProcesar, complejosPQRST[i].S, complejosPQRST[i + 1].Q);
                }
                else
                {
                    //La detección del ultimo complejo tiene tratamiento especial, ya que no hay 
                    //una terna QRS proxima, ya que se termina la senal.
                    int siguienteMaximo = SignalUtils.EncontrarPicoMaximoLocal(senalAProcesar, complejosPQRST[i].S, senalAProcesar.Length - 1);
                    if (siguienteMaximo > -1) complejosPQRST[i].T = siguienteMaximo;
                }
            }
        }


        /// <summary>
        /// Detecta los complejos P partiendo de la señal original y de las lista con los complejos QRS y T
        /// Luego los carga en la misma lista de complejos.
        /// </summary>
        /// <param name="senalCruda">Copia de la senal original</param>
        /// <param name="complejosQRS">Senal con complejos QRS ya cargados. En ella se completaran los P encontrados</param>

        public static void CargarComplejoP(double[] senalCruda, double frecuenciaMuestreo, ref List<ComplejoPQRST> complejosPQRST)
        {
            //A priori Buscar un pico maximo entre el complejo T de t-1 y el Q actual.
            
            double[] senalAProcesar = Filter.BandPass(senalCruda, frecuenciaMuestreo, 0.5, 49);

            //Algoritmo hasta bajar el "IndiceDeRugosidad" de la señal a un valor <= 0.004
            //Parece ser un valor apropiado para señales de la naturaleza de las de ECG
            for (int i = 0; i < 10; i++)
            {
                senalAProcesar = Filtros.MediaMovil(senalAProcesar, 3);
            }

            //Desbalanceo antes de buscar los máximos
            SignalUtils.DesbalancearMesetas(ref senalAProcesar);

            //Me paro en el complejo T (un par de muestras adelante) y miro hacia el siguiente complejo Q.
            //El mayoer de todos los picos que encuentre, ese será el complejo P
            for (int i = 1; i < complejosPQRST.Count; i++)
            {
                complejosPQRST[i].P = SignalUtils.EncontrarPicoMaximoLocal(senalAProcesar
                    , complejosPQRST[i - 1].T + 5 + (complejosPQRST[i].Q - complejosPQRST[i - 1].T + 5) / 2
                    , complejosPQRST[i].Q);

                //El ultimo complejo deberia tener tratamiento especial
            }
        }


        /// <summary>
        /// Detecta la terna de complejos QRS buscando un pico que este rodeado a su izq. y der. por otros picos 
        /// menores que el.
        /// </summary>
        /// <param name="senalTernaDePicos"></param>
        /// <param name="tMuestreo"></param>
        /// <param name="validarTiempos"></param>
        /// <returns></returns>
        public static List<ComplejoPQRST> GetComplejosQRSDesdeSenalTernaDePicos(in double[] senalTernaDePicos, double tMuestreo, bool validarTiempos)
        {
            List<int> picos = SignalUtils.DetectarPicos(senalTernaDePicos);
            List<ComplejoPQRST> complejosDetectados = new List<ComplejoPQRST>();

            for (int i = 1; i < picos.Count - 1; i++) // Para asegurar que haya picos antes y despues
            {
                int indexPicoActual = picos[i];
                int indexPicoAnterior = picos[i - 1];
                int indexPicoSiguiente = picos[i + 1];

                //El complejo R siempre estara encerrado entre untre un Q y un S de menor amplitud
                if    (senalTernaDePicos[indexPicoActual] > senalTernaDePicos[indexPicoAnterior] 
                    && senalTernaDePicos[indexPicoActual] > senalTernaDePicos[indexPicoSiguiente])
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


        public static int ReducirRugosidad(ref double[] senal, double valorLimiteDeseado)
        {
            int iteraciones  = 0;

            while (SignalUtils.VariabilidadDiferencias(senal) > valorLimiteDeseado)
            {
                iteraciones++;
                senal = Filtros.MediaMovil(senal, 3);
            }
            return iteraciones;
        }


    }
}
