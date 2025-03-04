using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer
{
    public partial class FrmEspectro : Form
    {
        public FrmEspectro(double[] signal, int sampleRate)
        {
            InitializeComponent();

            Series series = chartEspectro.Series["Muestras"];

            Complex[] spectrum = FftSharp.FFT.Forward(signal);
            double[] psd = FftSharp.FFT.Magnitude(spectrum);
            double[] freq = FftSharp.FFT.FrequencyScale(psd.Length, sampleRate);

            for (int i = 0; i < psd.Count(); i++)
            {
                series.Points.AddXY(freq[i], psd[i]);
            }

            chartEspectro.ChartAreas[0].AxisX.Interval = 2;
            chartEspectro.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            chartEspectro.ChartAreas[0].AxisX.Minimum = 0;
            chartEspectro.ChartAreas[0].AxisX.Maximum = 100;
            chartEspectro.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chartEspectro.ChartAreas[0].AxisY.Maximum = Double.NaN;
        }
    }
}
