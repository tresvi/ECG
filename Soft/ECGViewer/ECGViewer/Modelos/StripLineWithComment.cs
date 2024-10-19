using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer.Modelos
{
    internal class StripLineWithComment: StripLine
    {
        public TextAnnotation Annotation { get; set; }
        public double PosicionX { get; }
        public double PosicionY { get; }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { 
                _descripcion = value;
                if (Annotation != null) Annotation.Text = DescripcionResumen; 
            }
        }

        public string DescripcionResumen 
        {
            get 
            {
                return (_descripcion ?? "").PadRight(_longTextoResumen, ' ')
                    .Substring(0, _longTextoResumen)
                    .Trim() + "...";
            }
        }

        private readonly int _fontSize;
        private readonly int _longTextoResumen;

        public StripLineWithComment(double xPos, double yPos, string text, int fontSize, int longTextoResumen)
        {
            _fontSize = fontSize;
            _longTextoResumen = longTextoResumen;
            /*
            TextAlignment = StringAlignment.Far;
            TextLineAlignment = StringAlignment.Near;
            //TextOrientation = TextOrientation.;
            ForeColor = Color.Blue;
            Font = new Font("Arial", 12, FontStyle.Bold);
            Text = Texto;
            */
            PosicionX = xPos;
            PosicionY = yPos;
            IntervalOffset = xPos;
            BorderColor = Color.Red;
            BorderWidth = 2;
            BorderDashStyle = ChartDashStyle.Dash;

            Annotation = new TextAnnotation();
            Annotation.Text = string.IsNullOrWhiteSpace(text) ? "" : DescripcionResumen;
            Annotation.X = PosicionX;
            Annotation.Y = PosicionY;
            Annotation.Font = new Font("Arial", fontSize, FontStyle.Bold);
            Annotation.ForeColor = Color.Blue;
            Annotation.AnchorX = PosicionX;
            Annotation.AnchorY = PosicionY;
        }


        /*
        public void SetTexto(string texto, int fontSize, int longTextoResumen)
        {
            Annotation = new TextAnnotation();
            string textoResumido = texto.;
            Annotation.Text = textoResumido;
            Annotation.X = PosicionX;
            Annotation.Y = PosicionY;
            Annotation.Font = new Font("Arial", fontSize, FontStyle.Bold);
            Annotation.ForeColor = Color.Blue;
            Annotation.AnchorX = PosicionX;
            Annotation.AnchorY = PosicionY;
        }
        */
        public override string ToString()
        {
            if (Annotation == null) 
                return $"{PosicionX.ToString("00.000")} | ";
            else
                return $"{PosicionX.ToString("00.000")} | {_descripcion}";
        }
    }
}
