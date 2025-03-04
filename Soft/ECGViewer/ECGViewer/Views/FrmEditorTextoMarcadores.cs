using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmEditorTextoMarcadores : Form
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

        public FrmEditorTextoMarcadores()
        {
            InitializeComponent();
        }


        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnAplicar_Click(object sender, System.EventArgs e)
        {
            MarcadorDescripcion = txtDescripcion.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmEditorTextoMarcadores_Shown(object sender, System.EventArgs e)
        {
            txtDescripcion.Text = MarcadorDescripcion;
            txtDescripcion.Focus();
        }
    }
}
