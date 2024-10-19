using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmTextoMarcadorGrafico : Form
    {
        string _marcadorDescripcion;
        public string MarcadorDescripcion  
        {
            get { return _marcadorDescripcion ?? ""; }
            set { _marcadorDescripcion = value; }
        }

        public string MarcadorDescripcionResumen 
        { 
            get { return (MarcadorDescripcion ?? "").PadRight(10, ' ').Substring(0, 10) + "..."; } 
        }

        public FrmTextoMarcadorGrafico()
        {
            InitializeComponent();
        }

        private void FrmTextoMarcadorGrafico_Load(object sender, System.EventArgs e)
        {
            txtDescripcion.Text = MarcadorDescripcion;
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
