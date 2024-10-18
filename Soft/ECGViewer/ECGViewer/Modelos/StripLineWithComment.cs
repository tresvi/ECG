using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer.Modelos
{
    internal class StripLineWithComment: StripLine
    {
        public TextAnnotation Annotation { get; set; }
        public String Texto { get; set; }
        public double PosicionX { get; }
        public double PosicionY { get; }

        public StripLineWithComment(double xPos, double yPos, string texto)
        {
            /*
            TextAlignment = StringAlignment.Far;
            TextLineAlignment = StringAlignment.Near;
            //TextOrientation = TextOrientation.;
            ForeColor = Color.Blue;
            Font = new Font("Arial", 12, FontStyle.Bold);
            Text = Texto;
            */
            Texto = texto;
            PosicionX = xPos;
            PosicionY = yPos;
            IntervalOffset = xPos;
            BorderColor = Color.Red;
            BorderWidth = 2;
            BorderDashStyle = ChartDashStyle.Dash;
        }

        public void SetTexto(string texto, int fontSize, int longTextoResumen)
        {
            Texto = texto;

            Annotation = new TextAnnotation();
            string textoResumido = texto.PadRight(longTextoResumen, ' ').Substring(0, longTextoResumen).Trim() + "...";
            Annotation.Text = textoResumido;
            Annotation.X = PosicionX;
            Annotation.Y = PosicionY;
            Annotation.Font = new Font("Arial", fontSize, FontStyle.Bold);
            Annotation.ForeColor = Color.Blue;
            Annotation.AnchorX = PosicionX;
            Annotation.AnchorY = PosicionY;
        }

        public override string ToString()
        {
            if (Annotation == null) return "";
            return Texto;
        }
    }
}
