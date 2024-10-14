using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ECGViewer.Controles
{
    public class ToggleButton : CheckBox
    {
        //Fields
        private Color _onBackColor = Color.MediumSlateBlue;
        private Color _onToggleColor = Color.WhiteSmoke;
        private Color _offBackColor = Color.Gray;
        private Color _offToggleColor = Color.Gainsboro;
        private bool _solidStyle = true;

        private Color backgroundColor = Color.Transparent;

        //Properties
        [Category("RJ Code Advance")]
        public Color OnBackColor
        {
            get { return _onBackColor; }
            set{ _onBackColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color OnToggleColor
        {
            get { return _onToggleColor; }
            set { _onToggleColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color OffBackColor
        {
            get { return _offBackColor; }
            set { _offBackColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color OffToggleColor
        {
            get { return _offToggleColor; }
            set { _offToggleColor = value; this.Invalidate(); }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
        }

        [Category("RJ Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return _solidStyle; }
            set { _solidStyle = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; this.Invalidate(); }
        }

        //Constructor
        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
            this.BackColor = Color.Transparent; // Inicializa como transparente
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            // Cambia el fondo del control a transparente o usa el color definido
            if (backgroundColor == Color.Transparent)
            {
                pevent.Graphics.Clear(this.Parent.BackColor);
            }
            else
            {
                pevent.Graphics.Clear(backgroundColor);
            }

            if (this.Checked) //ON
            {
                //Draw the control surface
                if (_solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(_onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(_onBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(_onToggleColor),
                    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                //Draw the control surface
                if (_solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(_offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(_offBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(_offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
