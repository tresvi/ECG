using ECGViewer.Utiles;
using System;
using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmControlesFiltroInteractivo : Form
    {
        public FrmConsolaFiltros FormConsola { get; set; }

        public FrmControlesFiltroInteractivo(FrmConsolaFiltros frmConsolaFiltros)
        {
            FormConsola = frmConsolaFiltros;
            InitializeComponent();

            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            lblFCorteInferior.Text = fCorteInferior.ToString("0.0") + " Hz";
            lblFCorteSuperior.Text = fCorteSuperior.ToString("0.0") + " Hz";
            chkTransparencia.Checked = true;
        }

        private void tbFCorteInferior_ValueChanged(object sender, EventArgs e)
        {
            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            lblFCorteInferior.Text = fCorteInferior.ToString("0.0") + " Hz";
            FormConsola.AplicarFiltrosPasaBanda(fCorteInferior, fCorteSuperior);

            if (fCorteInferior >= fCorteSuperior)
            {
                int nuevoValor = tbFCorteInferior.Value - 1;
                if (nuevoValor < tbFCorteInferior.Minimum) nuevoValor = tbFCorteInferior.Minimum;

                tbFCorteSuperior.Value = nuevoValor;
            }
        }

        private void tbFCorteSuperior_ValueChanged(object sender, EventArgs e)
        {
            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            lblFCorteSuperior.Text = fCorteSuperior.ToString("0.0") + " Hz";
            FormConsola.AplicarFiltrosPasaBanda(fCorteInferior, fCorteSuperior);

            if (fCorteSuperior <= fCorteInferior)
            {
                int nuevoValor = tbFCorteSuperior.Value + 1;
                if (nuevoValor > tbFCorteInferior.Maximum) nuevoValor = tbFCorteInferior.Maximum;

                tbFCorteInferior.Value = nuevoValor;
            }
        }


        private void chkTransparencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransparencia.Checked)
                this.Opacity = 0.9;
            else
                this.Opacity = 1;
        }


        private void FrmControlesFiltroInteractivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

    }
}
