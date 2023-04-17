using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace UsagiConnect.WForms.CustomControls
{
    public class ToggleSlider : CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        public Color OnBackColor { get => onBackColor; set { onBackColor = value; this.Invalidate(); } }
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; this.Invalidate(); } }
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; this.Invalidate(); } }
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; this.Invalidate(); } }
        [DefaultValue(true)]
        public bool SolidStyle { get => solidStyle; set { solidStyle = value; this.Invalidate(); } }

        public ToggleSlider()
        {
            this.MinimumSize = new Size(45, 22);
        }

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
            pevent.Graphics.SmoothingMode= SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(OnBackColor, 2), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), 
                    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                if (solidStyle)
                pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(OffBackColor, 2), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor),
                    new Rectangle(2 , 2, toggleSize, toggleSize));
            }
        }
    }
}