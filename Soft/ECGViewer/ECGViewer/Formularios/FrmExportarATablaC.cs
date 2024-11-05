using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace ECGViewer.Formularios
{
    public partial class FrmExportarATablaC : Form
    {
        private readonly List<Muestra> _senalECG;
        private readonly int _indiceMinimo;
        private readonly int _indiceMaximo;

        public FrmExportarATablaC(in List<Muestra> senalECG, int indiceMinimo, int indiceMaximo)
        {
            _senalECG = senalECG;
            _indiceMinimo = indiceMinimo;
            _indiceMaximo = indiceMaximo;

            InitializeComponent();
        }


        private void FrmExportarATablaC_Load(object sender, EventArgs e)
        {
            if (_senalECG.Count > 2)
            {
                string funcion;
                long delay;
                double tMuestroEnmS = (_senalECG[1].Tiempo - _senalECG[0].Tiempo)*1000;

                //delayMicroseconds() como maximo puede recibir como parametro, como maximo 65.536 us, es decir aprox, 65mS
                //Mas de 65mS, se debe usar delay()
                if (tMuestroEnmS < 65)
                {
                    funcion = "delayMicroseconds";
                    delay = (int) (tMuestroEnmS * 1000);
                }
                else
                {
                    funcion = "delay";
                    delay = (int)(tMuestroEnmS);
                }
                txtEjemploCodigo.Text = txtEjemploCodigo.Text.Replace("%FUNCION%", funcion.ToString());
                txtEjemploCodigo.Text = txtEjemploCodigo.Text.Replace("%DELAY%", delay.ToString());
            }

            if (cmbSaltoLinea.SelectedIndex == -1) cmbSaltoLinea.SelectedIndex = 1;

            int bitsSeleccionadosIndex = ECGViewer.Properties.Settings.Default.BitsParaEscaladoIndex;
            if (bitsSeleccionadosIndex < cmbBitsEscalado.Items.Count)
                cmbBitsEscalado.SelectedIndex = bitsSeleccionadosIndex;
            else
                cmbBitsEscalado.SelectedIndex = -1;
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_senalECG == null || _senalECG.Count < 1)
            {
                MessageBox.Show("Debe abrir un archivo para poder exportar una tabla");
                return;
            }

            if (cmbBitsEscalado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar La cantidad de Bits a escalar");
                return;
            }

            if (rbEstiloAssembler.Checked || rbEstiloC.Checked)
            {
                saveFileDialog.Filter = "Text Files | *.txt";
                saveFileDialog.DefaultExt = "txt";
            }
            else
            {
                saveFileDialog.Filter = "Binary Files | *.bin| Hexadecimal Files | *.hex";
                saveFileDialog.DefaultExt = "bin";
            }

            DialogResult respuesta = saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName.Trim() == "" || respuesta == DialogResult.Cancel) return;

            if (rbBinario.Checked)
            {
                EscribirBinario8Bits(saveFileDialog.FileName);
                this.Close();
                return;
            }

            long longTabla = _indiceMaximo - _indiceMinimo + 1;

            try
            {
                using (var sw = new StreamWriter(saveFileDialog.FileName))
                {
                    bool insertarSaltoLinea = (cmbSaltoLinea.SelectedIndex != 0);
                    int valoresParaSalto = cmbSaltoLinea.SelectedIndex * 10;

                    if (rbEstiloC.Checked)
                    {
                        EscribirTablaC(sw, insertarSaltoLinea, valoresParaSalto);
                        MessageBox.Show($"El archivo fue creado satisfactoriamente con {longTabla} valores reescalados {cmbBitsEscalado.Text} bits");
                    }
                    else if (rbEstiloAssembler.Checked)
                    {
                        MessageBox.Show("Las exportaciones a assembler solo se reescalan a 8 bits");
                        EscribirTablaAssembler(sw, insertarSaltoLinea, valoresParaSalto);
                        MessageBox.Show($"El archivo fue creado satisfactoriamente con {longTabla} valores reescalados 8 bits");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo. Detalles: " + ex.Message);
            }

            this.Close();
        }


        private void EscribirTablaAssembler(StreamWriter sw, bool insertarSaltoLinea, int valoresParaSalto)
        {
            bool primerValor = true;
            long longTabla = _indiceMaximo - _indiceMinimo + 1; //_senalECG.Count;
            int valorMuestra = 0;

            double y0 = 0;
            double y = Math.Pow(2, 8) - 1;
            (double x0, double x) = Utiles.GetMinimoMaximo(in _senalECG);
            double zero = Utiles.GetZero(x0, x, y0, y);
            double span = Utiles.GetSpan(x0, x, y0, y);

            if (longTabla % 2 == 1) 
                MessageBox.Show(this, "Atención: La cantidad de valores a exportar en la tabla es impar!"
                    , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            sw.Write("TABLA:\t.DB    ");

            for (int i = _indiceMinimo; i < longTabla; i++)
            {
                if (!primerValor)   //Evito poner la primer coma
                {
                    //Pongo salto de linea, o bien, pongo una coma.
                    if (insertarSaltoLinea && (i % valoresParaSalto == 0))
                        sw.Write("\r\n\t.DB    ");
                    else
                        sw.Write(" ,");
                }
                primerValor = false;
                valorMuestra = (int)((_senalECG[i].Canal[0] * span) + zero);
                sw.Write(valorMuestra.ToString());
            }
        }


        private void EscribirTablaC(StreamWriter sw, bool insertarSaltoLinea, int valoresParaSalto)
        {
            bool primerValor = true;
            long longTabla = _indiceMaximo - _indiceMinimo + 1; //_senalECG.Count;
            UInt32 valorMuestra = 0;

            int bitsEscalado = GetBitsEscalado();
            double y0 = 0;
            double y = Math.Pow(2, bitsEscalado) - 1;
            (double x0, double x) = Utiles.GetMinimoMaximo(in _senalECG);
            double zero = Utiles.GetZero(x0, x, y0, y);
            double span = Utiles.GetSpan(x0, x, y0, y);

            sw.Write($"const {GetDataType()} tabla[" + longTabla + "] = {");

            for (int i = _indiceMinimo; i < longTabla; i++)
            {
                if (!primerValor)   //Evita poner la primer coma
                {
                    if (insertarSaltoLinea)     //Coloca el salto si corresponde
                    {
                        if ((i % valoresParaSalto) == 0) sw.Write("\r\n\t");
                    }
                    sw.Write(" ,");
                }
                primerValor = false;
                valorMuestra = (UInt32) ((_senalECG[i].Canal[0] * span) + zero);
                sw.Write(valorMuestra.ToString());
            }
            sw.Write("\r\n};");
        }


        private void EscribirBinario8Bits(string fileName)
        {
            try
            {
                fileName = Regex.Replace(fileName, "txt", "bin", RegexOptions.IgnoreCase);
                if (File.Exists(fileName)) File.Delete(fileName);

                using (var stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                using (var writer = new BinaryWriter(stream))
                {
                    for (int i = 0; i < _senalECG.Count; i++)
                    {
                        writer.Write((byte)_senalECG[i].Canal[0]);
                    }
                    writer.Write((byte)0x00);  // Escribo un 0 para indicar el fin del archivo
                }

                MessageBox.Show("El archivo fue creado satisfactoriamente con " + _senalECG.Count + " valores");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo. Detalles: " + ex.Message);
            }
        }


        private void rbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBinario.Checked)
                gpbSaltoLinea.Visible = false;
            else
                gpbSaltoLinea.Visible = true;
        }


        private int GetBitsEscalado()
        { 
            string bitText = cmbBitsEscalado.Text;
            return int.Parse(bitText);
        }

        private string GetDataType()
        {
            int bitsEscalado = GetBitsEscalado();
            if (bitsEscalado <= 8)
                return "unsigned char";
            else if (bitsEscalado <= 16)
                return "unsigned short";
            else return "unsigned long";
        }

    }
}
