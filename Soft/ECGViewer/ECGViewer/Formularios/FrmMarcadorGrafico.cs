using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmMarcadorGrafico : Form
    {
        public string MarcadorDescripcion { get; set; }
        public string MarcadorDescripcionResumen 
        { 
            get { return MarcadorDescripcion.PadRight(10, ' ').Substring(0, 10) + "..."; } 
        }

        public FrmMarcadorGrafico()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnAplicar_Click(object sender, System.EventArgs e)
        {
            MarcadorDescripcion = txtDescripcion.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
