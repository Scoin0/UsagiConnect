using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UsagiConnect.WForms.CustomControls
{
    public class CircularPictureBox : PictureBox
    {
        private int borderSize = 2;
        private Color borderColor = Color.RoyalBlue;
        private Color borderColor2 = Color.Purple;
        private DashStyle borderDashStyle = DashStyle.Solid;
        private DashCap borderDashCap = DashCap.Flat;
        private float gradientAngle = 50f;

        public CircularPictureBox()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public Color BorderColor2 { get => borderColor2; set { borderColor2 = value; this.Invalidate(); } }
        public DashStyle BorderDashStyle { get => borderDashStyle; set { borderDashStyle = value; this.Invalidate(); } }
        public DashCap BorderDashCap { get => borderDashCap; set { borderDashCap = value; this.Invalidate(); } }
        public float GradientAngle { get => gradientAngle; set { gradientAngle = value; this.Invalidate(); } }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var graphic = pe.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize);
            var smoothSize = borderSize > 0 ? borderSize * 3 : 1;
            using var borderGColor = new LinearGradientBrush(rectBorder, borderColor, borderColor2, gradientAngle);
            using var pathRegion = new GraphicsPath();
            using var penSmooth = new Pen(this.Parent.BackColor, smoothSize);
            using var penBorder = new Pen(borderGColor, borderSize);
            {
                penBorder.DashStyle = borderDashStyle;
                penBorder.DashCap = borderDashCap;
                pathRegion.AddEllipse(rectContourSmooth);
                this.Region = new Region(pathRegion);
                graphic.SmoothingMode = SmoothingMode.HighQuality;

                graphic.DrawEllipse(penBorder, rectContourSmooth);
                if (borderSize > 0)
                    graphic.DrawEllipse(penBorder, rectBorder);
            }
        }
    }
}