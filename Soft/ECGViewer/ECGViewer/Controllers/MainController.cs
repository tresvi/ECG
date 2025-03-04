using ECGViewer.Models;
using ECGViewer.Models.Dao;
using System;
using System.Collections.Generic;

namespace ECGViewer.Controllers
{
    internal class MainController
    {

        public MainController()
        {
        }


        public (List<Muestra> senalECG, List<StripLineWithComment>, string unidad) OpenFileCSV(string fileName)
        {
            string unidad;
            List<StripLineWithComment> anotaciones = new List<StripLineWithComment>();
            MuestraDao muestraDao = new MuestraDao();
            List<Muestra> senalECG = muestraDao.ListFromFile(fileName, out unidad, out anotaciones);

            if (senalECG.Count <= 1)
                throw new Exception($"Archivo invalido. El mismo contiene menos de 1 muestra");

            return (senalECG, anotaciones, unidad);
        }



    }
}
