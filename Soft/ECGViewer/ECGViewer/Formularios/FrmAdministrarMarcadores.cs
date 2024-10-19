using ECGViewer.Modelos;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer.Formularios
{
    public partial class FrmAdministrarMarcadores : Form
    {
        Chart _chart;

        public FrmAdministrarMarcadores(Chart chart)
        {
            InitializeComponent();

            _chart = chart;
            foreach (StripLine line in chart.ChartAreas[0].AxisX.StripLines)
            {
                StripLineWithComment stripLineWithComment = (StripLineWithComment) line;
                lBMarcadores.Items.Add(stripLineWithComment);
            }

            if (lBMarcadores.Items.Count > 0) lBMarcadores.SelectedIndex = 0;
        }


        private void btnBorrarMarcador_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Confirma borrar este marcador?", "Borrar marcador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes) BorrarItem();
        }


        private void lBMarcadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            BorrarItem();
        }


        private void BorrarItem()
        {
            if (lBMarcadores.SelectedIndex == -1) return;

            try
            {
                object itemABorrar = lBMarcadores.SelectedItem;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lBMarcadores.SelectedIndex == -1) return;

            try
            {
                StripLineWithComment itemSeleccionado = (StripLineWithComment)lBMarcadores.SelectedItem;
                FrmTextoMarcadorGrafico frmTextoMarcador = new FrmTextoMarcadorGrafico();
                frmTextoMarcador.MarcadorDescripcion = itemSeleccionado?.Descripcion ?? "";
                frmTextoMarcador.ShowDialog();

                if (frmTextoMarcador.DialogResult == DialogResult.Cancel) return;

                itemSeleccionado.Descripcion = frmTextoMarcador.MarcadorDescripcion;
                lBMarcadores.Items[lBMarcadores.SelectedIndex] = itemSeleccionado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar Marcador. Detalles: {ex}", "Borrar Marcador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
