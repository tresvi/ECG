using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer
{
    public partial class FrmPasaEliminaBanda : Form
    {
        private const decimal DIFERENCIA_FRECUENCIA_MIN = 0.1M;
        public decimal FrecuenciaCorteMin { get; private set; }
        public decimal FrecuenciaCorteMax { get; private set; }

        public FrmPasaEliminaBanda(string title, decimal fCorteMinDefault, decimal fCorteMaxDefault)
        {
            InitializeComponent();
            this.Text = title;
            nudFrecuenciaCorteMin.Value = fCorteMinDefault;
            nudFrecuenciaCorteMax.Value = fCorteMaxDefault;
        }

        private void BtnAplicar_Click(object sender, System.EventArgs e)
        {
            FrecuenciaCorteMin = nudFrecuenciaCorteMin.Value;
            FrecuenciaCorteMax = nudFrecuenciaCorteMax.Value;

            if (FrecuenciaCorteMax - FrecuenciaCorteMin < DIFERENCIA_FRECUENCIA_MIN)
            {
                MessageBox.Show($"La diferencia minima entre la F. Corte Max y F.Corte Min, debe ser mayor a {DIFERENCIA_FRECUENCIA_MIN} Hz");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
