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

            Series series = chartSenal.Series["Muestras"];

            Complex[] spectrum = FftSharp.FFT.Forward(signal);
            double[] psd = FftSharp.FFT.Magnitude(spectrum);
            double[] freq = FftSharp.FFT.FrequencyScale(psd.Length, sampleRate);

            for (int i = 0; i < psd.Count(); i++)
            {
                series.Points.AddXY(freq[i], psd[i]);
            }

            chartSenal.ChartAreas[0].AxisX.Interval = 2;
            chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            chartSenal.ChartAreas[0].AxisX.Minimum = 0;
            chartSenal.ChartAreas[0].AxisX.Maximum = 100;
            chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;
        }
    }
}
