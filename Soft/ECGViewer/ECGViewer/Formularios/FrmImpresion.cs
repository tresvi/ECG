using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer.Formularios
{
    public partial class FrmImpresion : Form
    {
        private readonly Chart _chartSenal;
        private PrintDocument printDocument;

        public FrmImpresion(Chart chart)
        {
            _chartSenal = chart;
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Configurar orientación Landscape
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintChart();
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener el área de impresión
            Graphics g = e.Graphics;

            // Definir el área de impresión para la parte superior
            int width = e.MarginBounds.Width + 150; // Reducir el margen derecho en 50 píxeles
            Rectangle topArea = new Rectangle(0, 0, width, e.MarginBounds.Height / 2);

            // Definir el área de impresión para la parte inferior
            Rectangle bottomArea = new Rectangle(0, e.MarginBounds.Height / 2, width, e.MarginBounds.Height / 2);

            // Obtener el tamaño original del gráfico
            var originalSize = _chartSenal.Size;

            _chartSenal.ChartAreas[0].AxisX.Title = ""; // Ocultar el título del eje X
            _chartSenal.ChartAreas[0].AxisY.Title = ""; // Ocultar el título del eje Y

            // Redimensionar el gráfico para imprimir
            _chartSenal.Size = new Size((int)e.MarginBounds.Width, (int)e.MarginBounds.Height);

            // Calcular el punto medio para dividir el gráfico
            int midPoint = _chartSenal.Series[0].Points.Count / 2;

            // Crear listas temporales para guardar los puntos de la serie
            var topHalfPoints = new DataPoint[midPoint];
            var bottomHalfPoints = new DataPoint[_chartSenal.Series[0].Points.Count - midPoint];

            // Copiar la primera mitad de los puntos
            for (int i = 0; i < midPoint; i++)
            {
                topHalfPoints[i] = _chartSenal.Series[0].Points[i];
            }

            // Copiar la segunda mitad de los puntos
            for (int i = midPoint; i < _chartSenal.Series[0].Points.Count; i++)
            {
                bottomHalfPoints[i - midPoint] = _chartSenal.Series[0].Points[i];
            }

            // Dibujar la parte superior del gráfico
            _chartSenal.Series[0].Points.Clear(); // Limpiar los puntos de la serie
            foreach (var point in topHalfPoints)
            {
                _chartSenal.Series[0].Points.Add(point); // Agregar cada punto de la mitad superior
            }
            _chartSenal.Printing.PrintPaint(g, topArea);

            // Dibujar la parte inferior del gráfico
            _chartSenal.Series[0].Points.Clear(); // Limpiar los puntos de la serie
            foreach (var point in bottomHalfPoints)
            {
                _chartSenal.Series[0].Points.Add(point); // Agregar cada punto de la mitad inferior
            }
            _chartSenal.Printing.PrintPaint(g, bottomArea);

            // Restaurar el tamaño original del gráfico
            _chartSenal.Size = originalSize;
        }

        private void PrintChart()
        {
            // Mostrar la vista previa de impresión
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }
    }
}
