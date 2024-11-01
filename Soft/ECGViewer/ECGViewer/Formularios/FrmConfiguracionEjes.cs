using System;
using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmConfiguracionEjes : Form
    {
        public string Unidad { get; private set; }
        public double EjeXMin { get; private set; }
        public double EjeXMax { get; private set; }
        public double EjeYMin { get; private set; }
        public double EjeYMax { get; private set; }


        public FrmConfiguracionEjes(string unidad)
        {
            InitializeComponent();
            Unidad = unidad;
            txtUnidad.Text = Unidad;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Unidad = txtUnidad.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
