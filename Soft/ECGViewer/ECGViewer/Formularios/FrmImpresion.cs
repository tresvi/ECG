using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer.Formularios
{
    public partial class FrmImpresion : Form
    {
        private readonly Chart chartSenal;
        private PrintDocument printDocument;
        private List<Muestra> _senal;

        public FrmImpresion(Chart chart, in List<Muestra> senal)
        {
            chartSenal = chart;
            _senal = senal;
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (rbSimple.Checked)
            {
                ImpresionSimple();
            }
            else if (rbDoble.Checked)
            {
                ImpresionDoble();
            }
            else if (rbTriple.Checked)
            {
                ImpresionTriple();
            }

            return;

            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Configurar orientación Landscape
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintChart();
        }


        private void ImpresionSimple()
        {
            try
            {
                PrintDocument printDocument = chartSenal.Printing.PrintDocument;
                printDocument.DefaultPageSettings.Landscape = true; // Configurar orientación Landscape

                // Mostrar la vista previa de impresión
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                printPreviewDialog.WindowState = FormWindowState.Maximized;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir. Detalles: {ex}", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ImpresionDoble()
        {
            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Configurar orientación Landscape
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);


            // Crear y mostrar el PrintDialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                printPreviewDialog.WindowState = FormWindowState.Maximized;
                printPreviewDialog.ShowDialog();
            }
        }


        private void ImpresionTriple()
        {
            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Configurar orientación Landscape
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_Triple_PrintPage);


            // Crear y mostrar el PrintDialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                printPreviewDialog.WindowState = FormWindowState.Maximized;
                printPreviewDialog.ShowDialog();
            }
        }


        private void PrintDocument_Triple_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Obtener el área de impresión
                Graphics g = e.Graphics;

                int topMargin = 90; // Ajusta el valor para dejar más espacio superior

                // Definir el área de impresión para las tres secciones
                int width = e.MarginBounds.Width + 150;
                int sectionHeight = e.MarginBounds.Height / 3; // Dividir en 3 partes
                Rectangle topArea = new Rectangle(0, topMargin, width, sectionHeight);
                Rectangle middleArea = new Rectangle(0, topMargin + sectionHeight, width, sectionHeight);
                Rectangle bottomArea = new Rectangle(0, topMargin + sectionHeight * 2, width, sectionHeight);

                // Obtener el tamaño original del gráfico
                var originalSize = chartSenal.Size;

                // Redimensionar el gráfico para impresión
                chartSenal.Size = new Size((int)e.MarginBounds.Width, (int)e.MarginBounds.Height);

                // Calcular los puntos para dividir el gráfico en tres partes
                int thirdPoint = chartSenal.Series[0].Points.Count / 3;

                // Crear listas temporales para guardar los puntos de cada tercio
                var firstThirdPoints = new DataPoint[thirdPoint];
                var secondThirdPoints = new DataPoint[thirdPoint];
                var lastThirdPoints = new DataPoint[chartSenal.Series[0].Points.Count - (2 * thirdPoint)];

                // Copiar los puntos del primer tercio
                for (int i = 0; i < thirdPoint; i++)
                {
                    firstThirdPoints[i] = chartSenal.Series[0].Points[i];
                }

                // Copiar los puntos del segundo tercio
                for (int i = thirdPoint; i < 2 * thirdPoint; i++)
                {
                    secondThirdPoints[i - thirdPoint] = chartSenal.Series[0].Points[i];
                }

                // Copiar los puntos del último tercio
                for (int i = 2 * thirdPoint; i < chartSenal.Series[0].Points.Count; i++)
                {
                    lastThirdPoints[i - (2 * thirdPoint)] = chartSenal.Series[0].Points[i];
                }

                // Guardar el rango original del eje X
                double originalXMin = chartSenal.ChartAreas[0].AxisX.Minimum;
                double originalXMax = chartSenal.ChartAreas[0].AxisX.Maximum;

                // Dibujar el primer tercio del gráfico
                chartSenal.Series[0].Points.Clear();
                foreach (var point in firstThirdPoints)
                {
                    chartSenal.Series[0].Points.Add(point);
                }

                // Ajustar el rango del eje X para el primer tercio
                chartSenal.ChartAreas[0].AxisX.Minimum = firstThirdPoints[0].XValue;
                chartSenal.ChartAreas[0].AxisX.Maximum = firstThirdPoints[firstThirdPoints.Length - 1].XValue;
                chartSenal.Printing.PrintPaint(g, topArea);

                // Dibujar el segundo tercio del gráfico
                chartSenal.Series[0].Points.Clear();
                foreach (var point in secondThirdPoints)
                {
                    chartSenal.Series[0].Points.Add(point);
                }

                // Ajustar el rango del eje X para el segundo tercio
                chartSenal.ChartAreas[0].AxisX.Minimum = secondThirdPoints[0].XValue;
                chartSenal.ChartAreas[0].AxisX.Maximum = secondThirdPoints[secondThirdPoints.Length - 1].XValue;
                chartSenal.Printing.PrintPaint(g, middleArea);

                // Dibujar el último tercio del gráfico
                chartSenal.Series[0].Points.Clear();
                foreach (var point in lastThirdPoints)
                {
                    chartSenal.Series[0].Points.Add(point);
                }

                // Ajustar el rango del eje X para el último tercio
                chartSenal.ChartAreas[0].AxisX.Minimum = lastThirdPoints[0].XValue;
                chartSenal.ChartAreas[0].AxisX.Maximum = lastThirdPoints[lastThirdPoints.Length - 1].XValue;
                chartSenal.Printing.PrintPaint(g, bottomArea);

                // Restaurar el tamaño y los ejes originales del gráfico
                chartSenal.Series[0].Points.Clear();
                chartSenal.ChartAreas[0].AxisX.Minimum = originalXMin;
                chartSenal.ChartAreas[0].AxisX.Maximum = originalXMax;
                chartSenal.Size = originalSize;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al imprimir. Detalles: {ex}", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            GraphicHelpers.CargarGrafico(chartSenal, _senal);
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Obtener el área de impresión
                Graphics g = e.Graphics;

                int topMargin = 90; // Ajusta el valor para dejar más espacio superior

                // Definir el área de impresión para la parte superior
                int width = e.MarginBounds.Width + 150; // Reducir el margen derecho en 50 píxeles
                Rectangle topArea = new Rectangle(0, topMargin, width, e.MarginBounds.Height / 2);

                // Definir el área de impresión para la parte inferior
                Rectangle bottomArea = new Rectangle(0, topMargin + e.MarginBounds.Height / 2, width, e.MarginBounds.Height / 2);

                // Obtener el tamaño original del gráfico
                var originalSize = chartSenal.Size;

                // Redimensionar el gráfico para imprimir
                chartSenal.Size = new Size((int)e.MarginBounds.Width, (int)e.MarginBounds.Height);

                // Calcular el punto medio para dividir el gráfico
                int midPoint = chartSenal.Series[0].Points.Count / 2;

                // Crear listas temporales para guardar los puntos de la serie
                var topHalfPoints = new DataPoint[midPoint];
                var bottomHalfPoints = new DataPoint[chartSenal.Series[0].Points.Count - midPoint];

                // Copiar la primera mitad de los puntos
                for (int i = 0; i < midPoint; i++)
                {
                    topHalfPoints[i] = chartSenal.Series[0].Points[i];
                }

                // Copiar la segunda mitad de los puntos
                for (int i = midPoint; i < chartSenal.Series[0].Points.Count; i++)
                {
                    bottomHalfPoints[i - midPoint] = chartSenal.Series[0].Points[i];
                }


                chartSenal.ChartAreas[0].AxisX.Interval = 1;

                // Dibujar la parte superior del gráfico
                chartSenal.Series[0].Points.Clear(); // Limpiar los puntos de la serie
                foreach (var point in topHalfPoints)
                {
                    chartSenal.Series[0].Points.Add(point); // Agregar cada punto de la mitad superior
                }
                chartSenal.Printing.PrintPaint(g, topArea);

                // Dibujar la parte inferior del gráfico
                chartSenal.Series[0].Points.Clear(); // Limpiar los puntos de la serie
                foreach (var point in bottomHalfPoints)
                {
                    chartSenal.Series[0].Points.Add(point); // Agregar cada punto de la mitad inferior
                }

                chartSenal.ChartAreas[0].AxisX.Minimum = chartSenal.ChartAreas[0].AxisX.Maximum;
                chartSenal.Printing.PrintPaint(g, bottomArea);

                // Restaurar el tamaño original del gráfico
                chartSenal.ChartAreas[0].AxisX.Minimum = 0;
                chartSenal.Size = originalSize;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al imprimir. Detalles: {ex}", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 


            GraphicHelpers.CargarGrafico(chartSenal, _senal);
        }


        private void PrintChart()
        {
            // Mostrar la vista previa de impresión
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void rbDoble_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
