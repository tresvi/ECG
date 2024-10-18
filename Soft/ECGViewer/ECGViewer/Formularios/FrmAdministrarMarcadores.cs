using ECGViewer.Modelos;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer.Formularios
{
    public partial class FrmAdministrarMarcadores : Form
    {
        //StripLinesCollection _stripLines;
        Chart _chart;

        public FrmAdministrarMarcadores(Chart chart)
        {
            InitializeComponent();

            //_stripLines = stripLines;
            _chart = chart;
            foreach (StripLine line in chart.ChartAreas[0].AxisX.StripLines)
            {
                StripLineWithComment stripLineWithComment = (StripLineWithComment) line;
                lBMarcadores.Items.Add(stripLineWithComment);
            }
        }

        private void btnBorrarMarcador_Click(object sender, EventArgs e)
        {
            BorrarItem();
        }


        private void lBMarcadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            BorrarItem();
        }


        private void BorrarItem()
        {
            try
            {
                if (lBMarcadores.SelectedIndex == -1) return;

                object itemABorrar = lBMarcadores.SelectedItem;

                //((StripLineWithComment)itemABorrar).Annotation
                //_stripLines.Remove((StripLine)itemABorrar);
                Annotation annotation = ((StripLineWithComment)itemABorrar).Annotation;
                _chart.Annotations.Remove(annotation);
                _chart.ChartAreas[0].AxisX.StripLines.Remove((StripLine)itemABorrar);
                lBMarcadores.Items.Remove(itemABorrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar Marcador. Detalles: {ex}", "Borrar Marcador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
