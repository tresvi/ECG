using System;
using System.Windows.Forms;

namespace ECGViewer.Views
{
    public partial class FrmControlSuavizadoInteractivo : Form
    {
        public FrmConsolaFiltros FormConsola { get; set; }

        public FrmControlSuavizadoInteractivo(FrmConsolaFiltros formConsolaFiltros )
        {
            FormConsola = formConsolaFiltros;
            InitializeComponent();
            chkTransparencia.Checked = true;
        }


        private void tbSuavizado_ValueChanged(object sender, EventArgs e)
        {
            int intensidad = tbSuavizado.Maximum - tbSuavizado.Value;
            lblSuavizar.Text = intensidad.ToString();

            FormConsola.AplicarSuavizado(intensidad);
        }


        private void chkTransparencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransparencia.Checked)
                this.Opacity = 0.9;
            else
                this.Opacity = 1;
        }

        private void FrmControlSuavizadoInteractivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
