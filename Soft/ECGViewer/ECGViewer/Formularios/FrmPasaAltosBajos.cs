using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ECGViewer
{
    public partial class FrmPasaAltosBajos : Form
    {
        public decimal FrecuenciaCorte { get; private set; }

        public FrmPasaAltosBajos(string title, decimal frecuencaCorteDefault)
        {
            InitializeComponent();
            this.Text = title;
            nudFrecuenciaCorte.Value = frecuencaCorteDefault;
        }


        internal decimal GetFrecuenciaCorte()
        {
            return nudFrecuenciaCorte.Value;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            FrecuenciaCorte = nudFrecuenciaCorte.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
