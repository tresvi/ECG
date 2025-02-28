using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }


        private void tbFCorteInferior_Scroll(object sender, EventArgs e)
        {
            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            lblFCorteInferior.Text = fCorteInferior.ToString("0.0") + " Hz";
            FormConsola.AplicarFiltrosPasaBanda(fCorteInferior, fCorteSuperior);
        }


        private void tbFCorteSuperior_Scroll(object sender, EventArgs e)
        {
            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            

            lblFCorteSuperior.Text = fCorteSuperior.ToString("0.0") + " Hz";
            FormConsola.AplicarFiltrosPasaBanda(fCorteInferior, fCorteSuperior);
        }



        private void tbFCorteInferior_ValueChanged(object sender, EventArgs e)
        {
            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            if (fCorteInferior >= fCorteSuperior)
            {
                tbFCorteSuperior.Value = tbFCorteInferior.Value - 1;
            }
        }

        private void tbFCorteSuperior_ValueChanged(object sender, EventArgs e)
        {
            double fCorteInferior = (tbFCorteInferior.Maximum - tbFCorteInferior.Value) * 0.5;
            double fCorteSuperior = (tbFCorteSuperior.Maximum - tbFCorteSuperior.Value) * 0.5;

            if (fCorteSuperior <= fCorteInferior)
            {
                tbFCorteInferior.Value = tbFCorteSuperior.Value + 1;
            }
        }

    }
}
