using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECGViewer.Models.Dao
{
    internal class MuestraDao
    {
        public const string CABECERA_ANOTACIONES = "## ";
        public const string SEPARADOR_ANOTACIONES = "#|#";

        public List<Muestra> ListFromFile(string filePath, out string unidad, out List<StripLineWithComment> anotaciones)
        {
            string[] separadorAnotaciones = new string[] { SEPARADOR_ANOTACIONES };
            List<Muestra> dataList = new List<Muestra>();
            unidad = "";
            anotaciones = new List<StripLineWithComment>();

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
                else if (line.StartsWith(CABECERA_ANOTACIONES))
                {
                    string lineaAux = line.Substring(CABECERA_ANOTACIONES.Length);
                    string[] anotacionArray = lineaAux.Split(separadorAnotaciones, StringSplitOptions.None);
                    if (anotacionArray.Length < 3) continue;

                    if (double.TryParse(anotacionArray[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double posX) &&
                        double.TryParse(anotacionArray[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double posY))
                    {
                        StripLineWithComment anotacion = new StripLineWithComment(posX, posY, anotacionArray[2], 12, 10);
                        anotaciones.Add(anotacion);
                    }
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
    }
}
